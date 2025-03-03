using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class PatientRegisterDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string Address { get; set; }
    }
}
