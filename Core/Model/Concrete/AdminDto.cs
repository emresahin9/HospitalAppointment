using Core.Model.Abstract;

namespace Core.Model.Concrete
{
    public class AdminDto : IDto
    {
        public AdminDto()
        {
            Roles = new List<RoleDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
