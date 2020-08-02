using PuntuarCombateMarvel_DAL.Connections;
using PuntuarCombateMarvelUWP_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_DAL.Handlers
{
    public class clsHandlerLuchadoresCombatesDAL
    {
        /*TODO:
         * int insertarLuchadorCombate(clsLuchadorCombate nuevoLuchadorCombate)
         * int actualizarPuntuacionLuchadorCombate(clsLuchadorcombate luchadorConNuevaPuntuacion)
         */

        /// <summary>
        /// Método que inserta un nuevo registro en tabla SH_LuchadoresCombates
        /// </summary>
        /// <param name="nuevoLuchadorCombate">clsLuchadorCombate, con los datos del objeto a insertar</param>
        /// <returns>int filasAfectadas, con el número de filas afectadas por la sentencia</returns>
        public int insertarLuchadorCombate(clsLuchadorCombate nuevoLuchadorCombate)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            int filasAfectadas;
            //int idCombate = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@idCombate", System.Data.SqlDbType.Int).Value = nuevoLuchadorCombate.IdCombate; 
                command.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = nuevoLuchadorCombate.IdLuchador; 
                command.Parameters.Add("@puntuacionLuchador", System.Data.SqlDbType.Int).Value = nuevoLuchadorCombate.PuntuacionLuchador;


                command.CommandText = "INSERT INTO SH_LuchadoresCombates(idCombate, idLuchador, puntuacionLuchador) VALUES(@idCombate, @idLuchador, @puntuacionLuchador)";

                //Ejecuta la instrucción SQL
                filasAfectadas = command.ExecuteNonQuery();
                //idCombate = (int)command.ExecuteScalar();


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

        /// <summary>
        /// Método que actualiza la puntuación de un lucchador en un combate
        /// </summary>
        /// <param name="nuevaPuntuacionLuchadorCombate">clsLuchadorCombate con los datos para actualizar el registro con la nueva puntuación</param>
        /// <returns>int filasAfectadas, con número de filas afectadas por la ejecución</returns>
        public int actualizarPuntuacionLuchadorCombate(clsLuchadorCombate nuevaPuntuacionLuchadorCombate)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            int filasAfectadas;
            //int idCombate = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@idCombate", System.Data.SqlDbType.Int).Value = nuevaPuntuacionLuchadorCombate.IdCombate;
                command.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = nuevaPuntuacionLuchadorCombate.IdLuchador;
                command.Parameters.Add("@puntuacionLuchador", System.Data.SqlDbType.Int).Value = nuevaPuntuacionLuchadorCombate.PuntuacionLuchador; //Nueva puntuación a añadir


                command.CommandText = "UPDATE SH_LuchadoresCombates SET puntuacionLuchador = puntuacionLuchador + @puntuacionLuchador WHERE idLuchador = @idLuchador AND idCombate = @idCombate";

                //Ejecuta la instrucción SQL
                filasAfectadas = command.ExecuteNonQuery();
                //idCombate = (int)command.ExecuteScalar();


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
