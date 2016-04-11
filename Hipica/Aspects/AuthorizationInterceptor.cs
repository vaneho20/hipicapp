using AopAlliance.Intercept;
using Hipica.Filters;
using System.Web;

namespace Hipica.Aspects
{
    public class AuthorizationInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            var attr = (AuthorizeEnumAttribute)System.Attribute.GetCustomAttribute(invocation.Method, typeof(AuthorizeEnumAttribute));
            if (attr != null)
            {
                //attr.OnAuthorization(HttpContext.Current.Request.Filter);
            }
            return invocation.Proceed();
        }
    }
}