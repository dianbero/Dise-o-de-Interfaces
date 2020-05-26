using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_Entities
{
    public class clsPrueba
    {
        #region Atributos Privados
        private int idPrueba;
        private int numeroPalabras;
        private TimeSpan tiempoMax;

        #endregion

        #region Propiedades Públicas
        public int IdPrueba { get => idPrueba; set => idPrueba = value; }
        public int NumeroPalabras { get => numeroPalabras; set => numeroPalabras = value; }
        public TimeSpan TiempoMax { get => tiempoMax; set => tiempoMax = value; }
        #endregion

        #region Contructor
        public clsPrueba()
        {
            this.idPrueba = 0;
            this.numeroPalabras = 0;
            this.tiempoMax = new TimeSpan();
        }
        public clsPrueba(int idPrueba, int numeroPalabras, TimeSpan tiempoMax)
        {
            this.idPrueba = idPrueba;
            this.numeroPalabras = numeroPalabras;
            this.tiempoMax = tiempoMax;
        }

        
        #endregion
    }
}
