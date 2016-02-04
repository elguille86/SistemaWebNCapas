﻿using System;
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

        public IList<Entity.RespuestaUsuario> BL_ValidaAcceso(Entity.Usuario Model)
        {
            return this.UsuarioRespositorio.ValidaAcceso(Model);
        }
 

 
    }
}
