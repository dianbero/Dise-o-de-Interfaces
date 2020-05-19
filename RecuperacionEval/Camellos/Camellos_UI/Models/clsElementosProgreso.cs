using Camellos_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camellos_UI.Models
{
    /// <summary>
    /// Esta clase la creo para poder usarla en el gridView de la vista de progresos
    /// </summary>
    public class clsElementosProgreso : clsPruebasJugadores
    {
        #region Atributos Privados
        private DateTime tiempoMaxPrueba;
        #endregion

        #region Propiedades Públicas
        public DateTime TiempoMaxPrueba { get => tiempoMaxPrueba; set => tiempoMaxPrueba = value; }
        #endregion

        #region Contructor
        public clsElementosProgreso(int idJugador, int idPrueba, DateTime tiempoJugador, DateTime tiempoMaxPrueba) : 
            base(idJugador,idPrueba, tiempoJugador)
        {
            this.tiempoMaxPrueba = tiempoMaxPrueba;
        }
        #endregion

    }
}
