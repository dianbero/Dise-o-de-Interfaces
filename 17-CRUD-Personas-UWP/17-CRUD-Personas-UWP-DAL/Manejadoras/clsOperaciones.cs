
using _17_CRUD_Personas_UWP_DAL.Connections;
using _17_CRUD_Personas_UWP_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _17_CRUD_Personas_UWP_DAL.Manejadoras
{
    public class clsOperaciones
    {
        clsMyConnection objConexion = new clsMyConnection();
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Método que borra una persona según un id pasado por parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Borrar(int id)
        {
            //comando = new SqlCommand();
            conexion = objConexion.getConnection(); //Abro conexion
            comando.Connection = conexion; //Paso conexión al comando
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            comando.CommandText = "DELETE FROM PD_Personas WHERE IdPersona = @id";
            int resultado = 0;

            resultado = comando.ExecuteNonQuery(); //Ejecuta la sentencia y devuelve el número de filas afectadas

            return resultado;
        }

        /// <summary>
        /// Método que pasándole una objeto persona por parámetro, la inserta en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int Create(clsPersona persona)
        {
            //comando = new SqlCommand();
            
            conexion = objConexion.getConnection();
            comando.Connection = conexion;
            int resultado;
            
            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            comando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            comando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
            
            comando.CommandText = "INSERT INTO PD_Personas VALUES (@nombre, @apellido, @idDepartamento, @fechaNacimiento, @telefono, @foto)";

            resultado = comando.ExecuteNonQuery();
            
            return resultado;
        }

        /// <summary>
        /// Método que recibe objeto persona y la inserta en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>   
        public int Edit(clsPersona persona) //Recibe una persona con los datos a modificar
        {
            conexion = objConexion.getConnection();
            comando.Connection = conexion;

            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            comando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            comando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                        
            int filasAfectadas = 0;
            string nombre = null;
            string apellido = null;
            string idDepartamento = null; 
            string fechaNacimiento = null; 
            string telefono = null;
            string foto = null;


            if(persona.Nombre != null)
            {
                nombre = "@nombre";
            }
            else
            {
                nombre = null;
            }

            if (persona.Apellido != null)
            {
                apellido = "@apellido";
            }
            else
            {
                apellido = null;
            }

            if(persona.FechaNacimiento != null)
            {
                fechaNacimiento = "@fechaNacimiento";
            }
            else
            {
                fechaNacimiento = null;
            }
            if (persona.Telefono != null)
            {
                telefono = "@telefono";
            }
            else
            {
                telefono = null;
            }
            if (foto != null)
            {
                foto = "@foto";
            }
            else
            {
                foto = null;
            }

            comando.CommandText = $"UPDATE PD_Personas SET NombrePersona = {nombre}, ApellidosPersona = {apellido}, IDDepartamento = {idDepartamento}, FechaNacimientoPersona = {fechaNacimiento}, TelefonoPersona = {telefono}, FotoPersona = {foto}";

            filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;            
        }


    }
}
