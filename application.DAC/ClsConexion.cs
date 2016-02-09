using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
 
using System.Data;
namespace application.DAC
{
    public class ClsConexion
    {
        public String CadenaCN()
        {
            return ConfigurationManager.ConnectionStrings["BDGRPNET"].ConnectionString;
        }
    }
}
