using PuntuarCombateMarvel_DAL.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_DAL.Lists
{
    public class clsListadosCombatesDAL
    {
        /*TODO:
         * int getCombate(int idLuchador1, int idLuchador2, DateTime fechaCombate): devuelve del idCombate, no el objeto entero
         * */

        /// <summary>
        /// Método que obtiene el id de un combate según los luchadores que participan y la fecha 
        /// </summary>
        /// <param name="idLuchador1">int con id del luchador 1</param>
        /// <param name="idLuchador2">int con id del luchador 2</param>
        /// <param name="fechaCombate">DateTime con la fecha del combate</param>
        /// <returns></returns>
        public int getIdCombate(int idLuchador1, int idLuchador2, DateTime fechaCombate)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            int idCombate = 0;


            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@idLuchador1", System.Data.SqlDbType.Int).Value = idLuchador1;
                command.Parameters.Add("@idLuchador2", System.Data.SqlDbType.Int).Value = idLuchador2;
                command.Parameters.Add("@fechaCombate", System.Data.SqlDbType.Date).Value = fechaCombate;

                command.CommandText = "select co.idCombate, fechaCombate from SH_Combates as co " +
                                       "inner join SH_LuchadoresCombates as lc " +
                                       "on co.idCombate = lc.idCombate " +
                                       "where co.fechaCombate = @fechaCombate and idLuchador = @idLuchador1 " +

                                       "intersect " +

                                       "select co.idCombate, fechaCombate from SH_Combates as co " +
                                       "inner join SH_LuchadoresCombates as lc " +
                                       "on co.idCombate = lc.idCombate " +
                                       "where co.fechaCombate = @fechaCombate and idLuchador = @idLuchador2 ";

                //TODO en VM tengo que comprobar que el filasAfectadas > 1, pueden salir más de dos registros (por que haya de otras fechas), pero si al menos hay más de uno es que existe un combate con esa fecha y esos luchadores

                //Ejecuta la instrucción SQL
                idCombate = (int)command.ExecuteScalar();

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

            return idCombate;
        }
    }

}
