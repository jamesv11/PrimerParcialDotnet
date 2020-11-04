using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Apoyo
    {
        [Key]
        public int ApoyoId {get; set;}
        public int ValorApoyo  { get; set; } 
        [StringLength(15)]
        public string ModalidadApoyo { get; set; }
        public DateTime Fecha { get; set; }  
    }
}