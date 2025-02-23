using Business.Abstract;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters.ActionFilters;

namespace Presentation.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [TypeFilter(typeof(LoggedInAsADoctor))]
    public class HomeController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public HomeController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OpeningAppointments()
        {
            return View(_appointmentService.GetAppointmentSchedule(Convert.ToInt32(((Identity)User.Identity).Id)));
        }

        public IActionResult OpenTodayForAppointments(string dateTime)
        {
            _appointmentService.MakeTheSelectedDayAvailableForAppointments(DateTime.Parse(dateTime), Convert.ToInt32(((Identity)User.Identity).Id));
            return RedirectToAction("OpeningAppointments");
        }

        public IActionResult CompleteTransaction(string route)
        {
            TempData["IsTransactionCompleted"] = true;
            return RedirectToAction(route);
        }
    }
}
