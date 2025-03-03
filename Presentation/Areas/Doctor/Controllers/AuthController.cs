using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Model.Concrete.Dto;
using Presentation.Filters.ExceptionFilters;

namespace Presentation.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class AuthController : Controller
    {
        private readonly IDoctorService _doctorService;
        public AuthController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Login()
        {
            DeleteCookies();

            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter))]
        [TypeFilter(typeof(ErrorInformationExceptionFilter))]
        public IActionResult Login(LoginDto model)
        {
            var cookie = _doctorService.Login(model);

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

            return Redirect("/Doctor/Home/Index");
        }

        public IActionResult LogOut()
        {
            DeleteCookies();

            return Redirect("/Doctor/Auth/Login");
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
