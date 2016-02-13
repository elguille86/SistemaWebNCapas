using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using application.Entity;
namespace application.DAC
{
    public interface IProductosRepositorio  
    {

        IList<JsonBasico2> DAC_JsonProducto(string Codigo);
        
    }
}
