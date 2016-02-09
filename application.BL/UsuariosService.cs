using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using application.Entity;
using System.Data;

namespace application.BL
{
    public class UsuariosService : IUsuariosService
    {
        
        private DAC.IUsuariosRepositorio UsuarioRespositorio = new DAC.UsuariosRepositorio();
        private Configuracion.FuncionGeneral FunGen = new Configuracion.FuncionGeneral();
        public IList<Entity.RespuestaUsuario> BL_ValidaAcceso(Entity.Usuario Model)
        {
            return this.UsuarioRespositorio.ValidaAcceso(Model);
        }
 
        public IList<RespuestaGlobal> BL_ChangePwd(string usuario, string pwd)
        {
            pwd = FunGen.Encrypt(pwd);
            return this.UsuarioRespositorio.DAC_ChangePwd(usuario, pwd);
        }
       
    }
}
