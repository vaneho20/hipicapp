using Microsoft.Owin;

[assembly: OwinStartup(typeof(Hipica.Backend.Startup))]

namespace Hipica.Backend
{
    using Hipica.Backend.Authentication.Repository;
    using Microsoft.Owin.Cors;
    using Owin;
    using System.Web.Http;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);

            app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}