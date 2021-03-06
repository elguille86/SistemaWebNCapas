﻿using System;
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
        private string ConnectionString = null; ClsConexion ClsCone ;
        public UsuariosRepositorio()
        {
            //this.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["BDSistema"].ConnectionString;
            ClsCone = new ClsConexion();
            this.ConnectionString = ClsCone.CadenaCN().ToString();
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


        public IList<Entity.RespuestaGlobal> DAC_ChangePwd(string usuario, string pwd)
        {
            IList<Entity.RespuestaGlobal> respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@login_user", usuario);
                parametros.Add("@pass_user", pwd);
                //respuesta = Dapper.SqlMapper.Execute(con, "SP_USUARIO_VALIDAD", parametros, commandType: CommandType.StoredProcedure);
                respuesta = Dapper.SqlMapper.Query<Entity.RespuestaGlobal>(con, "SP_ACTUALIZAR_PWD", parametros, commandType: CommandType.StoredProcedure).ToList();
                //List<Entity.RespuestaBD>  respuesta = con.Query<Entity.RespuestaBD>("SP_USUARIO_VALIDAD",parametros, commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }
            return respuesta.ToList();
        }

    }
}
