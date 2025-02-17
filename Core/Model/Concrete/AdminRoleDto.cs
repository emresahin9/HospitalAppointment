using Core.Model.Abstract;

namespace Core.Model.Concrete
{
    public class AdminRoleDto : IDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public AdminDto Admin { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
