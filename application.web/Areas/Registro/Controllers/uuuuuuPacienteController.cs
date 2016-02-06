using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.Entity;

namespace application.web.Areas.Registro.Controllers
{
    [Authorize]
    public class uuuuuuPacienteController : Controller
    {
        private application.BL.IPacienteService PacienteService = new application.BL.PacienteService();
        // GET: Registro/Default

        public ActionResult lista() {
             
             return View(PacienteService.BL_ListaPaciente());
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Paciente Model)
        {
            if (ModelState.IsValid)
            {


                IList<RespuestaGlobal> respuesta = this.PacienteService.BL_InsertaPaciente(Model);

                if (respuesta.Count() > 0)
                {
                    string texto = respuesta[0].RespText;
                    string cls = respuesta[0].RespClass;
                    string respue = ("<div class='" + cls + "'>" + texto + "</div>");
                    TempData["mensajeserver"] = respue;
                    if (respuesta[0].RespEstado == "true")
                    {                        
                        //return View("../../../../Views/Home/Mensaje");                        
                        //return View("~/Views/Home/Mensaje");                        
                        return RedirectToAction("Mensaje", "Home", new { area = "" } );
                    }
                    else {
                        return View(Model);
                    }

                }
                else {
                    return HttpNotFound();
                }
                
            }
            else
            {
                return HttpNotFound();
            }


           
        }

    }
}