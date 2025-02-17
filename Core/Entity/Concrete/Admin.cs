using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class Admin : IEntity
    {
        public Admin()
        {
            AdminRoles = new List<AdminRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<AdminRole> AdminRoles { get; set; }
    }
}
