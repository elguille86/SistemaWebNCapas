using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Data.Entity;


namespace application.DAC
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private string ConnectionString = null;
        public PacienteRepositorio()
        {
            this.ConnectionString =
                ConfigurationManager.ConnectionStrings["BDSistema"].ConnectionString;
        }
        public IList<Entity.RespuestaGlobal> DAC_InsertaPaciente(Entity.Paciente Model)
        {
            IList<Entity.RespuestaGlobal> respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("@usu_numdoc", Model.usu_numdoc);
                parametros.Add("@usu_apepaterno", Model.usu_apematerno);
                parametros.Add("@usu_apematerno", Model.usu_apematerno);
                parametros.Add("@usu_nombres", Model.usu_nombres);
                parametros.Add("@usu_fechanac", Model.usu_fechanac);
                respuesta = Dapper.SqlMapper.Query<Entity.RespuestaGlobal>(con, "SP_INSERTAPACIENTE", parametros, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
            }
            return respuesta.ToList();
        }
 
        public IList<Entity.Paciente> DAC_ListaPaciente()
        {                
            IList<Entity.Paciente>  respuesta = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var parametros = new DynamicParameters();

                respuesta = Dapper.SqlMapper.Query<Entity.Paciente>(con, "SP_LISTA_PACIENTE", null, commandType: CommandType.StoredProcedure).ToList();

                con.Close();
            }
            return respuesta.ToList();
        }
    }
}
