using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Patient : IEntity
    {
        public Patient()
        {
            Appointments = new List<Appointment>();
            PatientRoles = new List<PatientRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<PatientRole> PatientRoles { get; set; }
    }
}
