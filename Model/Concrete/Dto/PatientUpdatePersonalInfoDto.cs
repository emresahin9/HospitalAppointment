using Core.Model.Abstract;
using Core.Model.Concrete;

namespace Model.Concrete.Dto
{
    public class PatientUpdatePersonalInfoDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
    }
}