using PlatformService.Models;

namespace PlatformService.Repository
{
    public interface IPlatformRepo
    {
        Platform GetPlatformById(int id);
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool SaveChanges();

    }
}
