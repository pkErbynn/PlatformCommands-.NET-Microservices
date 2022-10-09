using AutoMapper;
using Grpc.Core;
using PlatformService.Repository;

namespace PlatformService.SyncDataServices.Grpc
{
    /// <summary>
    /// Platform as setup as Grpc server as Command service will pull Platform resources from this service on startup
    /// </summary>
    public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public GrpcPlatformService(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        /// <summary>
        ///  Loads platforms from db when this procedure is called remotely, instead of as controller api
        /// </summary>
        /// <param name="request">grpc input</param>
        /// <param name="context">grpc server context</param>
        /// <returns>grpc repeated platform response</returns>
        public override Task<PlatformResponse> GetAllPlatforms (GetAllRequest request, ServerCallContext context)
        {
            var response = new PlatformResponse();

            var platforms = _platformRepo.GetAllPlatforms();    // get from db

            foreach (var platform in platforms)
            {
                response.Platform.Add(_mapper.Map<GrpcPlatformModel>(platform));
            }

            return Task.FromResult(response);
        }
    }
}
