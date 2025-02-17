using Model.Concrete.Dto;

namespace Business.Abstract
{
    public interface IMedicalSpecialtyService
    {
        MedicalSpecialtyDto GetById(int id);
        List<MedicalSpecialtyDto> GetAll();
        void Add(MedicalSpecialtyDto medicalSpecialtyDto);
        void Update(MedicalSpecialtyDto medicalSpecialtyDto);
        void DeleteById(int id);
    }
}
