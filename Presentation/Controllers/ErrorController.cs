using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/HandleErrorCode/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var viewName = statusCode.ToString();
            return View(viewName);
        }
    }
}
