using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<PlatformReadDto, PlatformPublishedDto>();
            CreateMap<Platform, GrpcPlatformModel>()
                .ForMember(target => target.PlatformId, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.Name, opt => opt.MapFrom(source => source.Name))    // more explicit
                .ForMember(target => target.Publisher, opt => opt.MapFrom(source => source.Publisher));     // more explicit      
        }
    }
}
