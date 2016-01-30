using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using System.Security.Principal;
namespace application.web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Descripcion de la aplicacion";
            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto de la aplicacion";           
            ViewBag.ApplicationUser =
                 this.User.Identity.IsAuthenticated ? this.User.Identity.Name : "Anonymous";           
            return View();
        }

 

    }
}