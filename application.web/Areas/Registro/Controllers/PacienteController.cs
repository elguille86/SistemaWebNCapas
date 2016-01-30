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

                    if (respuesta[0].RespEstado == "true")
                    {
                        return View(Model);
                    }
                    else {
                        ViewBag.mensaje = respuesta[0].RespText;
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