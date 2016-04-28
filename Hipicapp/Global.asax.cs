/*using NHibernate;
using NHibernate.Context;*/

using Spring.Web.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hipicapp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DurandalBundleConfig.RegisterBundles(BundleTable.Bundles);

            //this.AuthenticateRequest += new EventHandler(WebApiApplication_AuthenticateRequest);
            /*this.BeginRequest += new EventHandler(Hipicapp_BeginRequest);
            this.EndRequest += new EventHandler(Hipicapp_EndRequest);*/
        }

        /*protected void Hipicapp_BeginRequest(
            object sender, EventArgs e)
        {
            ManagedWebSessionContext.Bind(
                HttpContext.Current,
                ServiceLocator.LocateService<ISessionFactory>(ServiceNames.NHIBERNATE_SESSION_FACTORY).OpenSession());
        }

        protected void Hipicapp_EndRequest(
            object sender, EventArgs e)
        {
            ISession session = ManagedWebSessionContext.Unbind(
                HttpContext.Current, ServiceLocator.LocateService<ISessionFactory>(ServiceNames.NHIBERNATE_SESSION_FACTORY));
            if (session != null)
            {
                if (session.Transaction != null &&
                    session.Transaction.IsActive)
                {
                    session.Transaction.Rollback();
                }
                else
                    session.Flush();
                session.Close();
            }
        }*/
    }
}