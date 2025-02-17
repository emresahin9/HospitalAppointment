using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class HospitalMedicalSpecialtiesDtoProfile : Profile
    {
        public HospitalMedicalSpecialtiesDtoProfile()
        {
            CreateMap<HospitalMedicalSpecialties, HospitalMedicalSpecialtiesDto>();
            CreateMap<HospitalMedicalSpecialtiesDto, HospitalMedicalSpecialties>();
        }
    }
}
