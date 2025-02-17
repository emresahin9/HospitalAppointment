using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class AuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder ConfigureCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
