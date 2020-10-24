using System.Collections.Generic;
using Entidad;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace Datos
{
    public class PersonaRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();

        public PersonaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (Identificacion,Nombre,Apellido,Sexo,Edad,Departamento,Ciudad,ValorApoyo,ModalidadApoyo,Fecha) 
                                        values (@Identificacion,@Nombre,@Apellido,@Sexo,@Edad,@Departamento,@Ciudad,@ValorApoyo,@ModalidadApoyo,@Fecha)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Departamento", persona.Departamento);
                command.Parameters.AddWithValue("@Ciudad", persona.Ciudad);
                command.Parameters.AddWithValue("@ValorApoyo", persona.ValorApoyo);
                command.Parameters.AddWithValue("@ModalidadApoyo", persona.ModalidadApoyo);
                command.Parameters.AddWithValue("@Fecha", persona.Fecha);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }

        public Persona BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }


        private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.Apellido = (string)dataReader["Apellido"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            persona.Departamento = (string)dataReader["Departamento"];
            persona.Ciudad = (string)dataReader["Ciudad"];
            persona.ValorApoyo = (decimal)dataReader["ValorApoyo"];
            persona.ModalidadApoyo = (string)dataReader["ModalidadApoyo"];
            persona.Fecha = (DateTime)dataReader["Fecha"];
            return persona;
        }

    }
}