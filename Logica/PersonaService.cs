using System;
using System.Collections.Generic;
using Datos;
using Entidad;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PersonaService
    {
        private readonly EmergenciaContext _context;
        public PersonaService(EmergenciaContext context)
        {
            _context=context;
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                var personaBuscada = _context.Personas.Find(persona.Identificacion);
                if(personaBuscada != null)
                {
                    return new GuardarPersonaResponse("Error la persona se encuentra registrada");
                }
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }
        public ConsultarPersonaResponse ConsultarTodos()
        {
            try
            {
                var personas = _context.Personas.Include(a => a.Apoyo).ToList();
                return new ConsultarPersonaResponse(personas);

            }
            catch (Exception e)
            {
                return new ConsultarPersonaResponse($"error de aplicacion: {e.Message}");
            }

        }


    }
    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
    public class ConsultarPersonaResponse
    {
        public ConsultarPersonaResponse(List<Persona> personas)
        {
            Error = false;
            Personas = personas;
        }
        public ConsultarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public List<Persona> Personas { get; set; }
    }
     public class BuscarPersonaResponse 
    {
        public BuscarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public BuscarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}


