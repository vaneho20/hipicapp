using Hipica.Maps;
using System.Web.Optimization;

[assembly: WebActivator.PostApplicationStartMethod(
    typeof(Hipica.App_Start.DurandalConfig), "PreStart")]

namespace Hipica.App_Start
{
    public static class DurandalConfig
    {
        public static void PreStart()
        {
            // Add your start logic here
            DurandalBundleConfig.RegisterBundles(BundleTable.Bundles);

            //MapperStarter.Startup();
        }
    }
}