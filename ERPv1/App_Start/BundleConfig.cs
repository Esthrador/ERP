using System.Web.Optimization;

namespace ERPv1
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
                      "~/Scripts/umd/popper.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/mdb.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
                      "~/Scripts/DataTables/dataTables.buttons.min.js",
                      "~/Scripts/DataTables/buttons.bootstrap4.min.js",
                      "~/Scripts/DataTables/buttons.html5.min.js",
                      "~/Scripts/DataTables/dataTables.select.min.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/ERPScripts/DubstepMode.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/mdb.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datepicker.standalone.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.min.css",
                      "~/Content/DataTables/css/select.bootstrap4.min.css",
                      //"~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/DataTables/css/buttons.bootstrap4.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
