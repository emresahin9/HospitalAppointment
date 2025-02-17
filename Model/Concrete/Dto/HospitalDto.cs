using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class HospitalDto : IDto
    {
        public HospitalDto()
        {
            HospitalMedicalSpecialties = new List<HospitalMedicalSpecialtiesDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<HospitalMedicalSpecialtiesDto> HospitalMedicalSpecialties { get; set; }
    }
}
