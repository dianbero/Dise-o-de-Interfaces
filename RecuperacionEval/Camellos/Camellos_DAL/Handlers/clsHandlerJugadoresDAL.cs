using Camellos_DAL.Connections;
using Camellos_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_DAL.Handlers
{
    public class clsHandlerJugadoresDAL
    {
        /*TODO:
         - int insertarJugador(string nick, string password)
         - clsJugador getIdJugador(string nick, string password) //TODO cambiar a que devuelva el objeto entero del jugador
         - int checkExisteJugador(string nick, string password)
         */

        /// <summary>
        /// Método que inserta un nuevo jugador en la BBDD
        /// </summary>
        /// <param name="nick">string con el nick del jugador</param>
        /// <param name="password">string con la contrasela del jugador</param>
        /// <returns>int que indica el número de filas afectadas por la ejecución</returns> 
        /// <returns>int con el idJugador insertado</returns>
        public int insertarJugador(string nick, string password)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            //int filasAfectadas;
            Int32 idJugador = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = password;
                //command.CommandText = "INSERT INTO CJ_Jugadores VALUES (@nick, @password)";

                /*Me llama la atención meter dos sentencias SQL a la vez en el CommandText, pero en la documentación de microsoft lo hacen así, con la sentencia de inserción primero y después
                 el select, y obtiene el idJugador únicamente que era mi intención, porque es lo único que quiero pasarle a la siguiente vista*/
                command.CommandText = "INSERT INTO CJ_Jugadores VALUES (@nick, @password)" +
                    "SELECT * FROM CJ_JUGADORES WHERE nick = @nick"; //Pilla sólo la primera columna y de la primera fila de las afectadas por la sentencia, en mi caso el idJugador

                //Ejecuta la instrucción SQL
                //filasAfectadas = command.ExecuteNonQuery();      
                idJugador = (Int32)command.ExecuteScalar();
                

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

            //return filasAfectadas;
            return (int)idJugador;
        }


        ///// <summary>
        ///// Método que obtiene el id de un jugador de la BBDD
        ///// </summary>
        ///// <param name="nick">string con el nick del jugador a buscar</param>
        ///// <returns>int idJugador con el id del jugador obtenido de la BBDD</returns>
        //public clsJugador getJugador(string nick)
        //{
        //    clsMyConnection objConnection = new clsMyConnection();
        //    SqlConnection connection = null;
        //    SqlCommand command = new SqlCommand();
        //    SqlDataReader reader = null;

        //    clsJugador jugador = null;

        //    try
        //    {
        //        connection = objConnection.getConnection();
        //        command.Connection = connection;

        //        command.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
        //        command.CommandText = "SELECT * FROM CJ_Jugadores WHERE  nick = @nick";

        //        reader = command.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            if (reader.Read())
        //            {
        //                jugador = new clsJugador();

        //                jugador.IdJugador = (int)reader["idJugador"];
        //                jugador.Nick = (string)reader["nick"];
        //                jugador.Password = (string)reader["contraseña"];
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //        }
        //        if (connection != null)
        //        {
        //            objConnection.closeConnection(ref connection);
        //        }
        //    }

        //    return jugador;
        //}


        /// <summary>
        /// Método que obtiene el id de un jugador de la BBDD
        /// </summary>
        /// <param name="nick">string con el nick del jugador a buscar</param>
        /// <returns>int idJugador con el id del jugador obtenido de la BBDD</returns>
        public int getIdJugador(string nick)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            int idJugador = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
                command.CommandText = "SELECT idJugador FROM CJ_Jugadores WHERE  nick = @nick";

                //idJugador = (int)command.ExecuteScalar(); //Con esto salta excepción en viewmodel 
                reader = command.ExecuteReader(); //Con esto no salta excepción en ViewModel

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        idJugador = (int)reader["idJugador"];
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

            return idJugador;
        }

        /// <summary>
        /// Método que comprueba que el jugador existe devolviendo un entero con la cantidad de filas afectadas por la sentencia
        /// que deberá ser una sola
        /// </summary>
        /// <param name="nick">string con el nick del jugador a buscar</param>
        /// <param name="password">string con la contraseña del jugador a buscar</param>
        /// <returns>int filasAfectadas, con los registros obtenidos</returns>
        public int checkExisteJugador(string nick, string password)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            Int32 filasAfectadas = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = password;
                command.CommandText = "SELECT COUNT(*) FROM CJ_Jugadores WHERE  nick = @nick AND contraseña = @password";

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
    }
}
