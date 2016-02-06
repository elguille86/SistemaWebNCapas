using System.Web;
using System.Web.Optimization;

namespace application.web
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/menu.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/CssLogin").Include(
                "~/Scripts/jquery-{version}.js",
                "~/cssbac/bootstrap.min.js" 
                ));

            bundles.Add(new StyleBundle("~/Content/CssLogin").Include(                      
                      "~/cssbac/login.css",
                        "~/cssbac/animate-custom.css",
                        "~/cssbac/bootstrap.min.css",
                      "~/Content/styles.css"));

            bundles.Add(new StyleBundle("~/themes/CssThemaNuevo").Include(
                      "~/themes/bootstrap.min.css",
                      "~/themes/AdminLTE.min.css",
                      "~/themes/style.css",
                      "~/themes/jquery.bootgrid/jquery.bootgrid.min.css",
                      "~/themes/_all-skins.min.css"));

            bundles.Add(new ScriptBundle("~/themes/js").Include(
                      
                      "~/themes/bootstrap.min.js",
                      "~/themes/bootstrap3-wysihtml5.all.min",
                      "~/Scripts/jquery.bootgrid.min.js",
                      "~/Scripts/jquery.bootgrid.fa.min.js",
                      "~/themes/slimScroll/jquery.slimscroll.min.js",

                      "~/themes/jquery.bootgrid/jquery.bootgrid.min.js",
                      "~/themes/jquery.bootgrid/jquery.bootgrid.fa.min.js",
                        "~/themes/app.min.js",
 
                      "~/themes/demo.js" 
                    
                      ));
            //"~/themes/jQuery-2.1.4.min.js",
                  //"~/themes/app.min.js",
                  //    "~/themes/dashboard.js",
            
        }
    }
}

