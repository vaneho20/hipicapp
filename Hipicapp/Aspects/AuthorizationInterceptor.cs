using AopAlliance.Intercept;
using Hipicapp.Filters;
using Hipicapp.Service.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Web.Http;

namespace Hipicapp.Aspects
{
    public class AuthorizationInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            if (!SkipAuthorization(invocation))
            {
                var attr = (AuthorizeEnumAttribute)Attribute.GetCustomAttribute(invocation.Method, typeof(AuthorizeEnumAttribute));
                if (attr != null)
                {
                    var user = Thread.CurrentPrincipal;
                    if (user == null || !user.Identity.IsAuthenticated || !attr.Roles.Any(x => user.IsInRole(x.ToString())))
                    {
                        throw new AccessDeniedException();
                    }
                }
            }
            return invocation.Proceed();
        }

        private static bool SkipAuthorization(IMethodInvocation invocation)
        {
            return Attribute.GetCustomAttribute(invocation.Method, typeof(AllowAnonymousAttribute)) != null;
        }
    }
}