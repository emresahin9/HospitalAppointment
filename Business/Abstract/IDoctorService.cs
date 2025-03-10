﻿using Model.Concrete.Dto;

namespace Business.Abstract
{
    public interface IDoctorService
    {
        DoctorDto GetById(int id);
        List<DoctorDto> GetAll();
        List<DoctorForSelectListDto> GetAllForSelectListByMedicalSpecialtyId(int medicalSpecialtyId);
        void Add(DoctorDto doctorDto);
        void Update(DoctorDto doctorDto);
        void DeleteById(int id);
        string Login(LoginDto loginDto);
    }
}
