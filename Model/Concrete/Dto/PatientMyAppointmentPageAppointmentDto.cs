using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class PatientMyAppointmentPageAppointmentDto : IDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public PatientMyAppointmentPageDoctorDto Doctor { get; set; }
        public DateTime Time { get; set; }
        public int DurationInMinutes { get; set; }
        public int? PatientId { get; set; }
        public bool IsAppointmentComplete { get; set; }
    }
}
