using application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.BL
{
    public interface IProductosService
    {

        IList<JsonBasico> BL_JsonProductos(string Codigo);
        
        
    }
}
