using Camellos_DAL.Handlers;
using Camellos_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_BL.Handlers
{
    public class clsHandlerJugadoresBL
    {
        /*TODO:
         - int insertarJugador(string nick, string password)
         - clsJugador getIdJugador(string nick, string password)
         - int checkExisteJugador(string nick, string password)
         */

        /// <summary>
        /// Método que inserta un nuevo jugador en la BBDD
        /// </summary>
        /// <param name="nick">string con el nick del jugador</param>
        /// <param name="password">string con la contrasela del jugador</param>
        /// <returns>int que indica el número de filas afectadas por la ejecución</returns>
        public int insertarJugador(string nick, string password)
        {
            return new clsHandlerJugadoresDAL().insertarJugador(nick, password);
        }

        /// <summary>
        /// Método que obtiene el id de un jugador de la BBDD
        /// </summary>
        /// <param name="nick">string con el nick del jugador a buscar</param>
        /// <returns>int idJugador con el id del jugador obtenido de la BBDD</returns>
        public int getIdJugador(string nick)
        {
            return new clsHandlerJugadoresDAL().getIdJugador(nick);
        }

        /// <summary>
        /// Método que comprueba que el jugador existe devolviendo un entero con la cantidad de filas afectadas por la sentencia
        /// que deberá ser una sola
        /// </summary>
        /// <param name="nick">string con el nick del jugador a buscar</param>
        /// <param name="password">string con la contraseña del jugador a buscar</param>
        /// <returns>int filasAfectadas, con los registros obtenidos</returns>
        public int checkExisteJugador(string nick, string password)
        {
            return new clsHandlerJugadoresDAL().checkExisteJugador(nick, password);
        }
    }
}
