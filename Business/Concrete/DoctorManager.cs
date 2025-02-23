using Business.Abstract;
using Business.ValidationRules.FluentValidation.Rules;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Exceptions;
using Core.Utilities.MappingTools.Concrete;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Model.Concrete.Dto;
using System.Web.Helpers;
using MapperType = Business.Mappers.AutoMapper.AutoMapper;


namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        private readonly IDoctorRoleDal _doctorRoleDal;
        private readonly IRoleDal _roleDal;
        public DoctorManager(IDoctorDal doctorDal, IDoctorRoleDal doctorRoleDal, IRoleDal roleDal)
        {
            _doctorDal = doctorDal;
            _doctorRoleDal = doctorRoleDal;
            _roleDal = roleDal;
        }

        [AuthorizationAspect(Roles = "admin,doctor")]
        public DoctorDto GetById(int id)
        {
            var doctor = _doctorDal.Get(x => x.Id == id);
            return MapperTool<MapperType>.Map<Doctor, DoctorDto>(doctor);
        }

        [AuthorizationAspect(Roles = "admin")]
        public List<DoctorDto> GetAll()
        {
            var doctors = _doctorDal.GetAll(null, i => i.Include(x => x.MedicalSpecialty));
            return MapperTool<MapperType>.Map<List<Doctor>, List<DoctorDto>>(doctors);
        }

        [AuthorizationAspect(Roles = "admin")]
        [ValidationAspect(typeof(DoctorDtoValidator))]
        public void Add(DoctorDto doctorDto)
        {
            var doctor = MapperTool<MapperType>.Map<DoctorDto, Doctor>(doctorDto);
            doctor.Password = Crypto.Hash("12345678", "MD5");
            doctor.HospitalId = 1;
            _doctorDal.Add(doctor);

            var doctorRole = new DoctorRole
            {
                DoctorId = doctor.Id,
                RoleId = _roleDal.Get(x => x.Name == "doctor").Id
            };
            _doctorRoleDal.Add(doctorRole);
        }

        [AuthorizationAspect(Roles = "admin,doctor")]
        [ValidationAspect(typeof(DoctorDtoValidator))]
        public void Update(DoctorDto doctorDto)
        {
            var doctor = MapperTool<MapperType>.Map<DoctorDto, Doctor>(doctorDto);
            doctor.Password = _doctorDal.Get(x => x.Id == doctor.Id).Password;

            _doctorDal.Update(doctor);
        }

        [AuthorizationAspect(Roles = "admin")]
        public void DeleteById(int id)
        {
            _doctorDal.Delete(x => x.Id == id);
        }

        [ValidationAspect(typeof(LoginDtoValidator))]
        public string Login(LoginDto loginDto)
        {
            var admin = _doctorDal.Get(x => x.Email == loginDto.Email && x.Password == Crypto.Hash(loginDto.Password, "MD5"), x => x.Include(i => i.DoctorRoles).ThenInclude(t => t.Role));

            if (admin == null)
                throw new ErrorInformation("Email veya şifre hatalı");

            return WebAuthenticationHelper.CreateAutCookie(admin.Name + " " + admin.Surname, admin.DoctorRoles.Select(s => s.Role.Name).ToArray(), admin.Id, admin.Email);
        }
    }
}
