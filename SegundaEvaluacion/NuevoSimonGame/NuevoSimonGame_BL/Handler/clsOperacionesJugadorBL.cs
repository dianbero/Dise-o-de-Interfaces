using NuevoSimonGame_DAL.Handler;
using NuevoSimonGame_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevoSimonGame_BL.Handler
{
    public class clsOperacionesJugadorBL
    {
        /// <summary>
        /// Método que inserta un nuevo jugador en la BD 
        /// </summary>
        /// <param name="nuevoJugador">objeto clsJugador nuevoJugador</param>
        /// <returns>int que representa la filas afectadas al ejecutar la inserción</returns>
        public int InsertNuevoJugador(clsJugador nuevoJugador)
        {
            return new clsOperacionesJugadorDAL().InsertNuevoJugador(nuevoJugador);
        }

        /// <summary>
        /// Método que obtiene la lista completa de jugadores 
        /// </summary>
        /// <returns>ObservableCollection<clsJugador> que representa la lista de jugadores de la BD</returns>
        public ObservableCollection<clsJugador> GetListaJugadores()
        {
            return new clsOperacionesJugadorDAL().GetListaJugadores();
        }
    }
}
