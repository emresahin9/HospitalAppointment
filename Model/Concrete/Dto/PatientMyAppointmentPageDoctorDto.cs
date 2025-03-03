using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class PatientMyAppointmentPageDoctorDto : IDto
    {
        public string FullName { get; set; }
        public PatientMyAppointmentPageMedicalSpecialtyDto MedicalSpecialty { get; set; }
    }
}