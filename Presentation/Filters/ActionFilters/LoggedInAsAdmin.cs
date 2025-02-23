using Core.Utilities.Security;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Filters.ActionFilters
{
    public class LoggedInAsAdmin : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.Name == null)
            {
                context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary(new { area = "Admin", controller = "Auth", action = "Login" })
                );
            }
            else
            {
                var identity = (Identity)context.HttpContext.User.Identity;

                if (identity.Roles.FirstOrDefault(x => x == "admin") == null)
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { area = "Admin", controller = "Auth", action = "Login" })
                    );
                }
            }
        }
    }
}
