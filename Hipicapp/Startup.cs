using Microsoft.Owin;

[assembly: OwinStartup(typeof(Hipicapp.Backend.Startup))]

namespace Hipicapp.Backend
{
    using Microsoft.Owin.Cors;
    using Owin;
    using System.Web.Http;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}