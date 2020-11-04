using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Persona
    {
        [Key]

        [StringLength(10)]
        public String Identificacion { get; set; }
        [StringLength(15)]
        public String Nombre { get; set; }
        [StringLength(20)]   
        public String Apellido { get; set; }
        [StringLength(2)]  
        public string Sexo { get; set; }
        public int Edad { get; set; }
        [StringLength(20)]  
        public String Departamento { get; set; }
        [StringLength(20)]  
        public String Ciudad { get; set; }     

        public int ApoyoId {get; set;}
        public virtual Apoyo Apoyo {get; set;}
          
    }
}