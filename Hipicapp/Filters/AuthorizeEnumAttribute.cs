using System;
using System.Linq;
using System.Web.Http;

namespace Hipicapp.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeEnumAttribute : AuthorizeAttribute
    {
        public AuthorizeEnumAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
            {
                this.Roles = string.Empty;
            }
            else
            {
                this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
            }
            //throw new ArgumentException("roles");
        }
    }
}