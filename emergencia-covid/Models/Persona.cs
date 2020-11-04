using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emergencia_covid.Models
{
     public class PersonaInputModel
    {
        public String Identificacion { get; set; }
        public String Nombre { get; set; }   
        public String Apellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public String Departamento { get; set; }
        public String Ciudad { get; set; } 
        public virtual Apoyo Apoyo {get; set;}    
    }

    public class PersonaViewModel : PersonaInputModel
    {
         
        public PersonaViewModel()
        {
            
        }
        public PersonaViewModel(Persona persona)
        {        
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Apellido =  persona.Apellido;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            Apoyo = persona.Apoyo;
            IdApoyo = persona.ApoyoId;

        }

        public int IdApoyo { get; set; }
       
    }
}