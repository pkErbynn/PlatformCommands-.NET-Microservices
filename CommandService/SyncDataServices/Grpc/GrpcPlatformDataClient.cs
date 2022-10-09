using AutoMapper;
using CommandService.Models;
using Grpc.Net.Client;
using PlatformService;

namespace CommandService.SyncDataServices.Grpc
{
    /// <summary>
    /// Serves as Client to pull all platforms from the Platforms service using Grps
    /// </summary>
    public class GrpcPlatformDataClient : IGrpcPlatformDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GrpcPlatformDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// This client calling remote procedures from platforms procedures/methods
        /// This will be invoked in the startup.cs to pull platforms on start up
        /// </summary>
        /// <returns>platform response from grpc server and map to Platform model</returns>
        public IEnumerable<Platform> PullAllPlatorms()
        {
            Console.WriteLine($"--> Calling Grpc Service {_configuration["GrpsPlatformService"]}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpsPlatformService"]);
             var client = new GrpcPlatform.GrpcPlatformClient(channel);
            var inputRequest = new GetAllRequest();

            try
            {
                var platformResponse = client.GetAllPlatforms(inputRequest);
                return _mapper.Map<IEnumerable<Platform>>(platformResponse.Platform);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not call GRPC Server: {ex.Message} : {ex.StackTrace} ");
                return null;
            }
        }
    }
}
