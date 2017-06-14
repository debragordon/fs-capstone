using System.Web;
using System.Web.Optimization;

namespace DuckDuck
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/angular-material.css",
                      "~/Content/angular-material.layout-attributes.css",
                      "~/Content/angular-material.layouts.css",
                      "~/Content/angular-material.layouts.ie_fixes.css",
                      "~/Content/Site.css",
                      "~/Content/Login.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-route.js",
                    "~/Scripts/angular-animate.js",
                    "~/Scripts/angular-aria.js",
                    "~/Scripts/angular-material.js",
                    "~/Scripts/angular-mocks.js",
                    "~/app/app.js")
                .IncludeDirectory("~/app", "*.js", true));
        }
    }
}
