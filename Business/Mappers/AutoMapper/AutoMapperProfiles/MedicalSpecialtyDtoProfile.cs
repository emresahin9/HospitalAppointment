using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class MedicalSpecialtyDtoProfile : Profile
    {
        public MedicalSpecialtyDtoProfile()
        {
            CreateMap<MedicalSpecialty, MedicalSpecialtyDto>();
            CreateMap<MedicalSpecialtyDto, MedicalSpecialty>();

            CreateMap<MedicalSpecialty, PatientMyAppointmentPageMedicalSpecialtyDto>();
        }
    }
}
