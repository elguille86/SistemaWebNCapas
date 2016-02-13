using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace application.web.Areas.Registro.Controllers
{
    [Authorize]
    public class ComprobanteController : Controller
    {
        // GET: Registro/Comprobante
        public ActionResult Index()
        {
            return RedirectToAction("RegistraComprobante", "Comprobante", new { area = "Registro" });
            
        }
        public ActionResult RegistraComprobante()
        {
            ViewBag.TitlePag = "Registrar Comprobante";
            return View();
        }
    }
}