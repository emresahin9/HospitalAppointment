using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Model.Concrete.Dto;
using Presentation.Filters.ExceptionFilters;

namespace Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IAdminService _adminService;
        public AuthController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/admin/home/index");

            DeleteCookies();

            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter))]
        [TypeFilter(typeof(ErrorInformationExceptionFilter))]
        public IActionResult Login(LoginDto model)
        {
            var cookie = _adminService.Login(model);

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

            return Redirect("/admin/home/index");
        }

        public IActionResult LogOut()
        {
            DeleteCookies();

            return Redirect("/admin/auth/login");
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
