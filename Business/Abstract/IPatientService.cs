using Model.Concrete.Dto;

namespace Business.Abstract
{
    public interface IPatientService
    {
        PatientDto GetById(int id);
        List<PatientDto> GetAll();
        void Add(PatientRegisterDto patientRegisterDto);
        void DeleteById(int id);
        string Login(LoginDto loginDto);
        PatientUpdatePersonalInfoDto GetByIdForUpdatePersonalInfo(int id);
        PatientUpdateContactInfoDto GetByIdForUpdateContactInfo(int id);
        PatientUpdatePasswordDto GetByIdForUpdatePassword(int id);
        void UpdatePersonalInfo(PatientUpdatePersonalInfoDto patientUpdatePersonalInfoDto);
        void UpdateContactInfo(PatientUpdateContactInfoDto patientUpdateContactInfoDto);
        void UpdatePassword(PatientUpdatePasswordDto patientUpdatePasswordDto);
    }
}
