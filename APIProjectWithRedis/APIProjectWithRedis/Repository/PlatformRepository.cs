using APIProjectWithRedis.Models;
using Microsoft.AspNetCore.Mvc;
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

            /*db.StringSet(platform.Id, serialPlatform);*/
            /*db.SetAdd("platforms", serialPlatform);*/
            db.HashSet("hashplatform", new HashEntry[] { new HashEntry(platform.Id, serialPlatform) });
        }

        public IEnumerable<Platform?>? GetAllPlatforms()  
        {
            var db = _redisConnector.GetDatabase();

            //var set = db.SetMembers("platforms");

            var hashSet = db.HashGetAll("hashplatform");

            if(hashSet != null)
            {
                var returnSet = Array.ConvertAll(hashSet, value => JsonSerializer.Deserialize<Platform>(value.Value)).ToList();

                return returnSet;
            }

            return null;
        }

        public Platform? GetPlatformById(string id)
        {
            var db = _redisConnector.GetDatabase();

            var platform = db.HashGet("hashplatform", id);

            if (!string.IsNullOrEmpty(platform))
            {
                return JsonSerializer.Deserialize<Platform>(platform);
            }

            return null;
        }

        public void DeletePlatform(string id)
        {
            var db = _redisConnector.GetDatabase();

            var platform = db.HashGet("hashplatform", id);

            if (!string.IsNullOrEmpty(platform))
            {
                db.HashDelete("hashplatform", id);
            }
            else
            {
                throw new ArgumentNullException(nameof(platform));
            }
        }

        public void UpdatePlatform(Platform platform)
        {
            var db = _redisConnector.GetDatabase();

            var toBeupdatedPlatform = db.HashGet("hashplatform", platform.Id);

            if (!string.IsNullOrEmpty(toBeupdatedPlatform))
            {
                db.HashSet("hashplatform", new HashEntry[] { new HashEntry(platform.Id, JsonSerializer.Serialize(platform)) });
            }
            else
            {
                throw new ArgumentNullException(nameof(platform));
            }
        }
    }
}
