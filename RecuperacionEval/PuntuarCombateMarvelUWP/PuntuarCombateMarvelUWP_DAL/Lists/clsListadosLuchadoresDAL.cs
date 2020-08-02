using PuntuarCombateMarvel_DAL.Connections;
using PuntuarCombateMarvelUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_DAL.Lists
{
    public class clsListadosLuchadoresDAL
    {
        /*TODO:
         * ObservableCollecion<clsLuchador> getListadoLuchadoresOrdenados()
         * ObservableCollecion<clsLuchador> getListadoLuchadores()
         * */

        /// <summary>
        /// Método que obtiene el listado de todos los luchadores de la BBDD
        /// </summary>
        /// <returns>ObservableCollection<clsLuchador> listadoLuchadores, con todos los luchadores</returns>
        public ObservableCollection<clsLuchador> getListadoLuchadores()
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader= null;

            ObservableCollection<clsLuchador> listadoLuchadores = new ObservableCollection<clsLuchador>();
            clsLuchador objLuchador = null;


            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;
                
                command.CommandText = "SELECT * FROM SH_Luchadores";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creo objeto clsLuchador
                        objLuchador = new clsLuchador();

                        //Paso los datos obtenidos al objeto clsLuchador
                        objLuchador.IdLuchador = (int)reader["idLuchador"];
                        objLuchador.NombreLuchador = reader.IsDBNull(reader.GetOrdinal("nombreLuchador")) ? "null" : (string)reader["nombreLuchador"];
                        objLuchador.FotoLuchador = reader.IsDBNull(reader.GetOrdinal("fotoLuchador")) ? new byte[0] : (byte[])reader["fotoLuchador"];

                        //Añado el nuevo objeto al listado
                        listadoLuchadores.Add(objLuchador);
                    }
                }              

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

            return listadoLuchadores;
        }

        /// <summary>
        /// Método que obtiene el listado de todos los luchadores de la BBDD ordenados por el total de sus rating en todos los combates que han participado
        /// </summary>
        /// <returns>ObservableCollection<clsLuchador> listadoLuchadores, con todos los luchadores</returns>
        public ObservableCollection<clsLuchador> getListadoLuchadoresOrdenados()
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            ObservableCollection<clsLuchador> listadoLuchadores = new ObservableCollection<clsLuchador>();
            clsLuchador objLuchador = null;


            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.CommandText = " SELECT lu.idLuchador, lu.nombreLuchador, lu.fotoLuchador, SUM(lc.puntuacionLuchador) AS totalPuntuacionLuchador " +
                                         "FROM SH_LuchadoresCombates AS lc, SH_Luchadores AS lu " +
                                         "WHERE lu.idLuchador = lc.idLuchador " +
                                         "GROUP BY lu.idLuchador, lu.nombreLuchador, lu.fotoLuchador "+
                                         "ORDER BY SUM(lc.puntuacionLuchador) DESC";


                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creo objeto clsLuchador
                        objLuchador = new clsLuchador();

                        //Paso los datos obtenidos al objeto clsLuchador
                        objLuchador.IdLuchador = (int)reader["idLuchador"];
                        objLuchador.NombreLuchador = reader.IsDBNull(reader.GetOrdinal("nombreLuchador")) ? "null" : (string)reader["nombreLuchador"];
                        objLuchador.FotoLuchador = reader.IsDBNull(reader.GetOrdinal("fotoLuchador")) ? new byte[0] : (byte[])reader["fotoLuchador"];

                        //Añado el nuevo objeto al listado
                        listadoLuchadores.Add(objLuchador);
                    }
                }
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

            return listadoLuchadores;

        }

    }

}
