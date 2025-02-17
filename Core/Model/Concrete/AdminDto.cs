using Core.Entity.Concrete;
using Core.Model.Abstract;

namespace Core.Model.Concrete
{
    public class AdminDto : IDto
    {
        public AdminDto()
        {
            AdminRoles = new List<AdminRoleDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<AdminRoleDto> AdminRoles { get; set; }
    }
}
