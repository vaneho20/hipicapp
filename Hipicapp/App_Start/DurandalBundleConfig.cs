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
                // iCheck
                .Include("~/Scripts/Administrator/icheck/icheck.js")
                // Flot and Flot plugins
                .Include("~/Scripts/jquery.flot.js")
                .Include("~/Scripts/jquery.flot.pie.js")
                .Include("~/Scripts/jquery.flot.time.js")
                .Include("~/Scripts/jquery.flot.stack.js")
                .Include("~/Scripts/jquery.flot.resize.js")
                .Include("~/Scripts/Administrator/flot/jquery.flot.orderBars.js")
                .Include("~/Scripts/Administrator/flot/date.js")
                .Include("~/Scripts/Administrator/flot/jquery.flot.spline.js")
                .Include("~/Scripts/Administrator/flot/curvedLines.js")
                // jVectorMap
                .Include("~/Scripts/Administrator/maps/jquery-jvectormap-{version}.min.js")
                .Include("~/Scripts/Administrator/maps/jquery-jvectormap-world-mill.js")
                .Include("~/Scripts/Administrator/maps/jquery-jvectormap-us-aea-en.js")
                .Include("~/Scripts/Administrator/maps/gdp-data.js")
                // Knockout JS
                .Include("~/Scripts/knockout-{version}.js")
                .Include("~/Scripts/knockout-mapping-{version}.js")
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
                // iCheck
                .Include("~/Content/Administrator/icheck/flat/red.css")
                // jVectorMap
                .Include("~/Content/Administrator/maps/jquery-jvectormap-{version}.css")
                .Include("~/Content/Administrator/custom.css")
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