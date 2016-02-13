using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using application.Entity;

namespace application.BL
{
    public class PacienteService :IPacienteService
    {

        private DAC.IPacienteRepositorio PacienteRespositorio = new DAC.PacienteRepositorio();
        public IList<RespuestaGlobal> BL_InsertaPaciente(Paciente Model)
        {
            return this.PacienteRespositorio.DAC_InsertaPaciente(Model);
        }


        public IList<Paciente> BL_ListaPaciente()
        {
            return this.PacienteRespositorio.DAC_ListaPaciente();
        }


        public IList<EstadosTablas> BL_ListaEstados()
        {
            return this.PacienteRespositorio.DAC_ListaEstados();
        }


        public IList<Paciente> BL_DetallePaciente(string Codigo)
        {
            return this.PacienteRespositorio.DAC_DetallePaciente(Codigo);
        }


        public IList<RespuestaGlobal> BL_ActualizarPaciente(Paciente Model)
        {
            return this.PacienteRespositorio.DAC_ActualizarPaciente(Model);
        }
    }
}
