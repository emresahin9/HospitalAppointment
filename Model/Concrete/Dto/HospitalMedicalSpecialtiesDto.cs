using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class HospitalMedicalSpecialtiesDto : IDto
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public HospitalDto Hospital { get; set; }
        public int MedicalSpecialtyId { get; set; }
        public DoctorDto MedicalSpecialty { get; set; }
    }
}
