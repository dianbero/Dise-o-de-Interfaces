﻿using Proyecto_Juego_Parejas_DAL.Connections;
using Proyecto_Juego_Parejas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_DAL.Handlers
{
    public class clsOperacionesJugadorDAL
    {
        /// <summary>
        /// Método que inserta un nuevo jugador en la BD
        /// </summary>
        /// <param name="nuevoJugador">objeto clsJugador nuevoJugador</param>
        /// <returns>int filasAfectadas</returns>
        public int InsertNuevoJugador(clsJugador nuevoJugador)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            int filasAfectadas = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@nombreJugador", System.Data.SqlDbType.VarChar).Value = nuevoJugador.NombreJugador;
                command.Parameters.Add("@puntuacionJugador", System.Data.SqlDbType.DateTime).Value = nuevoJugador.Puntuacion;

                command.CommandText = "INSERT INTO TopScores (nombreJugador, puntuacion) VALUES (@nombreJugador, @puntuacionJugador)";

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
        /// Método que obtiene la lista completa de jugadores ordenada de menor a mayor tiempo
        /// </summary>
        /// <returns>ObservableCollection<clsJugador> listaJugadores</returns>
        public ObservableCollection<clsJugador> GetListaJugadores()
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsJugador objJugador;
            ObservableCollection<clsJugador> listaJugadores = new ObservableCollection<clsJugador>();

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM TopScores ORDER BY puntuacion";
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objJugador = new clsJugador();
                        objJugador.IdJugador = (int)reader["idJugador"];
                        objJugador.NombreJugador = (string)reader["nombreJugador"];
                        objJugador.Puntuacion = (DateTime)reader["puntuacion"];

                        listaJugadores.Add(objJugador);
                    }
                }
            }
            catch(Exception e)
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

            return listaJugadores;
        }
    }
}
