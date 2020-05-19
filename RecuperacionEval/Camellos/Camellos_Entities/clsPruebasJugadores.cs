using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_Entities
{
    public class clsPruebasJugadores
    {
        #region Atributos Privados
        private int idJugador;
        private int idPrueba;
        private DateTime tiempoJugador;

        #endregion

        #region Propiedades Públicas
        public int IdJugador { get => idJugador; set => idJugador = value; }
        public int IdPrueba { get => idPrueba; set => idPrueba = value; }
        public DateTime TiempoJugador { get => tiempoJugador; set => tiempoJugador = value; }
        #endregion

        #region Constructor        
        public clsPruebasJugadores()
        {
            this.idJugador = 1;
            this.idPrueba = 1;
            this.tiempoJugador = new DateTime();
        }
        public clsPruebasJugadores(int idJugador, int idPrueba, DateTime tiempoJugador)
        {
            this.idJugador = idJugador;
            this.idPrueba = idPrueba;
            this.tiempoJugador = tiempoJugador;
        }
        #endregion
    }
}
