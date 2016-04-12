using AttributeRouting.Web.Http.WebHost;
using Hipica.Controllers.Abstract;
using Hipica.Controllers.Account;
using System.Web.Http;

//[assembly: WebActivator.PreApplicationStartMethod(typeof(Hipica.AttributeRoutingHttpConfig), "Start")]

namespace Hipica
{
    public static class AttributeRoutingHttpConfig
    {
        public static void RegisterRoutes(HttpRouteCollection routes)
        {
            // See http://github.com/mccalltd/AttributeRouting/wiki for more options.
            // To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            routes.MapHttpAttributeRoutes(config =>
            {
                config.UseLowercaseRoutes = true;
                config.AutoGenerateRouteNames = true;
                //config.AddRoutesFromControllersOfType<HipicaApiController>();
                config.InheritActionsFromBaseController = true;
                config.InMemory = true;
            });
        }

        public static void Start()
        {
            RegisterRoutes(GlobalConfiguration.Configuration.Routes);
        }
    }
}