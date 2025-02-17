using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class AppointmentDtoProfile : Profile
    {
        public AppointmentDtoProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment>();
        }
    }
}
