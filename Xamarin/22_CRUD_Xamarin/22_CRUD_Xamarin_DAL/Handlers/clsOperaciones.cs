
//using _17_CRUD_Personas_UWP_DAL.Connections;
//using _17_CRUD_Personas_UWP_Entities;
//using _22_CRUD_Xamarin_Entitites;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Text;

//namespace _17_CRUD_Personas_UWP_DAL.Manejadoras
//{
//    public class clsOperaciones
//    {
//        clsMyConnection objConexion = new clsMyConnection();
//        SqlConnection conexion;
//        SqlCommand comando = new SqlCommand();

//        /// <summary>
//        /// Método que borra una persona según un id pasado por parámetro
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public int Borrar(int id)
//        {
//            //comando = new SqlCommand();
//            conexion = objConexion.getConnection(); //Abro conexion
//            comando.Connection = conexion; //Paso conexión al comando
//            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
//            comando.CommandText = "DELETE FROM PD_Personas WHERE IdPersona = @id";
//            int resultado = 0;

//            resultado = comando.ExecuteNonQuery(); //Ejecuta la sentencia y devuelve el número de filas afectadas

//            return resultado;
//        }

//        /// <summary>
//        /// Método que pasándole una objeto persona por parámetro, la inserta en la base de datos
//        /// </summary>
//        /// <param name="persona"></param>
//        /// <returns></returns>
//        public int Create(clsPersona persona)
//        {
//            //comando = new SqlCommand();
            
//            conexion = objConexion.getConnection();
//            comando.Connection = conexion;
//            int resultado;
            
//            comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
//            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
//            comando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
//            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
//            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
//            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
//            comando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
            
//            comando.CommandText = "INSERT INTO PD_Personas VALUES (@nombre, @apellido, @idDepartamento, @fechaNacimiento, @telefono, @foto)";

//            resultado = comando.ExecuteNonQuery();
            
//            return resultado;
//        }

//        /// <summary>
//        /// Método que recibe objeto persona y la inserta en la base de datos
//        /// </summary>
//        /// <param name="persona"></param>
//        /// <returns></returns>   
//        public int Edit(clsPersona persona) //Recibe una persona con los datos a modificar
//        {
//            conexion = objConexion.getConnection();
//            comando.Connection = conexion;

//            comando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = persona.Id;
//            comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
//            comando.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
//            comando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;
//            comando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
//            comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
//            comando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
                        
//            int filasAfectadas = 0;
//            string nombre;
//            string apellido;
//            string idDepartamento; 
//            string fechaNacimiento; 
//            string telefono;
//            string foto;


//            if(persona.Nombre != null)
//            {
//                nombre = "@nombre";
//            }
//            else
//            {
//                nombre = "NULL";
//            }

//            if (persona.Apellido != null)
//            {
//                apellido = "@apellido";
//            }
//            else
//            {
//                apellido = "NULL";
//            }
            
//            if(persona.FechaNacimiento != null)
//            {
//                fechaNacimiento = "@fechaNacimiento";
//            }
//            else
//            {
//                fechaNacimiento = "NULL";
//            }

//            if (persona.Telefono != null)
//            {
//                telefono = "@telefono";
//            }
//            else
//            {
//                telefono = "NULL";
//            }
//            if (persona.Foto != null)
//            {
//                foto = "@foto";
//            }
//            else
//            {
//                foto = "NULL";
//            }

//            //Apellido no se comprueba si es nulo, porque será un dropdown y nunca podrá establecerse a nulo (a parte, no sé cómo comprobar que el idDepartamento no sea nulo, porque da error)
//            //comando.CommandText = $"UPDATE PD_Personas SET NombrePersona = {nombre}, ApellidosPersona = {apellido}, IDDepartamento = @idDepartamento, FechaNacimientoPersona = {fechaNacimiento}, TelefonoPersona = {telefono}, FotoPersona = {foto}";
//            comando.CommandText = $"UPDATE PD_Personas SET NombrePersona = {nombre}, ApellidosPersona = {apellido}, IDDepartamento = @idDepartamento, FechaNacimientoPersona = {fechaNacimiento}, TelefonoPersona = {telefono}, FotoPersona = {foto} WHERE idPersona = @idPersona";

//            //comando.CommandText = $"UPDATE PD_Personas SET NombrePersona = {nombre}, ApellidosPersona = {apellido}, FechaNacimientoPersona = {fechaNacimiento}, TelefonoPersona = {telefono}, FotoPersona = {foto}";

//            filasAfectadas = comando.ExecuteNonQuery();

//            return filasAfectadas;            
//        }

//        //Este método no lo debería necesitar
//        //public int EditDepartamentoPersonaPorId(int idDepartamentoACambiar, clsPersona objPersona)
//        //{
//        //    //update PD_Personas set idDepartamento = ... where idDepartamento = ... 
//        //    conexion = objConexion.getConnection();
//        //    comando.Connection = conexion;

//        //    comando.Parameters.Add("@idDepartamentoACambiar", System.Data.SqlDbType.Int).Value = idDepartamentoACambiar;
//        //    comando.Parameters.Add("@nombrePersona", System.Data.SqlDbType.VarChar).Value = objPersona.Nombre;

//        //    comando.CommandText = "UPDATE PD_Personas SET IDDepartamento = @idDepartamentoACambiar WHERE IDDepartamento = 1 AND NombrePersona = @nombrePersona";

//        //    int resultadoFilasAfectadas = comando.ExecuteNonQuery();

//        //    return resultadoFilasAfectadas;            
//        //}
//    }
//}
