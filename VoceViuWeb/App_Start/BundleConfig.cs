using System.Web;
using System.Web.Optimization;

namespace VoceViuWeb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Vendors/JQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Vendors/Angular/angular.js",
                        "~/Scripts/Vendors/Angular/angular-resource.js",
                        "~/Scripts/App/app.js",
                        "~/Scripts/App/Resources/*.js",
                        "~/Scripts/App/Controllers/*.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/utilities").Include(
                "~/Scripts/Vendors/pnotify.custom.min.js",
                "~/Scripts/Vendors/LinqJs/linq.js",
                "~/Scripts/App/NotificationHandler.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/pnotify.custom.css"));
        }
    }
}
