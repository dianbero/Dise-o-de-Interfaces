using Newtonsoft.Json;
using PruebaCRUDXamarin_DAL.Connections;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCRUDXamarin_DAL.Handlers
{
    public class clsOperacionesDAL
    {
        /// <summary>
        /// Método que insertar una nueva persona
        /// </summary>
        /// <param name="nuevaPersona">Nueva persona a insertar</param>
        /// <returns></returns>
        public async Task InsertarPersona(clsPersona nuevaPersona)
        {
            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                HttpContent contenido;

                string uriBase = new clsMyConnection().getUriBase();

                Uri uri = new Uri($"{uriBase}PersonasAPI");
                HttpResponseMessage respuesta;

                string datos;
                datos = JsonConvert.SerializeObject(nuevaPersona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                respuesta = await httpClient.PostAsync(uri, contenido);

            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }
    }
}
