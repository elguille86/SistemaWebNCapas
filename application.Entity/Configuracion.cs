using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using System.ComponentModel.DataAnnotations;
 
namespace application.Entity
{
 
    public class EstadosTablas
    {
        public string mvalor { get; set; }
        public string mTexto { get; set; } 
    }

    public class GridCabComp
    {
        public string Cliente { get; set; }
        public string Fecha { get; set; } 
        public string Monto { get; set; } 
        public string CodComp { get; set; } 
    }

 

}
