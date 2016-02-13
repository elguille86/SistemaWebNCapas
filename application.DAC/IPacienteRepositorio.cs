using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using application.Entity;
namespace application.DAC
{
    public interface IPacienteRepositorio  
    {
        IList<RespuestaGlobal> DAC_InsertaPaciente(Paciente Model);
        IList<RespuestaGlobal> DAC_ActualizarPaciente(Paciente Model);
        
        IList<Paciente> DAC_ListaPaciente( );
        IList<EstadosTablas> DAC_ListaEstados();
        IList<Paciente> DAC_DetallePaciente(string Codigo);
    }
}
