﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace application.Entity
{
 
    public class  Paciente
    {
        [Required]
        [Display(Name = "Nombres")]
        public string usu_nombres { get; set; }


        [Required]
        [Display(Name = "Apellido Paterno")]
        public string usu_apepaterno { get; set; }
 
        [Required]
        [Display(Name = "Apelludo Materno")]
        public string usu_apematerno { get; set; }
        
 
        [Display(Name = "Nro DNI")]
        public string usu_numdoc { get; set; }


        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public string usu_fechanac { get; set; }
  
        [Display(Name = "Estado Paciente")]
        public string usu_estado { get; set; }
        public string CodPac { get; set; }
       

    }
    public class RespuestaGlobal
    {
        public string RespText { get; set; }
        public string RespEstado { get; set; }
        public string RespClass { get; set; }
    }

    public class JsonBasico
    {
        public string nomcompleto { get; set; }
        public string Codigo { get; set; }
 
    }
    public class JsonBasico2
    {
        public string nomcompleto { get; set; }
        public string Codigo { get; set; }
        public decimal precio { get; set; }
 
    }
 
}
