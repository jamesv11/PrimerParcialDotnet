
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using emergencia_covid.Models;

namespace WebPulsaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;
        public IConfiguration Configuration { get; }
        public PersonaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _personaService = new PersonaService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public ActionResult<IEnumerable<PersonaViewModel>> Gets()
        {
            var response = _personaService.ConsultarTodos(); 
            if(response.Error){
           
                return BadRequest(response.Mensaje);
            }
            var personas = response.Personas.Select(p => new PersonaViewModel(p));
            return Ok(personas);
        }

        
        // GET: api/Persona/5
        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> Get(string identificacion)
        {
            var response = _personaService.BuscarxIdentificacion(identificacion);
            if (response.Persona == null) return NotFound();
            var personaViewModel = new PersonaViewModel(response.Persona);
            return Ok(personaViewModel);
        }
        // POST: api/Persona
        
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }
        /*
        // DELETE: api/Persona/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _personaService.Eliminar(identificacion);
            return Ok(mensaje);
        }
        */
        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                Nombre = personaInput.Nombre,
                Apellido = personaInput.Apellido,
                Sexo = personaInput.Sexo,
                Edad = personaInput.Edad,
                Departamento = personaInput.Departamento,
                Ciudad = personaInput.Ciudad,
                ValorApoyo = personaInput.ValorApoyo,
                ModalidadApoyo = personaInput.ModalidadApoyo,
                Fecha = personaInput.Fecha
                
            };
            return persona;
        }
        /*
        Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Apellido =  persona.Apellido;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
            ValorApoyo = persona.ValorApoyo;
            ModalidadApoyo = persona.ModalidadApoyo;
            Fecha = persona.Fecha;    
        */
        // PUT: api/Persona/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}