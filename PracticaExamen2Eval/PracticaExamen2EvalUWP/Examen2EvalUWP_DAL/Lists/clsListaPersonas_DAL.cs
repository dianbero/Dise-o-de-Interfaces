using _17_CRUD_Personas_UWP_DAL.Connections;
using Examen2EvalUWP_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_DAL.Lists
{
    public class clsListaPersonas_DAL
    {
        public async Task<ObservableCollection<clsPersona>> ListadoCompletoPersonasDAL()
        {
            ObservableCollection<clsPersona> listaPersonas = new ObservableCollection<clsPersona>();
            //Cliente
            HttpClient cliente = new HttpClient();
            //Cadena uri
            string cadenaUri = $"{clsMyConnection.getUriBase()}personasapi";

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

                    //Convierto el archivo Json a una lista de personas
                    listaPersonas = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(httpResponseBody);
                }
            }
            catch (Exception e)
            {
                httpResponseBody = $"Error: {e.HResult.ToString("X")} Message: {e.Message}";
            }

            return listaPersonas;
        }
    }
}
