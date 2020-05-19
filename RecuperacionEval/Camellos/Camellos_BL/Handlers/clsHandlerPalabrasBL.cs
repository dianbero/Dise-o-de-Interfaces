using Camellos_DAL.Handlers;
using Camellos_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_BL.Handlers
{
    public class clsHandlerPalabrasBL
    {
        /*TODO:
         - ObservableCollection<clsPalabra> getPalabrasPorIdPrueba(int idPrueba)
         */

        /// <summary>
        /// Método que obtiene la lista de palabras de una prueba
        /// </summary>
        /// <param name="idPrueba">int con el id de la prueba a la que pertenecen las palabras</param>
        /// <returns>ObservableCollection<clsPalabra> listaPalabras con el listado de las palabras obtenidas</returns>
        public ObservableCollection<clsPalabra> getPalabrasPorIdPrueba(int idPrueba)
        {
            return new clsHandlerPalabrasDAL().getPalabrasPorIdPrueba(idPrueba);
        }
    }
}
