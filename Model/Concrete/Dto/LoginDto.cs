using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
