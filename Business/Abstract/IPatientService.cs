using Model.Concrete.Dto;

namespace Business.Abstract
{
    public interface IPatientService
    {
        PatientDto GetById(int id);
        List<PatientDto> GetAll();
        void Add(PatientRegisterDto patientRegisterDto);
        void Update(PatientDto patientDto);
        void DeleteById(int id);
        string Login(LoginDto loginDto);
    }
}
