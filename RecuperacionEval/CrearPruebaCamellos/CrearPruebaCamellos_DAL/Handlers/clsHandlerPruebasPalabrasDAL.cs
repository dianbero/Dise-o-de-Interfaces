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
         - void/int insertarPruebasPalabras(int idPrueba, int idPalabra) //O directamente pasa por parámetro objeto clsPruebaPalabra
         */

        /// <summary>
        /// Método que inserta un nuevo registro en la tabla CJ_PruebasPalabras de la BBDD
        /// </summary>
        /// <param name="idPrueba"></param>
        /// <param name="idPalabra"></param>
        public void insertarPruebasPalabras(int idPrueba, int idPalabra)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            //int filasAfectadas;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = idPrueba;
                command.Parameters.Add("@idPalabra", System.Data.SqlDbType.Time).Value = idPalabra;
                
                command.CommandText = "INSERT INTO CJ_PruebasPalabras(idPalabra, idPrueba) VALUES (@idPalabra, @idPrueba)";

                //Ejecuta la instrucción SQL
                command.ExecuteNonQuery();                               
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
        }
    }
}
