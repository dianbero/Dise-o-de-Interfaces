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
    public class clsHandlerPruebasBL
    {
        /*TODO:
         - clsPrueba getPrueba(int idPrueba)
         - int getUltimaPruebaJugador(int idJugador)
         - ObservableCollection<clsPrueba> getListadoCompletoPruebas() //Porque quizás sea mejor obtener todas las pruebas del tirón
         y luego buscar en la lista la prueba en concreto que desee, y así no itero sobre el idPrueba si no sobre la posición de las pruebas
         en el listado
         */

        /// <summary>
        /// Método que obtiene una prueba de la BBDD
        /// </summary>
        /// <param name="idPrueba">int con el id de la prueba que se desea obtener</param>
        /// <returns>clsPrueba objPrueba con la prueba obtenida de la BBDD</returns>
        public clsPrueba getPrueba(int idPrueba)
        {
            return new clsHandlerPruebasDAL().getPrueba(idPrueba);
        }

        /// <summary>
        /// Método que obtiene el listado completo de pruebas de la BBDD
        /// </summary>
        /// <returns>ObservableCollection<clsPrueba> listaPruebas con todas las pruebas obtenidas de la BBDD</returns>
        public ObservableCollection<clsPrueba> getListadoCompletoPruebas()
        {
            return new clsHandlerPruebasDAL().getListadoCompletoPruebas();
        }

        /// <summary>
        /// Método que obtiene el id de la última prueba registrada de un jugador
        /// </summary>
        /// <param name="idJugador">int con el id del jugador</param>
        /// <returns>int idPrueba, con id de la prueba obtenida de la BBDD</returns>
        public int getUltimaPruebaJugador(int idJugador)
        {
            return new clsHandlerPruebasDAL().getUltimaPruebaJugador(idJugador);
        }
    }
}
