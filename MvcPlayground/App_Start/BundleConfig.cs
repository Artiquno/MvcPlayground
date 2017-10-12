using System.Web;
using System.Web.Optimization;

namespace MvcPlayground
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/bower_components/moment/min/moment.min.js",
                        "~/bower_components/moment/min/locales.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/others").Include(
                        "~/node_modules/sweetalert/dist/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/bower_components/angular/angular.min.js",
                        "~/bower_components/angular-touch/angular-touch.min.js",
                        "~/bower_components/ngstorage/ngStorage.min.js",
                        "~/bower_components/angular-bootstrap/ui-bootstrap-tpls.min.js",
                        "~/bower_components/hammerjs/hammer.min.js",
                        "~/bower_components/angular-gestures/gestures.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/bower_components/font-awesome/font-awesome.min.css"));
        }
    }
}
