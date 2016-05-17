using Hipicapp.Filters;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Hipicapp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.ParameterBindingRules.Add(p =>
            {
                if (p.GetCustomAttributes<ValidAttribute>().Any() && (p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Post) || p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Put)
                    || p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Delete)))
                {
                    return new ValidParameterBinding(p);
                }
                else
                {
                    return null;
                }
            });

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}"
            );
        }
    }
}