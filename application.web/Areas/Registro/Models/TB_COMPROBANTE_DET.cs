//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace application.web.Areas.Registro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_COMPROBANTE_DET
    {
        public int CodDet { get; set; }
        public string prod_descri { get; set; }
        public Nullable<int> cant_prod { get; set; }
        public Nullable<decimal> prod_precio { get; set; }
        public Nullable<int> cod_comp { get; set; }
        public string cod_prod { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
    
        public virtual TB_COMPROBANTE_CAB TB_COMPROBANTE_CAB { get; set; }
    }
}