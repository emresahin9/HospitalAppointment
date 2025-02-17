using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Hospital : IEntity
    {
        public Hospital()
        {
            HospitalMedicalSpecialties = new List<HospitalMedicalSpecialties>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<HospitalMedicalSpecialties> HospitalMedicalSpecialties { get; set; }
    }
}
