using application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Configuration;

namespace application.BL
{
    
    public interface IUsuariosService
    {
        //string HASKEY = ConfigurationManager.AppSettings["HASH_KEY"].ToString();
        IList<RespuestaUsuario> BL_ValidaAcceso(Usuario Model);

        //IList<RespuestaGlobal> BL_ChangePwd(string usuario, string pwd);
    }
}
