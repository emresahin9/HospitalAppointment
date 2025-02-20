using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Model.Concrete.Dto;
using Presentation.Filters.ActionFilters;
using Presentation.Filters.ExceptionFilters;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [TypeFilter(typeof(LoggedInAsAdmin))]
    public class HomeController : Controller
    {
        private readonly IMedicalSpecialtyService _medicalSpecialtyService;
        private readonly IDoctorService _doctorService;

        public HomeController(IMedicalSpecialtyService medicalSpecialtyService, IDoctorService doctorService)
        {
            _medicalSpecialtyService = medicalSpecialtyService;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region MedicalSpecialty
        public IActionResult MedicalSpecialties()
        {
            return View(_medicalSpecialtyService.GetAll());
        }

        [HttpGet]
        public IActionResult AddMedicalSpecialty()
        {
            return View();
        }

        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.MedicalSpecialty })]
        [HttpPost]
        public IActionResult AddMedicalSpecialty(MedicalSpecialtyDto medicalSpecialtyDto)
        {
            _medicalSpecialtyService.Add(medicalSpecialtyDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("MedicalSpecialties");
        }

        [HttpGet]
        public IActionResult UpdateMedicalSpecialty(int id)
        {
            return View(_medicalSpecialtyService.GetById(id));
        }

        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.MedicalSpecialty })]
        [HttpPost]
        public IActionResult UpdateMedicalSpecialty(MedicalSpecialtyDto medicalSpecialtyDto)
        {
            _medicalSpecialtyService.Update(medicalSpecialtyDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("MedicalSpecialties");
        }

        public IActionResult DeleteMedicalSpecialty(int id)
        {
            _medicalSpecialtyService.DeleteById(id);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("MedicalSpecialties");
        }
        #endregion

        #region Doctor
        public IActionResult Doctors()
        {
            return View(_doctorService.GetAll());
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            TempData["MedicalSpecialties"] = _medicalSpecialtyService.GetAll();
            return View();
        }

        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.Doctor })]
        [HttpPost]
        public IActionResult AddDoctor(DoctorDto doctorDto)
        {
            _doctorService.Add(doctorDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("Doctors");
        }

        [HttpGet]
        public IActionResult UpdateDoctor(int id)
        {
            TempData["MedicalSpecialties"] = _medicalSpecialtyService.GetAll();
            return View(_doctorService.GetById(id));
        }

        [TypeFilter(typeof(ValidationExceptionFilter), Arguments = new object[] { ValidationType.Doctor })]
        [HttpPost]
        public IActionResult UpdateDoctor(DoctorDto doctorDto)
        {
            _doctorService.Update(doctorDto);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("Doctors");
        }

        public IActionResult DeleteDoctor(int id)
        {
            _doctorService.DeleteById(id);

            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction("Doctors");
        }
        #endregion

        public IActionResult CompleteTransaction(string route)
        {
            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction(route);
        }
    }
}
