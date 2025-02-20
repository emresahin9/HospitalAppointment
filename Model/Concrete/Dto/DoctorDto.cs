using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class DoctorDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int HospitalId { get; set; }
        public HospitalDto Hospital { get; set; }
        public int? MedicalSpecialtyId { get; set; }
        public MedicalSpecialtyDto MedicalSpecialty { get; set; }
    }
}
