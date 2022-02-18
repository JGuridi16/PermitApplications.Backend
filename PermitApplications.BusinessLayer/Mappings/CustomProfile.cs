using AutoMapper;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Persistence.Entities;

namespace PermitApplications.BusinessLayer.Mappings
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Permit, PermitDto>().ReverseMap();
            CreateMap<PermitType, PermitTypeDto>().ReverseMap();
            CreateMap<Permit, PermitDto>()
                .ForMember(x => x.PermitType, y => y.MapFrom(x => x.PermitType))
                ;
        }
    }
}
