using Business.Abstract;
using Business.Exceptions.ExceptionsMessage;
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
    public class PatientManager : IPatientService
    {
        private readonly IPatientDal _patientDal;
        private readonly IPatientRoleDal _patientRoleDal;
        private readonly IRoleDal _roleDal;
        public PatientManager(IPatientDal patientDal, IPatientRoleDal patientRoleDal, IRoleDal roleDal)
        {
            _patientDal = patientDal;
            _patientRoleDal = patientRoleDal;
            _roleDal = roleDal;
        }
        [AuthorizationAspect(Roles = "admin,patient")]
        public PatientDto GetById(int id)
        {
            var patient = _patientDal.Get(x => x.Id == id);
            return MapperTool<MapperType>.Map<Patient, PatientDto>(patient);
        }

        [AuthorizationAspect(Roles = "admin")]
        public List<PatientDto> GetAll()
        {
            var patients = _patientDal.GetAll();
            return MapperTool<MapperType>.Map<List<Patient>, List<PatientDto>>(patients);
        }

        [ValidationAspect(typeof(PatientRegisterDtoValidator))]
        public void Add(PatientRegisterDto patientRegisterDto)
        {
            if (_patientDal.Get(x => x.IdentityNumber == patientRegisterDto.IdentityNumber) != null)
                throw new ErrorInformation(ErrorInformationMessage.RegisteredWithTheSameIdentityNumberMessage);
            if (_patientDal.Get(x => x.Email == patientRegisterDto.Email) != null)
                throw new ErrorInformation(ErrorInformationMessage.RegisteredWithTheSameEmailAddressMessage);
            if (_patientDal.Get(x => x.PhoneNumber == patientRegisterDto.PhoneNumber) != null)
                throw new ErrorInformation(ErrorInformationMessage.RegisteredWithTheSamePhoneNumberMessage);

            var patient = MapperTool<MapperType>.Map<PatientRegisterDto, Patient>(patientRegisterDto);
            patient.Password = Crypto.Hash(patient.Password, "MD5");
            _patientDal.Add(patient);

            var patientRole = new PatientRole
            {
                PatientId = patient.Id,
                RoleId = _roleDal.Get(x => x.Name == "patient").Id
            };
            _patientRoleDal.Add(patientRole);
        }

        [AuthorizationAspect(Roles = "patient")]
        //[ValidationAspect(typeof(PatientDtoValidator))]
        public void Update(PatientDto patientDto)
        {
            var patient = MapperTool<MapperType>.Map<PatientDto, Patient>(patientDto);
            patient.Password = _patientDal.Get(x => x.Id == patient.Id).Password;

            _patientDal.Update(patient);
        }

        [AuthorizationAspect(Roles = "admin")]
        public void DeleteById(int id)
        {
            _patientDal.Delete(x => x.Id == id);
        }

        [ValidationAspect(typeof(LoginDtoValidator))]
        public string Login(LoginDto loginDto)
        {
            var patient = _patientDal.Get(x => x.Email == loginDto.Email && x.Password == Crypto.Hash(loginDto.Password, "MD5"), x => x.Include(i => i.PatientRoles).ThenInclude(t => t.Role));

            if (patient == null)
                throw new ErrorInformation("Email veya şifre hatalı");

            return WebAuthenticationHelper.CreateAutCookie(patient.Name + " " + patient.Surname, patient.PatientRoles.Select(s => s.Role.Name).ToArray(), patient.Id, patient.Email);
        }
    }
}
