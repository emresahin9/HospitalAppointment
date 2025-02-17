using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class MedicalSpecialty : IEntity
    {
        public MedicalSpecialty()
        {
            HospitalMedicalSpecialties = new List<HospitalMedicalSpecialties>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<HospitalMedicalSpecialties> HospitalMedicalSpecialties { get; set; }
    }
}
