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

            CreateMap<Appointment, AppointmentToBeTakenDto>()
                .ForMember(x => x.IsAvailable, i => i.MapFrom(x => !x.PatientId.HasValue));

            CreateMap<Appointment, PatientMyAppointmentPageAppointmentDto>();
        }
    }
}
