using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class AppointmentToBeTakenDto : IDto
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsAvailable { get; set; }
    }
}
