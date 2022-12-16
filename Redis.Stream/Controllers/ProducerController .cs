using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Text.Json;

namespace Redis.Stream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string streamKey,
            [FromQuery] string consumerGroup)
        {
            var muxer = await ConnectionMultiplexer.ConnectAsync("localhost");
            var db = muxer.GetDatabase();

            // Create the consumer group
            if (!(await db.KeyExistsAsync(streamKey))
                ||
                (await db.StreamGroupInfoAsync(streamKey)).All(x => x.Name != consumerGroup))
            {
                await db.StreamCreateConsumerGroupAsync(streamKey, consumerGroup, "0-0", true);
            }

            // Write a random number between 50 and 65 as the temp and send the current time as the time
            var currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            var value = JsonSerializer.Serialize(new
            {
                value = new Random().Next(50, 65)
            });
            var streamPairs = new NameValueEntry[]
            {
                new ("temp", value),
                new ("time", currentTime)
            };
            await db.StreamAddAsync(streamKey, streamPairs);
            return Ok();
        }
    }
}