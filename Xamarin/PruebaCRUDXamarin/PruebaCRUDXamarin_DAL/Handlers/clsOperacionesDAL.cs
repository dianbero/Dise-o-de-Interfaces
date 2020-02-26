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
        //Insertar
        public async Task InsertarPersona(clsPersona nuevaPersona)
        {
            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                HttpContent contenido;

                string uriBase = new clsMyConnection().getUriBase();

                Uri uri = new Uri($"{uriBase}");
                HttpResponseMessage respuesta;

                string datos;
                datos = JsonConvert.SerializeObject(nuevaPersona);
                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");
                respuesta = await httpClient.PostAsync(uri, contenido);

                //// Construct the JSON to post.
                //HttpStringContent content = new HttpStringContent(
                //    " \"nombre\": \""+nuevaPersona.Nombre+"\"}"+
                //    " \"apellidos\": \"" + nuevaPersona.Apellidos+"\"}"+
                //    " \"idPersona\": \"" + nuevaPersona.Id+"\"}"+
                //    " \"idDepartamento\": \"" + nuevaPersona.IdDepartamento+"\"}"+
                //    " \"telefono\": \"" + nuevaPersona.Telefono+"\"}"+
                //    " \"fechaNacimiento\": \"" + nuevaPersona.FechaNacimiento+"\"}",
                //    Encoding.UTF8,
                //    "application/json");


                // Post the JSON and wait for a response.
                //HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(
                //    uri,
                //    content);

                // Make sure the post succeeded, and write out the response.
                httpResponseMessage.EnsureSuccessStatusCode();
                var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine(httpResponseBody);
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }
    }
}
