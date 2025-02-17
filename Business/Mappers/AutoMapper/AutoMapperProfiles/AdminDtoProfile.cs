using AutoMapper;
using Core.Entity.Concrete;
using Core.Model.Concrete;

namespace Business.Mappers.AutoMapper.AutoMapperProfiles
{
    internal class AdminDtoProfile : Profile
    {
        public AdminDtoProfile()
        {
            CreateMap<Admin, AdminDto>()
                .ForMember(x => x.AdminRoles, i => i.MapFrom(x => x.AdminRoles.Select(x => x.Role)));
            CreateMap<AdminDto, Admin>();
        }
    }
}
