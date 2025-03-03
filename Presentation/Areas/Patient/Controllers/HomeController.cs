using Autofac.Core;
using Business.Abstract;
using Business.Exceptions;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters.ActionFilters;

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
