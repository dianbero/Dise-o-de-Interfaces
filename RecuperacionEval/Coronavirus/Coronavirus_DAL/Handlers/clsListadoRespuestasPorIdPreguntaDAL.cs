using Coronavirus_DAL.Connections;
using Coronavirus_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_DAL.Handlers
{
    public class clsListadoRespuestasPorIdPreguntaDAL
    {
        /// <summary>
        /// Método que obtiene el listado completo de las respuestas de una pregunta en concreto según su id
        /// </summary>
        /// <param name="idPregunta">int con el id de la pregunta de la que se desean obtener las respuestas</param>
        /// <returns>ObservableCollection<clsRespuesta> listadoRespuestas, con las respuestas de la pregunta en concreto</returns>
        public ObservableCollection<clsRespuesta> listadoRespuestasPorIdPregunta(int idPregunta)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsRespuesta objRespuesta;
            ObservableCollection<clsRespuesta> listadoRespuestas = new ObservableCollection<clsRespuesta>();

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@idPregunta", System.Data.SqlDbType.Int).Value = idPregunta;

                command.CommandText = "SELECT * FROM Respuestas WHERE idPregunta = @idPregunta";
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creo un nuevo objeto respuesta para añadir a la lista
                        objRespuesta = new clsRespuesta();
                        objRespuesta.IdRespuesta = (int)reader["idRespuesta"];
                        objRespuesta.IdPregunta = (int)reader["idPregunta"];
                        objRespuesta.Respuesta = (string)reader["respuesta"];
                        objRespuesta.PosibleCaso = (bool)reader["posibleCaso"];

                        //Añado el objeto obtenido a la lista de respuestas creada 
                        listadoRespuestas.Add(objRespuesta);
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

            return listadoRespuestas;
        }
    }
}
