using AutoMapper;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class HospitalDtoProfile : Profile
    {
        public HospitalDtoProfile()
        {
            CreateMap<Hospital, HospitalDto>();
            CreateMap<HospitalDto, Hospital>();
        }
    }
}
