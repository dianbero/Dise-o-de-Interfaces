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
    public class clsListadoPreguntasDAL
    {
        /// <summary>
        /// Método que obtiene el listado completo de preguntas de la BD
        /// </summary>
        /// <returns>ObservableCollection<clsPregunta> listadoPreguntas, con todas las preguntas de la BD</returns>
        public ObservableCollection<clsPregunta> getListadoPreguntas()
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsPregunta objPregunta;
            ObservableCollection<clsPregunta> listadoPreguntas = new ObservableCollection<clsPregunta>();

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.CommandText = "SELECT * FROM Preguntas";
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Creo un nuevo objeto pregunta para añadir a la lista
                        objPregunta = new clsPregunta();
                        objPregunta.IdPregunta = (int)reader["idPregunta"];
                        objPregunta.Pregunta = (string)reader["pregunta"];

                        //Añado el objeto obtenido a la lista de preguntas creada 
                        listadoPreguntas.Add(objPregunta);
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

            return listadoPreguntas;
        }
    }
}
