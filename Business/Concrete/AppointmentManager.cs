using Business.Abstract;
using Core.Aspects.Autofac.Authorization;
using DataAccess.Abstract;
using Entity.Concrete;
using Model.Concrete.Dto;

namespace Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;
        private readonly IAppointmentSettingDal _appointmentSettingDal;
        public AppointmentManager(IAppointmentDal appointmentDal, IAppointmentSettingDal appointmentSettingDal)
        {
            _appointmentDal = appointmentDal;
            _appointmentSettingDal = appointmentSettingDal;
        }

        [AuthorizationAspect(Roles = "doctor")]
        public List<AppointmentOnTheScheduleDto> GetAppointmentSchedule(int doctorId)
        {
            var datetimeStart = DateTime.Now.AddDays(1);
            var datetimeEnd = DateTime.Now.AddMonths(1);
            List<AppointmentOnTheScheduleDto> appointmentSchedule = new List<AppointmentOnTheScheduleDto>();

            while (datetimeStart.Date <= datetimeEnd.Date)
            {
                var appointmentOnTheScheduleDto = new AppointmentOnTheScheduleDto { Datetime = datetimeStart, IsSelectable = true };
                if ((int)datetimeStart.DayOfWeek == 6 || (int)datetimeStart.DayOfWeek == 0 || _appointmentDal.Get(x => x.DoctorId == doctorId && x.Time.Date == datetimeStart.Date) != null)
                {
                    appointmentOnTheScheduleDto.IsSelectable = false;
                }
                appointmentSchedule.Add(appointmentOnTheScheduleDto);
                datetimeStart = datetimeStart.AddDays(1);
            }

            return appointmentSchedule;
        }

        [AuthorizationAspect(Roles = "doctor")]
        public void MakeTheSelectedDayAvailableForAppointments(DateTime date, int doctorId)
        {
            if (date.Date > DateTime.Now.Date && date.Date <= DateTime.Now.AddMonths(1).Date)
            {
                if (_appointmentDal.Get(x => x.DoctorId == doctorId && x.Time.Date == date.Date) == null)
                {
                    var appointmentSetting = _appointmentSettingDal.Get(x => x.Id == 1);
                    int appointmentHour = appointmentSetting.AppointmentStartTimeInHours;
                    int appointmentMinute = 0;

                    while (appointmentHour < appointmentSetting.AppointmentEndTimeInHours)
                    {
                        Appointment appointment = new Appointment() { DoctorId = doctorId, DurationInMinutes = appointmentSetting.AppointmentDurationInMinutes, Time = new DateTime(date.Year, date.Month, date.Date.Day, appointmentHour, appointmentMinute, 0), IsAppointmentComplete = false };
                        _appointmentDal.Add(appointment);

                        appointmentMinute += appointmentSetting.AppointmentDurationInMinutes;
                        if (appointmentMinute == 60)
                        {
                            appointmentMinute = 0;
                            appointmentHour++;
                        }
                        if (appointmentHour == appointmentSetting.BreakStartTimeInHours)
                            appointmentHour++;
                    }
                }
            }
        }
    }
}
