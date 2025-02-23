using Core.Model.Abstract;

namespace Model.Concrete.Dto
{
    public class AppointmentOnTheScheduleDto : IDto
    {
        public DateTime Datetime { get; set; }
        public bool IsSelectable { get; set; }
    }
}
