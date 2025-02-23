using Core.Entity.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class PatientRole : IEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
