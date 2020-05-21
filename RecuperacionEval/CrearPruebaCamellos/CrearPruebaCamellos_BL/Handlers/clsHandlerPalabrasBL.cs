using CrearPruebaCamellos_DAL.Handlers;
using CrearPruebaCamellos_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_BL.Handlers
{
    public class clsHandlerPalabrasBL
    {
        /// <summary>
        /// Método que comprueba si existe una palabra 
        /// </summary>
        /// <param name="palabra">string con la palabra que se quiere comprobar</param>
        /// <returns>int filasAfectadas con el número de registros obtenidos por la ejecución</returns>
        public int checkExistePalabra(string palabra)
        {
            return new clsHandlerPalabrasDAL().checkExistePalabra(palabra);
        }

        /// <summary>
        /// Método que obtiene los datos de una palabra ya existente en la BBDD.
        /// </summary>
        /// <param name="palabra">string con la palabra que se desea obtener</param>
        /// <returns>clsPalabra objPalabra, con todos los datos de la palabra obtenida de la BBDD</returns>
        public clsPalabra getPalabraExistente(string palabra)
        {
            return new clsHandlerPalabrasDAL().getPalabraExistente(palabra);
        }

        /// <summary>
        /// Método que inserta una nueva palabra en la BBDD
        /// </summary>
        /// <param name="nuevaPalabra">clsPalabra con los datos de la nueva palabra</param>
        /// <returns>int idPalabra, de la palabra insertada en la BBDD</returns>
        public int insertarPalabra(clsPalabra nuevaPalabra)
        {
            return new clsHandlerPalabrasDAL().insertarPalabra(nuevaPalabra);
        }
    }
}
