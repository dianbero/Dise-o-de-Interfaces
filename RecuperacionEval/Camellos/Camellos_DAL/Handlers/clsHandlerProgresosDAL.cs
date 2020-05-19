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
    public class clsHandlerProgresosDAL
    {
        /*TODO:
         - int insertarProgreso(clsPruebasJugadores progreso)
         - ObservableCollection<clsPruebasJugadores> getProgresoJugador(idJugador)
         */
        
        /// <summary>
        /// Método que inserta un nuevo registro como progreso del jugador cada vez que este supera una prueba,
        /// con el tiempo que ha tardado en superarla
        /// </summary>
        /// <param name="progreso">clsPruebasJugadores con los datos del progreso para una prueba en concreto</param>
        /// <returns></returns>
        public int insertarProgreso(clsPruebasJugadores progreso)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            int filasAfectadas;


            TimeSpan timeSpan = new TimeSpan(progreso.TiempoJugador.Hour, progreso.TiempoJugador.Minute, progreso.TiempoJugador.Second);

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = progreso.IdPrueba;

                command.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = progreso.IdJugador;
                //command.Parameters.Add("@tiempoJugador", System.Data.SqlDbType.Time).Value = progreso.TiempoJugador;
                command.Parameters.Add("@tiempoJugador", System.Data.SqlDbType.Time).Value = timeSpan; //Tiene queser TimeSpan porque es el correspondiente para tipo Time en BBDD

                command.CommandText = "INSERT INTO CJ_PruebasJugadores(idJugador, idPrueba, tiemoJugador) VALUES (@idJugador, @idPrueba, @tiempoJugador)";

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

        /// <summary>
        /// Método que obtiene una lista con el progreso total de un jugador
        /// </summary>
        /// <param name="idJugador">int con el id del jugador del que se quiere obtener el progreso</param>
        /// <returns>ObservableCollection<clsPruebasJugadores> listaProgresos, con el progreso total del jugador</returns>
        public ObservableCollection<clsPruebasJugadores> getProgresoJugador(int idJugador)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            ObservableCollection<clsPruebasJugadores> listaProgresos = new ObservableCollection<clsPruebasJugadores>();
            clsPruebasJugadores objProgreso;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = idJugador;
                command.CommandText = "SELECT * FROM CJ_PruebasJugadores WHERE  idJugador = @idJugador";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objProgreso = new clsPruebasJugadores();

                        objProgreso.IdJugador = (int)reader["idJugador"];
                        objProgreso.IdPrueba = (int)reader["idPrueba"];
                        //objProgreso.TiempoJugador = (DateTime)reader["tiemoJugador"]; //Esto da error, no castea bien
                        objProgreso.TiempoJugador = Convert.ToDateTime(reader["tiemoJugador"].ToString());

                        listaProgresos.Add(objProgreso);
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

            return listaProgresos;
        }
    }
}
