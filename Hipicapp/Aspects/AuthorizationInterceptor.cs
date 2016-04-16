using AopAlliance.Intercept;
using Hipicapp.Filters;
using System.Linq;
using System.Threading;
using System.Web;

//using System.Net;
//using System.Net;

namespace Hipicapp.Aspects
{
    public class AuthorizationInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            var attr = (AuthorizeEnumAttribute)System.Attribute.GetCustomAttribute(invocation.Method, typeof(AuthorizeEnumAttribute));
            if (attr != null)
            {
                var user = Thread.CurrentPrincipal;
                if (user == null || !user.Identity.IsAuthenticated || !attr.Roles.Any(x => user.IsInRole(x.ToString())))
                {
                    var request = HttpContext.Current.Request;
                    //HttpContext.Current.Response = HttpContext.Current.CreateErrorResponse(HttpStatusCode.Unauthorized, "");
                }
            }
            return invocation.Proceed();
        }
    }
}