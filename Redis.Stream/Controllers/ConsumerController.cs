using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Redis.Stream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string streamKey,
            [FromQuery] string consumerGroup)
        {
            var muxer = await ConnectionMultiplexer.ConnectAsync("localhost");
            var db = muxer.GetDatabase();
            var result = await db.StreamReadGroupAsync(
                streamKey,
                consumerGroup,
                $"{consumerGroup}-1",
                ">",
                1);

            if (result.Any())
            {
                var id = result.First().Id;
                
                var dict = ParseResult(result.First());
                return Ok(dict);
            }
            return  BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Acknowledge(
            [FromRoute] string id,
            [FromQuery] string streamKey,
            [FromQuery] string consumerGroup)
        {
            var muxer = await ConnectionMultiplexer.ConnectAsync("localhost");
            var db = muxer.GetDatabase();

            await db.StreamAcknowledgeAsync(streamKey, consumerGroup, id);

            return Ok();
        }




        Dictionary<string, string> ParseResult(StreamEntry entry)
            => entry.Values.ToDictionary(x => x.Name.ToString(), x => x.Value.ToString());
    }
}