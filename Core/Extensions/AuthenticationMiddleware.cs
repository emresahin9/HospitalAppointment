using Core.Utilities.Security;
using Core.Utilities.Security.Encryptions;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace Core.Extensions
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var cookie = httpContext.Request.Cookies["authCookie"];

                if (!string.IsNullOrEmpty(cookie))
                {
                    var userData = Encryption.DecryptString(cookie);

                    var identity = WebAuthenticationHelper.AuthCookieToIdentity(userData);

                    var principal = new GenericPrincipal(identity, identity.Roles);

                    httpContext.User = principal;

                    Thread.CurrentPrincipal = principal;
                }

            }
            catch
            {

            }

            await _next.Invoke(httpContext);
        }
    }
}
