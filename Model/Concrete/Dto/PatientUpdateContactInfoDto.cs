using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class PatientUpdateContactInfoDto : IDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
