using System.Security.Principal;

namespace Core.Utilities.Security
{
    public class Identity : IIdentity
    {
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
