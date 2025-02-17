using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Security;

namespace Core.Aspects.Autofac.Authorization
{
    public class AuthorizationAspect : MethodInterception
    {
        public string Roles { get; set; }

        protected override void OnBefore(IInvocation invocation)
        {
            var isAuthorized = false;

            var roles = Roles.Split(',');

            var currentPrincipal = Thread.CurrentPrincipal;

            if (currentPrincipal != null)
            {
                foreach (var role in roles)
                {

                    if (currentPrincipal.IsInRole(role))
                    {
                        isAuthorized = true;

                        break;
                    }
                }

            }


            if (!isAuthorized)
            {
                throw new SecurityException("403 Forbidden");
            }
        }
    }
}
