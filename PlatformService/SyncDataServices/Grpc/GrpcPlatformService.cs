using AutoMapper;
using Grpc.Core;
using PlatformService.Repository;

namespace PlatformService.SyncDataServices.Grpc
{
    public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public GrpcPlatformService(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        public override Task<PlatformResponse> GetAllPlatforms (GetAllRequest request, ServerCallContext context)   // load platforms from db when this procedure is called remotely, instead of as controller api
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
