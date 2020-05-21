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
        private DateTime tiempoMax;

        #endregion

        #region Propiedades Públicas
        public int IdPrueba { get => idPrueba; set => idPrueba = value; }
        public int NumeroPalabras { get => numeroPalabras; set => numeroPalabras = value; }
        public DateTime TiempoMax { get => tiempoMax; set => tiempoMax = value; }
        #endregion

        #region Contructor
        public clsPrueba()
        {
            this.idPrueba = 1;
            this.numeroPalabras = 5;
            this.tiempoMax = new DateTime();
        }
        public clsPrueba(int idPrueba, int numeroPalabras, DateTime tiempoMax)
        {
            this.idPrueba = idPrueba;
            this.numeroPalabras = numeroPalabras;
            this.tiempoMax = tiempoMax;
        }

        
        #endregion
    }
}
