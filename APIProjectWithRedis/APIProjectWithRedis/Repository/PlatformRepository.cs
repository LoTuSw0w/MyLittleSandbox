using APIProjectWithRedis.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace APIProjectWithRedis.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private IConnectionMultiplexer _redisConnector;

        public PlatformRepository(IConnectionMultiplexer redisConnector)
        {
            _redisConnector = redisConnector;
        }

        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            var db = _redisConnector.GetDatabase();

            var serialPlatform = JsonSerializer.Serialize(platform);

            db.StringSet(platform.Id, serialPlatform);

        }

        public IEnumerable<Platform> GetAllPlatforms()  
        {
            throw new NotImplementedException();
        }

        public Platform? GetPlatformById(string id)
        {
            var db = _redisConnector.GetDatabase();

            var platform = db.StringGet(id);

            if (!string.IsNullOrEmpty(platform))
            {
                return JsonSerializer.Deserialize<Platform>(platform);
            }

            return null;
        }
    }
}
