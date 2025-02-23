using Model.Concrete.Dto;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        List<AppointmentOnTheScheduleDto> GetAppointmentSchedule(int doctorId);
        void MakeTheSelectedDayAvailableForAppointments(DateTime date, int doctorId);
    }
}
