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
        IList<Paciente> DAC_ListaPaciente(string busqueda);
    }
}
