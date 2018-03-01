using System.Web;
using System.Web.Optimization;

namespace webAppDevi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            //script
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                     "~/Scripts/bootstrap.js"
           , "~/Scripts/jquery-1.8.3.js"
     , "~/Scripts/jquery.validate.js"
     , "~/Scripts/jquery.validate.unobtrusive.min.js"
       , "~/Scripts/amcharts.js"
        , "~/Scripts/serial.js"
        , "~/Scripts/light.js"
          , "~/Scripts/radar.js"
           , "~/Scripts/vroom.js"
              , "~/Scripts/TweenLite.min.js"
                 , "~/Scripts/CSSPlugin.min.js"
                    , "~/Scripts/jquery.nicescroll.js"
                     , "~/Scripts/scripts.js"));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/custom.css",
                      "~/Content/css/style.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/icon-font.min.css",
                      "~/Content/css/vroom.css")
                      );
            BundleTable.EnableOptimizations = true;
        }
    }
}
