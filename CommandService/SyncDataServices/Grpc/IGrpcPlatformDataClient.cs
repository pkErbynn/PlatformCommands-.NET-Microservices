using CommandService.Models;

namespace CommandService.SyncDataServices.Grpc
{
    public interface IGrpcPlatformDataClient
    {
        IEnumerable<Platform> PullAllPlatorms();
    }
}
