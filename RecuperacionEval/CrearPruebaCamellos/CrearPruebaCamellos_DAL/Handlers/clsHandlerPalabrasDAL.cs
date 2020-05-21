using CrearPruebaCamellos_DAL.Connections;
using CrearPruebaCamellos_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_DAL.Handlers
{
    public class clsHandlerPalabrasDAL
    {
        /*TODO:
         - int checkExistePalabra(string palabra)
         - clsPalabra getPalabraExistente(string palabra)
         - int insertarPalabra(clsPalabra nuevaPalabra)
         */

        /// <summary>
        /// Método que comprueba si existe una palabra 
        /// </summary>
        /// <param name="palabra">string con la palabra que se quiere comprobar</param>
        /// <returns>int filasAfectadas con el número de registros obtenidos por la ejecución</returns>
        public int checkExistePalabra(string palabra)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            Int32 filasAfectadas = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@palabra", System.Data.SqlDbType.VarChar).Value = palabra;
                command.CommandText = "SELECT COUNT(*) FROM CJ_Palabras WHERE palabra = @palabra";

                filasAfectadas = (Int32)command.ExecuteScalar();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    objConnection.closeConnection(ref connection);
                }
            }

            //Este doble casteo lo hago porque en la documentación lo he visto así, pero no lo entiendo, hasta el VS te dice que la conversión es redundante
            return (int)filasAfectadas;
        }

        /// <summary>
        /// Método que obtiene los datos de una palabra ya existente en la BBDD.
        /// </summary>
        /// <param name="palabra">string con la palabra que se desea obtener</param>
        /// <returns>clsPalabra objPalabra, con todos los datos de la palabra obtenida de la BBDD</returns>
        public clsPalabra getPalabraExistente(string palabra)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsPalabra objPalabra = null;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@palabra", System.Data.SqlDbType.VarChar).Value = palabra;
                command.CommandText = "SELECT * FROM CJ_Palabras WHERE palabra = @palabra";
                
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        objPalabra.IdPalabra = (int)reader["idPalabra"];
                        objPalabra.Palabra = (string)reader["palabra"];
                        objPalabra.Dificultad = (byte)reader["idPalabra"];                                                
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    objConnection.closeConnection(ref connection);
                }
            }

            return objPalabra;
        }

        /// <summary>
        /// Método que inserta una nueva palabra en la BBDD
        /// </summary>
        /// <param name="nuevaPalabra">clsPalabra con los datos de la nueva palabra</param>
        /// <returns>int idPalabra, de la palabra insertada en la BBDD</returns>
        public int insertarPalabra(clsPalabra nuevaPalabra)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            //int filasAfectadas;
            Int32 idPalabra = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@palabra", System.Data.SqlDbType.VarChar).Value = nuevaPalabra.Palabra;
                command.Parameters.Add("@dificultad", System.Data.SqlDbType.VarChar).Value = nuevaPalabra.Dificultad;


                /*Me llama la atención meter dos sentencias SQL a la vez en el CommandText, pero en la documentación de microsoft lo hacen así, con la sentencia de inserción primero y después
                 el select, y obtiene el idJugador únicamente que era mi intención, porque es lo único que quiero pasarle a la siguiente vista*/
                command.CommandText = "INSERT INTO CJ_Palabras(palabra, dificultad) VALUES (@palabra, @dificultad) " +
                    "SELECT * FROM CJ_Palabras WHERE palabra = @palabra"; //Pilla sólo la primera columna y de la primera fila de las afectadas por la sentencia, en mi caso el idPalabra

                //Ejecuta la instrucción SQL
                //filasAfectadas = command.ExecuteNonQuery();      
                idPalabra = (Int32)command.ExecuteScalar();


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    objConnection.closeConnection(ref connection);
                }
            }


            return (int)idPalabra;
        }

    }
}
