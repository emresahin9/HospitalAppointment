using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Time { get; set; }
        public int DurationInMinutes { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public bool IsAppointmentComplete { get; set; }
    }
}
