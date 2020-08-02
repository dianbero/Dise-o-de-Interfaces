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
    public class clsHandlerCombatesDAL
    {
        /*TODO:
         - int insertarCombate(clsCombate nuevoCombate)
         - int checkExisteCombate(int idLuchador1, int idLuchador2, DateTime fechaCombate)
         */

        /// <summary>
        /// Método que inserta un nuevo combate en la BBDD
        /// </summary>
        /// <param name="nuevoCombate">clsCombate con los datos del nuevo combate</param>
        /// <returns>int idCombate, del combate recién insertado</returns>
        public int insertarCombate(clsCombate nuevoCombate)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            //int filasAfectadas;
            int idCombate = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@fechaCombate", System.Data.SqlDbType.Date).Value = nuevoCombate.FechaCombate; //TODO ver si necesita castearse a DATETIME
                
                //command.CommandText = "INSERT INTO SH_Combates VALUES (getdate()) " +
                command.CommandText = "INSERT INTO SH_Combates VALUES (@fechaCombate) " +
                    "SELECT TOP 1 * FROM SH_Combates ORDER BY idCombate DESC"; //Pilla sólo la primera columna y de la primera fila de la última prueba insertada, en mi caso el idCombate

                //Ejecuta la instrucción SQL
                //filasAfectadas = command.ExecuteNonQuery();      
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

        /// <summary>
        /// Método que comprueba si existe un combate según su fecha y los luchadores que participan
        /// </summary>
        /// <param name="idLuchador1">int con id del luchador 1</param>
        /// <param name="idLuchador2">int con id del luchador 2</param>
        /// <param name="fechaCombate">DateTime con la fecha del combate</param>
        /// <returns>int filasAfectadas, con número de filas afectadas</returns>
        public int checkExisteCombate(int idLuchador1, int idLuchador2, DateTime fechaCombate)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            int filasAfectadas = 0;
            //string fecha = fechaCombate.ToString("yyyy-MM-dd");

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@idLuchador1", System.Data.SqlDbType.Int).Value = idLuchador1;
                command.Parameters.Add("@idLuchador2", System.Data.SqlDbType.Int).Value = idLuchador2;
                command.Parameters.Add("@fechaCombate", System.Data.SqlDbType.Date).Value = fechaCombate;

                command.CommandText =   "select count(*) from " +
                                        "(select co.idCombate, fechaCombate from SH_Combates as co " +
                                        "inner join SH_LuchadoresCombates as lc "+
                                        "on co.idCombate = lc.idCombate "+
                                        "where co.fechaCombate = @fechaCombate and idLuchador = @idLuchador1 " +

                                        "intersect "+

                                        "select co.idCombate, fechaCombate from SH_Combates as co "+
                                        "inner join SH_LuchadoresCombates as lc "+
                                        "on co.idCombate = lc.idCombate "+
                                        "where co.fechaCombate = @fechaCombate and idLuchador = @idLuchador2) I";
                //TODO en VM tengo que comprobar que el filasAfectadas == 1

                //Ejecuta la instrucción SQL
                filasAfectadas = (int)command.ExecuteScalar();

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
