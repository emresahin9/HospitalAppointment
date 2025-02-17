using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital{ get; set; }
        public int MedicalSpecialtyId { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
    }
}
