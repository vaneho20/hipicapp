using System.Linq;
using System.Security.Principal;

namespace Hipica.Model.Authentication
{
    public class Principal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Principal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public string Username { get; set; }

        public string[] Roles { get; set; }
    }
}