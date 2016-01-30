using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace application.Entity
{
    public class Usuario
    {
        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get ; set; }
        [Required]
        [Display(Name="Contraseña")]
        [DataType(DataType.Password)]
        public string pass { get; set; }
    }
    public class RespuestaUsuario
    {
        public string ResUsuario { get; set; }
        public string ResPass { get; set; }
        public string RepDNI { get; set; }
        public string RedRol { get; set; }
 
    }
    
 
}
