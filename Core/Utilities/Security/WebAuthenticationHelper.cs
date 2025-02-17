using System.Text;
using Core.Utilities.Security.Encryptions;

namespace Core.Utilities.Security
{
    public static class WebAuthenticationHelper
    {
        public static string CreateAutCookie(string userName, string[] roles, int id, string email)
        {
            var authTicked = new StringBuilder();
            authTicked.Append(userName);
            authTicked.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                authTicked.Append(roles[i]);

                if (i < roles.Length - 1) authTicked.Append(",");
            }
            authTicked.Append("|");
            authTicked.Append(id);
            authTicked.Append("|");
            authTicked.Append(email);
            return Encryption.EncryptString(authTicked.ToString());
        }

        public static Identity AuthCookieToIdentity(string authCookie)
        {
            var identity = new Identity()
            {
                AuthenticationType = "authCookie",
                IsAuthenticated = true,
                Name = SetName(authCookie),
                Roles = SetRoles(authCookie),
                Id = SetId(authCookie),
                Email = SetEmail(authCookie)
            };
            return identity;
        }

        private static string SetName(string cookie)
        {
            var identityData = cookie.Split('|');
            return identityData[0];
        }

        private static string[] SetRoles(string cookie)
        {
            var identityData = cookie.Split('|');
            return identityData[1].Split(',');
        }

        private static string SetId(string cookie)
        {
            var identityData = cookie.Split('|');
            return identityData[2];
        }

        private static string SetEmail(string cookie)
        {
            var identityData = cookie.Split('|');
            return identityData[3];
        }

    }
}
