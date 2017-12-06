using System.Web;
using System.Web.Optimization;

namespace FleeteInvoicing
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                  "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/MaterialDesign/plugins/bootstrap/css/bootstrap.css",
                          "~/MaterialDesign/plugins/node-waves/waves.css",
                          "~/MaterialDesign/plugins/animate-css/animate.css",
                          "~/MaterialDesign/plugins/morrisjs/morris.css",
                          "~/MaterialDesign/css/style.css",
                          "~/Content/font-awesome.min.css",
                          "~/MaterialDesign/css/themes/all-themes.css"));
            bundles.Add(new StyleBundle("~/Content/materialize").Include(
                            "~/Content/materialize/css/materialize.css"));


            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(

                     "~/MaterialDesign/plugins/jquery/jquery.min.js",
                    "~/MaterialDesign/plugins/bootstrap/js/bootstrap.js",
                    "~/MaterialDesign/plugins/bootstrap-select/js/bootstrap-select.js",
                     "~/MaterialDesign/plugins/jquery-slimscroll/jquery.slimscroll.js",
                     "~/MaterialDesign/plugins/node-waves/waves.js",

                     "~/MaterialDesign/plugins/jquery-countto/jquery.countTo.js",
                     "~/MaterialDesign/plugins/raphael/raphael.min.js",
                     "~/MaterialDesign/plugins/morrisjs/morris.js",
                     "~/MaterialDesign/plugins/chartjs/Chart.bundle.js",
                    "~/MaterialDesign/plugins/flot-charts/jquery.flot.js",
                    "~/MaterialDesign/plugins/flot-charts/jquery.flot.pie.js",
                    "~/MaterialDesign/plugins/flot-charts/jquery.flot.categories.js",
                    "~/MaterialDesign/plugins/flot-charts/jquery.flot.time.js",
                    "~/MaterialDesign/plugins/jquery-sparkline/jquery.sparkline.js",
                    "~/MaterialDesign/plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js",
                    "~/MaterialDesign/js/admin.js"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize/materialize.js"));
        }
    }
}
