using System;
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


        public IList<Entity.JsonBasico2> DAC_JsonProducto(string Codigo)
        {
            IList<Entity.JsonBasico2> respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@busqueda", Codigo);
                respuesta = Dapper.SqlMapper.Query<Entity.JsonBasico2>(con, "SP_CONSULTAJSON_Producto", parametros, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return respuesta.ToList();
        }




        public IList<Entity.GridCabComp> DAC_ListaCabCompro()
        {
            IList<Entity.GridCabComp> respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                respuesta = Dapper.SqlMapper.Query<Entity.GridCabComp>(con, "SP_Lista_CabProducto", null, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return respuesta.ToList();
        }

        public IList<Entity.GridDetComp> DAC_ListaDetCompro()
        {
            IList<Entity.GridDetComp> respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                respuesta = Dapper.SqlMapper.Query<Entity.GridDetComp>(con, "SP_ListaDetProc", null, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return respuesta.ToList();
        }

        
    }
}
