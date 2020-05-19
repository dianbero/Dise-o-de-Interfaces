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
    public class clsHandlerProgresosBL
    {
        /*TODO:
         - int insertarProgreso(clsPruebasJugadores progreso)
         - ObservableCollection<clsPruebasJugadores> getProgresoJugador(idJugador)
         */

        /// <summary>
        /// Método que inserta un nuevo registro como progreso del jugador cada vez que este supera una prueba,
        /// con el tiempo que ha tardado en superarla
        /// </summary>
        /// <param name="progreso">clsPruebasJugadores con los datos del progreso para una prueba en concreto</param>
        /// <returns></returns>
        public int insertarProgreso(clsPruebasJugadores progreso)
        {
            return new clsHandlerProgresosDAL().insertarProgreso(progreso);
        }

        /// <summary>
        /// Método que obtiene una lista con el progreso total de un jugador
        /// </summary>
        /// <param name="idJugador">int con el id del jugador del que se quiere obtener el progreso</param>
        /// <returns>ObservableCollection<clsPruebasJugadores> listaProgresos, con el progreso total del jugador</returns>
        public ObservableCollection<clsPruebasJugadores> getProgresoJugador(int idJugador)
        {
            return new clsHandlerProgresosDAL().getProgresoJugador(idJugador);
        }
    }
}
