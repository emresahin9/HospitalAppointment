using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class AdminRole : IEntity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
