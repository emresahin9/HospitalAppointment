using Core.Entity.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class DoctorRole : IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
