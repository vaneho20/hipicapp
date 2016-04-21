using Hipicapp.Filters;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Hipicapp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new InvalidModelStateFilterAttribute());

            config.ParameterBindingRules.Add(p =>
            {
                if (p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Post) || p.ActionDescriptor.SupportedHttpMethods.Contains(HttpMethod.Put))
                {
                    return new ValidParameterBinding(p);
                }
                else
                {
                    return null;
                }
            });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "get", id = UrlParameter.Optional }
            );
        }
    }
}