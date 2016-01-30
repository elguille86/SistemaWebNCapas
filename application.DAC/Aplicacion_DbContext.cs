using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace application.DAC
{
    public class Aplicacion_DbContext : DbContext
    {
        // Creamos el Constructor de Acceso a Datos
        public Aplicacion_DbContext()
            : base("BDSistema")
        { 
            
        }

    }
}
