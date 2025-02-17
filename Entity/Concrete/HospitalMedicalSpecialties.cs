using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class HospitalMedicalSpecialties : IEntity
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public int MedicalSpecialtyId { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
    }
}
