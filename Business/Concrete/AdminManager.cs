using Business.Abstract;
using Business.ValidationRules.FluentValidation.Rules;
using Core.Aspects.Autofac.Validation;
using Core.Entity.Concrete;
using Core.Model.Concrete;
using Core.Utilities.MappingTools.Concrete;
using Core.Utilities.Exceptions;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Model.Concrete.Dto;
using System.Linq.Expressions;
using MapperType = Business.Mappers.AutoMapper.AutoMapper;
using Core.Utilities.Security;
using System.Data;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        [ValidationAspect(typeof(LoginDtoValidator))]
        public string Login(LoginDto loginDto)
        {
            var admin = _adminDal.Get(x => x.Email == loginDto.Email && x.Password == loginDto.Password, x => x.Include(i => i.AdminRoles).ThenInclude(t => t.Role));

            if (admin == null)
                throw new ErrorInformation("Email veya şifre hatalı");

            return WebAuthenticationHelper.CreateAutCookie(admin.Name + " " + admin.Surname, admin.AdminRoles.Select(s => s.Role.Name).ToArray(), admin.Id, admin.Email);
        }

        public AdminDto Get(Expression<Func<Admin, bool>> filter)
        {
            var admin = _adminDal.Get(filter, i => i.Include(x => x.AdminRoles).ThenInclude(x => x.Role));

            return MapperTool<MapperType>.Map<Admin, AdminDto>(admin);
        }

    }
}
