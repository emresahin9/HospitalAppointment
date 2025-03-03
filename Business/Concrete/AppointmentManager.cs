using Business.Abstract;
using Business.Exceptions;
using Core.Aspects.Autofac.Authorization;
using Core.Utilities.MappingTools.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Model.Concrete.Dto;
using MapperType = Business.Mappers.AutoMapper.AutoMapper;

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

        [AuthorizationAspect(Roles = "patient")]
        public List<AppointmentToBeTakenDto> GetAvailableAppointment(int doctorId)
        {
            var appointments = _appointmentDal.GetAll(x => x.DoctorId == doctorId && x.Time.Date > DateTime.Now.Date && x.Time.Date < DateTime.Now.AddDays(31).Date).OrderBy(x => x.Time).ToList();
            return MapperTool<MapperType>.Map<List<Appointment>, List<AppointmentToBeTakenDto>>(appointments);
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

        [AuthorizationAspect(Roles = "patient")]
        public void TakeAnAppointment(int appointmentId, int patientId)
        {
            var appointment = _appointmentDal.Get(x => x.Id == appointmentId, i => i.Include(x => x.Doctor));
            // Bu randevu alıma açılmış mı?
            if(appointment != null)
            {
                // Bu randevu biri tarafından alımış mı ve randevu tarihi bugünden sonraya mı?
                if (appointment.PatientId == null && appointment.Time.Date > DateTime.Now.Date)
                {
                    // Bu hastanın aynı uzmanlık alanında aktif başka bir randevusu var mı?
                    if (_appointmentDal.Get(x => x.PatientId == patientId && !x.IsAppointmentComplete && x.Doctor.MedicalSpecialtyId == appointment.Doctor.MedicalSpecialtyId) == null)
                    {
                        appointment.PatientId = patientId;
                        _appointmentDal.Update(appointment);
                    }
                    else
                        throw new JsonErrorException("Bu branşta randevunuz bulunuyor!");
                }
                else
                    throw new JsonErrorException("Bu randevu biri tarafından alınmış!");
            }
            else
                throw new JsonErrorException("Böyle bir randevu bulunmuyor!");
        }

        [AuthorizationAspect(Roles = "patient")]
        public List<PatientMyAppointmentPageAppointmentDto> GetPatientAppointments(int patientId)
        {
            var appointments = _appointmentDal.GetAll(x => x.PatientId == patientId, i => i.Include(x => x.Doctor).ThenInclude(t => t.MedicalSpecialty));
            return MapperTool<MapperType>.Map<List<Appointment>, List<PatientMyAppointmentPageAppointmentDto>>(appointments);
        }

        [AuthorizationAspect(Roles = "patient")]
        public void CancelAppointment(int appointmentId, int patientId)
        {
            var appointment = _appointmentDal.Get(x => x.Id == appointmentId && x.PatientId == patientId && !x.IsAppointmentComplete);
            if(appointment is null)
                throw new JsonErrorException("Bu randevu iptal edilemiyor!");
            appointment.PatientId = null;
            _appointmentDal.Update(appointment);
        }
    }
}
