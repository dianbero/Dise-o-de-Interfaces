using CrearPruebaCamellos_DAL.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_DAL.Handlers
{
    public class clsHandlerPruebasPalabrasDAL
    {
        /*TODO:
         - void insertarPruebasPalabras(int idPrueba, int idPalabra) 
         */

        /// <summary>
        /// Método que inserta un nuevo registro en la tabla CJ_PruebasPalabras de la BBDD
        /// </summary>
        /// <param name="idPrueba">int con el id de la nueva prueba</param>
        /// <param name="idPalabra">int con el id de la palabra a introducir</param>
        /// <returns>int filasAfectadas, indicando el número de registros afectados</returns>
        public int insertarPruebasPalabras(int idPrueba, int idPalabra)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            int filasAfectadas;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = idPrueba;
                command.Parameters.Add("@idPalabra", System.Data.SqlDbType.Int).Value = idPalabra;
                
                command.CommandText = "INSERT INTO CJ_PruebasPalabras(idPalabra, idPrueba) VALUES (@idPalabra, @idPrueba)";

                //Ejecuta la instrucción SQL
                filasAfectadas = command.ExecuteNonQuery();                               
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

            return filasAfectadas;
        }
    }
}
