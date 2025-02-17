using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class MedicalSpecialtyDto : IDto
    {
        public MedicalSpecialtyDto()
        {
            HospitalMedicalSpecialties = new List<HospitalMedicalSpecialtiesDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<HospitalMedicalSpecialtiesDto> HospitalMedicalSpecialties { get; set; }
    }
}
