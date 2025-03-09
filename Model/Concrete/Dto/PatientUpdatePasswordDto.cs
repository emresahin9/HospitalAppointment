using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class PatientUpdatePasswordDto : IDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}
