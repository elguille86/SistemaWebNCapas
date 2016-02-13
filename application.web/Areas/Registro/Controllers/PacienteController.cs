using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.Entity;
using application.web.Models;
namespace application.web.Areas.Registro.Controllers
{
   [Authorize]
    public class PacienteController : Controller
    {
        private application.BL.IPacienteService PacienteService = new application.BL.PacienteService();
        private application.BL.Configuracion.FuncionGeneral ConG = new application.BL.Configuracion.FuncionGeneral();
       // private BDGRPNETEntities db = new BDGRPNETEntities();
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
            id = ConG.DesEncriptar_V1(id);
            ViewBag.Codigo = id;
 
            var Model = this.PacienteService.BL_DetallePaciente(id);
            
           // Model[0].usu_fechanac = Model[0].usu_fechanac.ToString("yyyy-MM-dd");;
          
            //Usando View Model
            //ViewBag.usu_estado = new SelectList(db.Tv_TipoEstado, "mvalor", "mtexto");
            ViewBag.usu_estado = new SelectList(PacienteService.BL_ListaEstados(), "mvalor", "mtexto", Model[0].usu_estado);          
            if (Model.Count() > 0)
            {
                return View(Model[0]);
            }
            else {
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editpac(Paciente modelp)
        {

            ViewBag.TitlePag = "Editar Paciente";
            if (ModelState.IsValid)
            {
                IList<RespuestaGlobal> respuesta = this.PacienteService.BL_ActualizarPaciente(modelp);

                if (respuesta.Count() > 0)
                {
                    string texto = respuesta[0].RespText;
                    string cls = respuesta[0].RespClass;
                    string respue = ("<div class='" + cls + "'>" + texto + "</div>");
                    TempData["mensajeserver"] = respue;
                    if (respuesta[0].RespEstado == "true")
                    {                    
                        return RedirectToAction("lista", "Paciente", new { area = "Registro" });
                    }
                    else
                    {
                        return View(modelp);
                    }

                }
                else
                {
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