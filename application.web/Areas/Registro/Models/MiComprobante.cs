using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace application.web.Areas.Registro.Models
{
    public class MiComprobante
    {


        public string estab_serie { get; set; }
        public Nullable<System.DateTime> cabe_fecha { get; set; }
        public string cabe_ticket { get; set; }
        public Nullable<System.DateTime> cabe_hora { get; set; }
        public string cod_estab { get; set; }
        public int cod_comp { get; set; }
        public string usu_docid_codigo { get; set; }
        public string login_user { get; set; }
        public string Nro_Fua { get; set; }
        public Nullable<decimal> Mont_Total { get; set; }
        public virtual ICollection<TB_COMPROBANTE_DET> TB_COMPROBANTE_DET { get; set; }

    }
}