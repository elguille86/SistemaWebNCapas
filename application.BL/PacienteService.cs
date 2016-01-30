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
    }
}
