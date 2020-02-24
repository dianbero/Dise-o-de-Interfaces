using Newtonsoft.Json;
using PruebaCRUDXamarin_DAL.Connections;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCRUDXamarin_DAL.Lists
{
    public class clsListadoPersonasDAL
    {
        public async Task<ObservableCollection<clsPersona>> ListadoPersonas()
        {
            ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

            HttpClient cliente = new HttpClient();

            String uriBase = new clsMyConnection().getUriBase();

            Uri requestUri = new Uri(uriBase + "PersonasAPI");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                //Send the GET request
                httpResponse = await cliente.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                listadoPersonas = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(httpResponseBody);
            }
            catch (Exception e)
            {
                httpResponseBody = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
            }

            return listadoPersonas;
        }
    }
}
