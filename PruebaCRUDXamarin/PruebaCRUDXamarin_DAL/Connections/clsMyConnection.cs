using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace PruebaCRUDXamarin_DAL.Connections
{
    public class clsMyConnection
    {
        /// <summary>
        /// Método que obtiene la cadena Uri de la Api Base.
        /// </summary>
        /// <returns></returns>
        public string getUriBase()
        {
            string uriBase;
            uriBase = "https://crudpersonasui-victor.azurewebsites.net/api/personasapi/ ";
            return uriBase;
        }

    }

}
