using application.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.BL
{
    public interface IPacienteService
    {
        IList<RespuestaGlobal> BL_InsertaPaciente(Paciente Model);
        IList<RespuestaGlobal> BL_ActualizarPaciente(Paciente Model);
        IList<Paciente> BL_ListaPaciente();
        IList<EstadosTablas> BL_ListaEstados();
        IList<Paciente> BL_DetallePaciente(string Codigo);
        IList<JsonBasico> BL_JsonPaciente(string Codigo);
        
        
    }
}
