﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
//using System.Data.Entity;


namespace application.DAC
{
    public class ProductosRepositorio : IProductosRepositorio
    {
        private string ConnectionString = null;ClsConexion ClsCone ;
        public ProductosRepositorio()
        {
            ClsCone = new ClsConexion();
            this.ConnectionString = ClsCone.CadenaCN().ToString();
                //ConfigurationManager.ConnectionStrings["BDSistema"].ConnectionString;
        }

  
        public IList<Entity.JsonBasico> DAC_JsonProducto(string Codigo)
        {
            IList<Entity.JsonBasico> respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@busqueda", Codigo);
                respuesta = Dapper.SqlMapper.Query<Entity.JsonBasico>(con, "SP_CONSULTAJSON_Producto", parametros, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return respuesta.ToList();
        }

 
    }
}
