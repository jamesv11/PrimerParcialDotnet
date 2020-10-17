﻿using System;
using System.Collections.Generic;
using Datos;
using Entidad;

namespace Logica
{
    public class PersonaService
    {
        private readonly ConnectionManager _conexion;
        private readonly PersonaRepository _repositorio;



        public PersonaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new PersonaRepository(_conexion);
        }

        public GuardarPersonaResponse Guardar(Persona persona)
        {
            try
            {
                _conexion.Open();
                _repositorio.Guardar(persona);
                _conexion.Close();
                return new GuardarPersonaResponse(persona);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public ConsultarPersonaResponse ConsultarTodos()
        {
            try
            {
                _conexion.Open();
                List<Persona> personas = _repositorio.ConsultarTodos();
                _conexion.Close();
                return new ConsultarPersonaResponse(personas);

            }
            catch (Exception e)
            {
                return new ConsultarPersonaResponse($"error de aplicacion: {e.Message}");
            }

        }
        public BuscarPersonaResponse BuscarxIdentificacion(string identificacion)
        {
            try{
                  _conexion.Open();
                  Persona persona = _repositorio.BuscarPorIdentificacion(identificacion);
                  _conexion.Close();
                  return new BuscarPersonaResponse(persona);
            }
            catch(Exception e){

                    return new BuscarPersonaResponse($"error de aplicacion: {e.Message}");

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
