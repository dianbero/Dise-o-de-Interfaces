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
    public class clsHandlerPalabrasDAL
    {
        /*TODO:
         - ObservableCollection<clsPalabra> getPalabrasPorIdPrueba(int idPrueba)
         */

        /// <summary>
        /// Método que obtiene la lista de palabras de una prueba
        /// </summary>
        /// <param name="idPrueba">int con el id de la prueba a la que pertenecen las palabras</param>
        /// <returns>ObservableCollection<clsPalabra> listaPalabras con el listado de las palabras obtenidas</returns>
        public ObservableCollection<clsPalabra> getPalabrasPorIdPrueba(int idPrueba)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            ObservableCollection<clsPalabra> listaPalabras = new ObservableCollection<clsPalabra>();
            clsPalabra objPalabra = null;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@idPrueba", System.Data.SqlDbType.VarChar).Value = idPrueba;
                command.CommandText = "SELECT * FROM CJ_Palabras pa INNER JOIN CJ_PruebasPalabras pp ON pa.idPalabra = pp.idPalabra WHERE idPrueba = @idPrueba";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                        
                        objPalabra = new clsPalabra();

                        objPalabra.IdPalabra = (int)reader["idPalabra"];
                        objPalabra.Palabra = (string)reader["palabra"];
                        objPalabra.Dificultad = (byte)reader["dificultad"];

                        listaPalabras.Add(objPalabra);
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

            return listaPalabras;            
        }
    }
}
