using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using application.Entity;
namespace application.DAC
{
    public interface IUsuariosRepositorio  
    {
        IList<RespuestaUsuario> ValidaAcceso(Usuario Model);
        //IList<RespuestaGlobal> DAC_ChangePwd(string usuario, string pwd);
    }
}
