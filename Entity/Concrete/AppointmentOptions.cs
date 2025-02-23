using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class AppointmentSetting : IEntity
    {
        public int Id { get; set; }
        public int AppointmentDurationInMinutes { get; set; }
        public int AppointmentStartTimeInHours { get; set; }
        public int AppointmentEndTimeInHours { get; set; }
        public int BreakStartTimeInHours { get; set; }
        public int BreakEndTimeInHours { get; set; }
    }
}
