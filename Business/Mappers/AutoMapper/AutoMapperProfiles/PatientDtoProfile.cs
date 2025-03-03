using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class PatientDtoProfile : Profile
    {
        public PatientDtoProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(x => x.Roles, i => i.MapFrom(x => x.PatientRoles.Select(x => x.Role)));
            CreateMap<PatientDto, Patient>();

            CreateMap<PatientRegisterDto, Patient>();
        }
    }
}

