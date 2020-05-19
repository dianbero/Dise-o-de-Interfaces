using Camellos_DAL.Connections;
using Camellos_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_DAL.Handlers
{
    public class clsHandlerPruebasDAL
    {
        /*TODO:
         - clsPrueba getPrueba(int idPrueba)
         - int getUltimaPruebaJugador(int idJugador)
         - ObservableCollection<clsPrueba> getListadoCompletoPruebas() //Porque quizás sea mejor obtener todas las pruebas del tirón
             y luego buscar en la lista la prueba en concreto que desee, y así no itero sobre el idPrueba si no sobre la posición de las pruebas
             en el listado
         */

        /// <summary>
        /// Método que obtiene una prueba de la BBDD
        /// </summary>
        /// <param name="idPrueba">int con el id de la prueba que se desea obtener</param>
        /// <returns>clsPrueba objPrueba con la prueba obtenida de la BBDD</returns>
        public clsPrueba getPrueba(int idPrueba)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsPrueba objPrueba = null;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = idPrueba;
                command.CommandText = "SELECT * FROM CJ_Pruebas WHERE  idPrueba = @idPrueba";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        objPrueba = new clsPrueba();

                        objPrueba.IdPrueba = (int)reader["idPrueba"];
                        objPrueba.NumeroPalabras = (int)reader["numeroPalabras"];
                        //objPrueba.TiempoMax = (DateTime)reader["tiempoMaximo"];
                        objPrueba.TiempoMax = Convert.ToDateTime(reader["tiempoMaximo"].ToString());

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

            return objPrueba;
        }

        /// <summary>
        /// Método que obtiene el listado completo de pruebas de la BBDD
        /// </summary>
        /// <returns>ObservableCollection<clsPrueba> listaPruebas con todas las pruebas obtenidas de la BBDD</returns>
        public ObservableCollection<clsPrueba> getListadoCompletoPruebas()
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            ObservableCollection<clsPrueba> listaPruebas = new ObservableCollection<clsPrueba>();
            clsPrueba objPrueba = null;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;
                
                command.CommandText = "SELECT * FROM CJ_Pruebas";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objPrueba = new clsPrueba();

                        objPrueba.IdPrueba = (int)reader["idPrueba"];
                        objPrueba.NumeroPalabras = (int)reader["numeroPalabras"];
                        objPrueba.TiempoMax = Convert.ToDateTime(reader["tiempoMaximo"].ToString());

                        listaPruebas.Add(objPrueba);
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

            return listaPruebas;
        }

        /// <summary>
        /// Método que obtiene el id de la última prueba registrada de un jugador
        /// </summary>
        /// <param name="idJugador">int con el id del jugador</param>
        /// <returns>int idPrueba, con id de la prueba obtenida de la BBDD</returns>
        public int getUltimaPruebaJugador(int idJugador)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsPrueba objPrueba = null;
            int idPrueba = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = idJugador;
                command.CommandText = "SELECT TOP 1 idPrueba FROM CJ_PruebasJugadores WHERE idJugador = @idJugador ORDER BY idPrueba DESC";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idPrueba = (int)reader["idPrueba"];

                        //objPrueba = new clsPrueba();

                        //objPrueba.IdPrueba = (int)reader["idPrueba"];
                        //objPrueba.NumeroPalabras = (int)reader["numeroPalabras"];
                        //objPrueba.TiempoMax = (DateTime)reader["tiempoMaximo"];

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

            return idPrueba;
        }
    }
}
