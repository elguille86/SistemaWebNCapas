using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace application.DAC
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private string ConnectionString = null;
        public UsuariosRepositorio() {
            this.ConnectionString =
                ConfigurationManager.ConnectionStrings["BDSistema"].ConnectionString;
        }


        public IList<Entity.RespuestaUsuario> ValidaAcceso(Entity.Usuario Model)
        {
            IList<Entity.RespuestaUsuario> respuesta = null;
  
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@login_user", Model.usuario);
                parametros.Add("@pass_user", Model.pass);
               
                //respuesta = Dapper.SqlMapper.Execute(con, "SP_USUARIO_VALIDAD", parametros, commandType: CommandType.StoredProcedure);
                respuesta = Dapper.SqlMapper.Query<Entity.RespuestaUsuario>(con, "SP_USUARIO_VALIDAD", parametros, commandType: CommandType.StoredProcedure).ToList();
                //List<Entity.RespuestaBD>  respuesta = con.Query<Entity.RespuestaBD>("SP_USUARIO_VALIDAD",parametros, commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
                
            }
            return respuesta.ToList();
        }
    }
}
