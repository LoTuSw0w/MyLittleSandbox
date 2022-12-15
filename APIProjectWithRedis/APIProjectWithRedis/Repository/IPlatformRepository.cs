using APIProjectWithRedis.Models;

namespace APIProjectWithRedis.Repository
{
    public interface IPlatformRepository
    {
        void CreatePlatform(Platform platform);

        Platform? GetPlatformById(string id);

        IEnumerable<Platform?>? GetAllPlatforms();

        void DeletePlatform(string id);

        void UpdatePlatform(Platform platform);
    }
}
