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

    public class GridDetComp
    {
        public string produc { get; set; }
        public string Precio { get; set; } 
        public string Cant { get; set; } 
        public string SubTotal { get; set; } 
        public string CodComp { get; set; } 
    }

 

}
