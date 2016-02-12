using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.BL.Configuracion
{
    public interface IFuncionGeneral
    {
        string Encrypt(string clearText);
        string Decrypt(string clearText);
        
    }
}
