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
                     new RouteValueDictionary(new { area = "admin", controller = "auth", action = "login" })
                );
            }
            else
            {
                var identity = (Identity)context.HttpContext.User.Identity;

                if (identity.Roles.FirstOrDefault(x => x == "admin") == null)
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { area = "admin", controller = "auth", action = "login" })
                    );
                }
            }
        }
    }
}
