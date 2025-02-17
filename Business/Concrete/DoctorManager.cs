using Business.Abstract;
using Business.ValidationRules.FluentValidation.Rules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.MappingTools.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Model.Concrete.Dto;
using MapperType = Business.Mappers.AutoMapper.AutoMapper;


namespace Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal = doctorDal;
        }
        public DoctorDto GetById(int id)
        {
            var doctor = _doctorDal.Get(x => x.Id == id);
            return MapperTool<MapperType>.Map<Doctor, DoctorDto>(doctor);
        }

        public List<DoctorDto> GetAll()
        {
            var doctors = _doctorDal.GetAll(null, i => i.Include(x => x.MedicalSpecialty));
            return MapperTool<MapperType>.Map<List<Doctor>, List<DoctorDto>>(doctors);
        }

        [ValidationAspect(typeof(DoctorDtoValidator))]
        public void Add(DoctorDto doctorDto)
        {
            var doctor = MapperTool<MapperType>.Map<DoctorDto, Doctor>(doctorDto);
            doctor.Password = "12345678";
            doctor.HospitalId = 1;

            _doctorDal.Add(doctor);
        }

        [ValidationAspect(typeof(DoctorDtoValidator))]
        public void Update(DoctorDto doctorDto)
        {
            var doctor = MapperTool<MapperType>.Map<DoctorDto, Doctor>(doctorDto);
            doctor.Password = _doctorDal.Get(x => x.Id == doctor.Id).Password;

            _doctorDal.Update(doctor);
        }

        public void DeleteById(int id)
        {
            _doctorDal.Delete(x => x.Id == id);
        }
    }
}
