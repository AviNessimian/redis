using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace Redis.Cache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IRedisDatabase redisDatabase;
        private readonly IRedisClientFactory redisClientFactory;
        

        public TestController(
            IRedisDatabase redisDatabase,
            IRedisClientFactory redisClientFactory)
        {
            this.redisDatabase = redisDatabase;
            this.redisClientFactory = redisClientFactory;
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<IActionResult> Get([FromRoute] string key)
        {
            var cachedValue = await redisDatabase.GetAsync<object>(key);
            return Ok(cachedValue);
        }
    }
}