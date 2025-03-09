using Autofac.Core;
using Business.Abstract;
using Business.Exceptions;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Model.Concrete.Dto;
using Presentation.Filters.ActionFilters;
using Presentation.Filters.ExceptionFilters;

namespace Presentation.Areas.Patient.Controllers
{
    [Area("Patient")]
    [TypeFilter(typeof(LoggedInAsAPatient))]
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IMedicalSpecialtyService _medicalSpecialtyService;
        private readonly IAppointmentService _appointmentService;
        public HomeController(IPatientService patientService, IDoctorService doctorService, IMedicalSpecialtyService medicalSpecialtyService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _medicalSpecialtyService = medicalSpecialtyService;
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TakeAppointment()
        {
            TempData["MedicalSpecialties"] = _medicalSpecialtyService.GetAll();
            return View();
        }

        public IActionResult MyAppointments()
        {
            return View(_appointmentService.GetPatientAppointments(Convert.ToInt32(((Identity)User.Identity).Id)));
        }

        public IActionResult UpdatePersonalInfo()
        {
            return View(_patientService.GetByIdForUpdatePersonalInfo(Convert.ToInt32(((Identity)User.Identity).Id)));
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.PatientUpdatePersonalInfo })]
        public IActionResult UpdatePersonalInfo(PatientUpdatePersonalInfoDto patientUpdatePersonalInfoDto)
        {
            patientUpdatePersonalInfoDto.Id = Convert.ToInt32(((Identity)User.Identity).Id);
            _patientService.UpdatePersonalInfo(patientUpdatePersonalInfoDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("Index");
        }

        public IActionResult UpdateContactInfo()
        {
            return View(_patientService.GetByIdForUpdateContactInfo(Convert.ToInt32(((Identity)User.Identity).Id)));
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.PatientUpdateContactInfo })]
        public IActionResult UpdateContactInfo(PatientUpdateContactInfoDto patientUpdateContactInfoDto)
        {
            patientUpdateContactInfoDto.Id = Convert.ToInt32(((Identity)User.Identity).Id);
            _patientService.UpdateContactInfo(patientUpdateContactInfoDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePassword()
        {
            return View(_patientService.GetByIdForUpdatePassword(Convert.ToInt32(((Identity)User.Identity).Id)));
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.PatientUpdatePassword })]
        [TypeFilter(typeof(ErrorInformationExceptionFilter))]
        public IActionResult UpdatePassword(PatientUpdatePasswordDto patientUpdatePasswordDto)
        {
            patientUpdatePasswordDto.Id = Convert.ToInt32(((Identity)User.Identity).Id);
            _patientService.UpdatePassword(patientUpdatePasswordDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("Index");
        }

        public IActionResult TakeAnAppointment(int appointmentId)
        {
            try
            {
                _appointmentService.TakeAnAppointment(appointmentId, Convert.ToInt32(((Identity)User.Identity).Id));
                return RedirectToAction("Index");
            }
            catch (JsonErrorException ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        public IActionResult CancelAppointment(int appointmentId)
        {
            try
            {
                _appointmentService.CancelAppointment(appointmentId, Convert.ToInt32(((Identity)User.Identity).Id));
                return RedirectToAction("Index");
            }
            catch (JsonErrorException ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        public JsonResult GetDoctors(int medicalSpecialtyId)
        {
            var doctors = _doctorService.GetAllForSelectListByMedicalSpecialtyId(medicalSpecialtyId);
            return Json(doctors);
        }
        
        public JsonResult GetAppointments(int doctorId)
        {
            var appointments = _appointmentService.GetAvailableAppointment(doctorId);
            return Json(appointments);
        }

        public IActionResult CompleteTransaction(string route)
        {
            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction(route);
        }
    }
}
