using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class DoctorDtoProfile : Profile
    {
        public DoctorDtoProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(x => x.Roles, i => i.MapFrom(x => x.DoctorRoles.Select(x => x.Role)));
            CreateMap<DoctorDto, Doctor>();
        }
    }
}
