using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.Entity;

namespace application.web.Areas.Registro.Controllers
{
   [Authorize]
    public class PacienteController : Controller
    {
        private application.BL.IPacienteService PacienteService = new application.BL.PacienteService();
        private application.BL.Configuracion.FuncionGeneral ConG = new application.BL.Configuracion.FuncionGeneral();
        // GET: Registro/Default

        public ActionResult lista() {
            ViewBag.TitlePag = "Lista Paciente";
             return View();
        }
        public ActionResult Index()
        {
            ViewBag.TitlePag = "Registrar Paciente";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Paciente Model)
        {
            ViewBag.TitlePag = "Registrar Paciente";
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
                        return RedirectToAction("lista", "Paciente", new { area = "Registro" });
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


        public ActionResult editpac(string id) {
            ViewBag.TitlePag = "Editar Paciente";
            id  = ConG.Decrypt(id);
            ViewBag.Codigo = id;
            return View();
        }
    }
}