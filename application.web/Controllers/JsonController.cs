using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using application.Entity;
 

namespace application.web.Controllers
{

    public class JsonController : Controller
    {
        private application.BL.IPacienteService PacienteService = new application.BL.PacienteService();
        private application.BL.IProductosService ProductoService = new application.BL.ProductosService();
        private application.BL.Configuracion.FuncionGeneral ConG = new application.BL.Configuracion.FuncionGeneral();
        //public class Estudiante
        //{
        //public int Id { get; set; }
        //public int Edad { get; set; }
        //public string Nombre { get; set; }
        //public int Identificacion { get; set; }
        //public string CiudadDeOrigen { get; set; }
        //}
        public ActionResult Json1(  )
        {
            IList<Entity.Paciente> Lista = PacienteService.BL_ListaPaciente( );

            for (int i = 0; i < Lista.Count; i++)
            {
                Lista[i].CodPac = this.ConG.Encriptar_V1(Lista[i].CodPac);
            }
 
            /*
            List<Estudiante> estudiantes = new List<Estudiante>();
            estudiantes.Add(new Estudiante {Id= 1 , Nombre = "Jaimito el cartero", CiudadDeOrigen = "Tangamandapio", Edad = 50, Identificacion = 123 });
            estudiantes.Add(new Estudiante { Id = 2 , Nombre = "El chapulin Colorado", CiudadDeOrigen = "Mexico D.F", Edad = 35, Identificacion = 555 });
            estudiantes.Add(new Estudiante { Id =  3 , Nombre = "Godines", CiudadDeOrigen = "Acapulco", Edad = 8, Identificacion = 789 });
            */
            //return Json(new { current = 1, rowCount = 10, total = Lista.Count(), rows = Lista, }, JsonRequestBehavior.DenyGet); 
            return Json(new { result = Lista }, JsonRequestBehavior.AllowGet); 
           // return Json(new { result = estudiantes }, JsonRequestBehavior.DenyGet); 
        }

        public JsonResult Jsoncliente(string term)
        {
            IList<Entity.JsonBasico> Lista = PacienteService.BL_JsonPaciente(term);           
            return Json(  Lista  , JsonRequestBehavior.AllowGet); 
        }
        public JsonResult JsonProducto(string term)
        {
            IList<Entity.JsonBasico2> Lista = ProductoService.BL_JsonProductos(term);
            return Json(Lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonCabComp(string term)
        {
            IList<Entity.GridCabComp> Lista = ProductoService.BL_ListaCabCompro();
            return Json(Lista, JsonRequestBehavior.AllowGet);
        }
    }
     
}