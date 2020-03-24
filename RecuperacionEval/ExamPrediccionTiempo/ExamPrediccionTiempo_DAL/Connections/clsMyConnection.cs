using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ExamPrediccionTiempo_DAL.Connections
{
    public class clsMyConnection
    {
        /// <summary>
        /// Método que obtiene la cadena Uri de la Api Base de ciudades.
        /// </summary>
        /// <returns>uri de ciudades</returns>
        public static string getUriBase()
        {
            string uriBase;
            //uriBase = "https://crudpersonasui-victor.azurewebsites.net/api/"; 
            uriBase = "https://webapiaemet.azurewebsites.net/api/"; 
            return uriBase;
        }

    }

}
