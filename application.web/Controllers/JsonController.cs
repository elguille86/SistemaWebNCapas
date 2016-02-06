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
        //public class Estudiante
        //{
        //public int Id { get; set; }
        //public int Edad { get; set; }
        //public string Nombre { get; set; }
        //public int Identificacion { get; set; }
        //public string CiudadDeOrigen { get; set; }
        //}
        public ActionResult Json1(string searchPhrase )
        {
            IList<Entity.Paciente> Lista = PacienteService.BL_ListaPaciente(searchPhrase);
                
            /*
            List<Estudiante> estudiantes = new List<Estudiante>();
            estudiantes.Add(new Estudiante {Id= 1 , Nombre = "Jaimito el cartero", CiudadDeOrigen = "Tangamandapio", Edad = 50, Identificacion = 123 });
            estudiantes.Add(new Estudiante { Id = 2 , Nombre = "El chapulin Colorado", CiudadDeOrigen = "Mexico D.F", Edad = 35, Identificacion = 555 });
            estudiantes.Add(new Estudiante { Id =  3 , Nombre = "Godines", CiudadDeOrigen = "Acapulco", Edad = 8, Identificacion = 789 });
            */
            return Json(new { current = 1, rowCount = 10, total = Lista.Count(), rows = Lista, }, JsonRequestBehavior.DenyGet); 
           // return Json(new { result = estudiantes }, JsonRequestBehavior.DenyGet); 
        }
    }
     
}