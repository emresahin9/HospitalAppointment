using Model.Concrete.Dto;

namespace Business.Abstract
{
    public interface IAppointmentService
    {
        List<AppointmentOnTheScheduleDto> GetAppointmentSchedule(int doctorId);
        void MakeTheSelectedDayAvailableForAppointments(DateTime date, int doctorId);
        List<AppointmentToBeTakenDto> GetAvailableAppointment(int doctorId);
        void TakeAnAppointment(int appointmentId, int patientId);
        List<PatientMyAppointmentPageAppointmentDto> GetPatientAppointments(int patientId);
        void CancelAppointment(int appointmentId, int patientId);
    }
}
