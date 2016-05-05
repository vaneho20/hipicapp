using System;
using System.Web.Optimization;

namespace Hipicapp
{
    public class DurandalBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);

            // Public site
            bundles.Add(new ScriptBundle("~/Scripts/vendor")
                .Include("~/Scripts/underscore-{version}.js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.cookie.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/moment-with-locales.js")
                .Include("~/Scripts/bootstrap-datetimepicker.js")
                .Include("~/Scripts/knockout-{version}.js")
                .Include("~/Scripts/amplify-{version}.js")
                .Include("~/Scripts/amplify-request-deferred-{version}.js")
                .Include("~/Scripts/fastclick.js")
                .Include("~/Scripts/sjcl-{version}.js")
                .Include("~/Scripts/holder.js")
            );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/ie10mobile.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/bootstrap-datetimepicker.css")
                .Include("~/Content/public.css")
            );

            // Administration zone
            bundles.Add(new ScriptBundle("~/Scripts/administrator-vendor")
                .Include("~/Scripts/underscore-{version}.js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.cookie.js")
                .Include("~/Scripts/jquery.ui.widget.js")
                .Include("~/Scripts/jquery.iframe-transport.js")
                .Include("~/Scripts/jquery.fileupload.js")
                .Include("~/Scripts/jquery.fileupload-process.js")
                .Include("~/Scripts/jquery.fileupload-validate.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/moment-with-locales.js")
                .Include("~/Scripts/bootstrap-datetimepicker.js")
                .Include("~/Scripts/Administrator/custom.js")
                .Include("~/Scripts/Administrator/icheck/icheck.js")
                .Include("~/Scripts/knockout-{version}.js")
                .Include("~/Scripts/knockout-mapping-{version}.js")
                .Include("~/Scripts/knockout-server-side-validation.js")
                .Include("~/Scripts/amplify-{version}.js")
                .Include("~/Scripts/amplify-request-deferred-{version}.js")
                .Include("~/Scripts/fastclick.js")
                .Include("~/Scripts/sjcl-{version}.js")
                .Include("~/Scripts/holder.js")
            );

            bundles.Add(new StyleBundle("~/Content/administrator-css")
                .Include("~/Content/ie10mobile.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/bootstrap-datetimepicker.css")
                .Include("~/Content/Administrator/custom.css")
                .Include("~/Content/Administrator/icheck/flat/red.css")
            );
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}