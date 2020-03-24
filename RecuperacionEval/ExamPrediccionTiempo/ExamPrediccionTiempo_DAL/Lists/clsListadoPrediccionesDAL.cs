using ExamPrediccionTiempo_DAL.Connections;
using ExamPrediccionTiempo_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrediccionTiempo_DAL.Lists
{ 
    public class clsListadoPrediccionesDAL
    {

        /// <summary>
        ///  Método que obtiene la prediccion en tres días de una ciudad según su id
        /// </summary>
        /// <param name="idCiudad">int con el id de la ciudad deseada</param>
        /// <returns>ObservableCollection<clsCiudad> prediccion, con lista de predicciones de tres días</returns>
        public async Task<ObservableCollection<clsPrediccion>> ObtenerPrediccionCiudad(int idCiudad)
        {
            ObservableCollection<clsPrediccion> predicciones = new ObservableCollection<clsPrediccion>();
            //Cliente
            HttpClient cliente = new HttpClient();
            //Cadena uri
            string cadenaUri = $"{clsMyConnection.getUriBase()}prediccion/{idCiudad}";

            Uri requestUri = new Uri(cadenaUri);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await cliente.GetAsync(requestUri);
                if (httpResponse.IsSuccessStatusCode)
                {
                    httpResponse.EnsureSuccessStatusCode();

                    //Devuelve archivo Json, por lo que hay que convertirlo a Listado normal
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

                    //Convierto el archivo Json a una lista de predicciones
                    predicciones = JsonConvert.DeserializeObject<ObservableCollection<clsPrediccion>>(httpResponseBody);
                }
            }
            catch (Exception e)
            {
                httpResponseBody = $"Error: {e.HResult.ToString("X")} Message: {e.Message}";
            }

            return predicciones;
        }
    }
}
