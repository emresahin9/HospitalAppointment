using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class DoctorDtoProfile : Profile
    {
        public DoctorDtoProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
        }
    }
}
