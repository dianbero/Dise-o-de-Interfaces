using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_Entities
{
    public class clsJugador
    {
        #region Atributos Privados
        private int idJugador;
        private string nick;
        private string password;
        #endregion

        #region Propiedades Públicas
        public int IdJugador { get => idJugador; set => idJugador = value; }
        public string Nick { get => nick; set => nick = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region Contructor
        public clsJugador()
        {
            this.idJugador = 1;
            this.nick = "Jugador1";
            this.password = "111";
        }
        public clsJugador(int idJugador, string nick, string password)
        {
            this.idJugador = idJugador;
            this.nick = nick;
            this.password = password;
        }
        #endregion
    }
}
