using Core.Model.Abstract;

namespace Core.Model.Concrete
{
    public class RoleDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
