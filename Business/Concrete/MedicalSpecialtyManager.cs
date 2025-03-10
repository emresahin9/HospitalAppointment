﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation.Rules;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.MappingTools.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Model.Concrete.Dto;
using MapperType = Business.Mappers.AutoMapper.AutoMapper;


namespace Business.Concrete
{
    public class MedicalSpecialtyManager : IMedicalSpecialtyService
    {
        private readonly IMedicalSpecialtyDal _medicalSpecialtyDal;
        private readonly IHospitalMedicalSpecialtiesDal _hospitalMedicalSpecialtiesDal;
        private readonly IDoctorDal _doctorDal;
        public MedicalSpecialtyManager(IMedicalSpecialtyDal medicalSpecialtyDal, IHospitalMedicalSpecialtiesDal hospitalMedicalSpecialtiesDal, IDoctorDal doctorDal)
        {
            _medicalSpecialtyDal = medicalSpecialtyDal;
            _hospitalMedicalSpecialtiesDal = hospitalMedicalSpecialtiesDal;
            _doctorDal = doctorDal;
        }

        [AuthorizationAspect(Roles = "admin")]
        public MedicalSpecialtyDto GetById(int id)
        {
            var medicalSpecialty = _medicalSpecialtyDal.Get(x => x.Id == id);
            return MapperTool<MapperType>.Map<MedicalSpecialty, MedicalSpecialtyDto>(medicalSpecialty);
        }

        [AuthorizationAspect(Roles = "admin,patient")]
        public List<MedicalSpecialtyDto> GetAll()
        {
            var medicalSpecialties = _medicalSpecialtyDal.GetAll();
            return MapperTool<MapperType>.Map<List<MedicalSpecialty>, List<MedicalSpecialtyDto>>(medicalSpecialties);
        }

        [AuthorizationAspect(Roles = "admin")]
        [ValidationAspect(typeof(MedicalSpecialtyDtoValidator))]
        public void Add(MedicalSpecialtyDto medicalSpecialtyDto)
        {
            var medicalSpecialty = MapperTool<MapperType>.Map<MedicalSpecialtyDto, MedicalSpecialty>(medicalSpecialtyDto);

            _medicalSpecialtyDal.Add(medicalSpecialty);

            HospitalMedicalSpecialties hospitalMedicalSpecialty = new HospitalMedicalSpecialties()
            {
                MedicalSpecialtyId = medicalSpecialty.Id,
                HospitalId = 1
            };
            _hospitalMedicalSpecialtiesDal.Add(hospitalMedicalSpecialty);
        }

        [AuthorizationAspect(Roles = "admin")]
        [ValidationAspect(typeof(MedicalSpecialtyDtoValidator))]
        public void Update(MedicalSpecialtyDto medicalSpecialtyDto)
        {
            var medicalSpecialty = MapperTool<MapperType>.Map<MedicalSpecialtyDto, MedicalSpecialty>(medicalSpecialtyDto);

            _medicalSpecialtyDal.Update(medicalSpecialty);
        }

        [AuthorizationAspect(Roles = "admin")]
        public void DeleteById(int id)
        {
            _hospitalMedicalSpecialtiesDal.Delete(x => x.MedicalSpecialtyId == id && x.HospitalId == 1);
            var doctors = _doctorDal.GetAll(x => x.MedicalSpecialtyId == id);
            foreach(var doctor in doctors)
            {
                doctor.MedicalSpecialtyId = null;
                _doctorDal.Update(doctor);
            }
            _medicalSpecialtyDal.Delete(x => x.Id == id);
        }
    }
}
