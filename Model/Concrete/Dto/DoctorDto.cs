using Core.Model.Abstract;
using Core.Model.Concrete;

namespace Model.Concrete.Dto
{
    public class DoctorDto : IDto
    {
        public DoctorDto()
        {
            Appointments = new List<AppointmentDto>();
            Roles = new List<RoleDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int HospitalId { get; set; }
        public HospitalDto Hospital { get; set; }
        public int? MedicalSpecialtyId { get; set; }
        public MedicalSpecialtyDto MedicalSpecialty { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
        public List<RoleDto> Roles{ get; set; }
    }
}
