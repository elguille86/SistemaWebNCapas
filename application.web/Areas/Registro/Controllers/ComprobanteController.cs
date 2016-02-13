using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.web.Areas.Registro.Models;

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
        [HttpPost]
        public JsonResult SaveOver(CabComprobante o) {

            bool status = false;
            if (ModelState.IsValid) {
                using (BDGRPNETEntities1 dc = new BDGRPNETEntities1()) {

                    TB_COMPROBANTE_CAB order = new TB_COMPROBANTE_CAB { 
                    
                        estab_serie = "117",
                        cabe_fecha = o.cabe_fecha,
                        cabe_ticket ="0111-01444",
                        cabe_hora = DateTime.Now,
                        cod_estab = "E16000000001",
                        usu_docid_codigo = o.usu_docid_codigo,
                        login_user = User.Identity.Name,
                        Nro_Fua ="45454",
                        Mont_Total = o.Mont_Total
                    };
                    foreach (var i in o.TB_COMPROBANTE_DET) {
                        order.TB_COMPROBANTE_DET.Add(i);
                    
                    }
                    dc.TB_COMPROBANTE_CAB.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
                
                status = true;
            } 
            else { status = false; }
            return new JsonResult { Data = new { status = status } };
        }
    }
}