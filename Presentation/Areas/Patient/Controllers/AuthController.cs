using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Model.Concrete.Dto;
using Presentation.Filters.ActionFilters;
using Presentation.Filters.ExceptionFilters;

namespace Presentation.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class AuthController : Controller
    {
        private readonly IPatientService _patientService;
        public AuthController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter))]
        [TypeFilter(typeof(ErrorInformationExceptionFilter))]
        //[ValidateAntiForgeryToken]
        public IActionResult Register(PatientRegisterDto model)
        {
            _patientService.Add(model);

            return Redirect("/Patient/Auth/Login");
        }

        public IActionResult Login()
        {
            DeleteCookies();

            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter))]
        [TypeFilter(typeof(ErrorInformationExceptionFilter))]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(LoginDto model)
        {
            var cookie = _patientService.Login(model);

            if (model.RememberMe)
            {
                HttpContext.Response.Cookies.Append("authCookie", cookie, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(14)
                });
            }
            else
            {
                HttpContext.Response.Cookies.Append("authCookie", cookie);
            }

            return Redirect("/Patient/Home/Index");
        }

        public IActionResult LogOut()
        {
            DeleteCookies();

            return Redirect("/Patient/Auth/Login");
        }

        private void DeleteCookies()
        {
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                if (cookie.Key == "authCookie")
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }
        }
    }
}
