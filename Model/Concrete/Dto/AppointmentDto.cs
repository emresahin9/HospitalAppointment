using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class AppointmentDto : IDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorDto Doctor { get; set; }
        public DateTime Time { get; set; }
        public int DurationInMinutes { get; set; }
        public int? PatientId { get; set; }
        public PatientDto Patient { get; set; }
        public bool IsAppointmentComplete { get; set; }
    }
}
