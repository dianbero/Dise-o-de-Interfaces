﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _17_CRUD_Personas_UWP_Entities;
using _17_CRUD_Personas_UWP_DAL.Connections;
using System.Collections.ObjectModel;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace _17_CRUD_Personas_UWP_DAL.Lists
{
    public class clsListadoPersonasDAL
    {
        /*Pagina para ver cómo se implementa:
         https://docs.microsoft.com/es-es/windows/uwp/networking/httpclient
         */
        public async Task<List<clsPersona>> ListadoPersonasDAL()  //debe esperar a que reciba el listado
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            //CLiente
            HttpClient cliente = new HttpClient();

            //string cadena = clsMyConnection.getUriBase() + "PersonaApi/";
            string cadena = $"{clsMyConnection.getUriBase()}/Persona";

            Uri requestUri = new Uri(cadena);

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
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync(); //devuelve archivo Json, por lo que hay que convertirlo a Listado normal
                    var lista = JsonConvert.DeserializeObject<List<clsPersona>>(httpResponseBody); //convierto el archivo Json a una lista de personas
                }



            }
            catch(Exception e) //Mensaje de error
            {
                //httpResponseBody = "Error: " + e.HResult.ToString("X") + " Message: " + e.Message;
                httpResponseBody = $"Error: {e.HResult.ToString("X")} +  Message: {e.Message}";
            }

            return listadoPersonas;
        }
    }
}
