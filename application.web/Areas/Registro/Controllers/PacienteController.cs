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
             
            Paciente Model2 = new Paciente();

            var Model = this.PacienteService.BL_DetallePaciente(id);
            Model2.CodPac = Model[0].CodPac;
            Model2.usu_apematerno = Model[0].usu_apematerno;
            Model2.usu_apepaterno = Model[0].usu_apepaterno;
            //Usando View Model
            //ViewBag.usu_estado = new SelectList(db.Tv_TipoEstado, "mvalor", "mtexto");
            ViewBag.usu_estado = new SelectList(PacienteService.BL_ListaEstados(), "mvalor", "mtexto");
            //ViewBag.usu_estado = new SelectList(TablaEstados, "valor", "Texto");

            return View(Model[0]);
        }


        //public IEnumerable<EstadosTablas> TablaEstados()
        //{

        //    IEnumerable<EstadosTablas> Estados = new IEnumerable<EstadosTablas>();
        //    Estados.Add(new EstadosTablas { valor = "1", Texto = "HABILITADO" });
        //    Estados.Add(new EstadosTablas { valor = "0", Texto = "DESHABILITADO" });

        //    return Estados;
        //}



    }
}