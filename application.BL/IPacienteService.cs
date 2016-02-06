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
        IList<Paciente> BL_ListaPaciente(string busqueda);
    }
}
