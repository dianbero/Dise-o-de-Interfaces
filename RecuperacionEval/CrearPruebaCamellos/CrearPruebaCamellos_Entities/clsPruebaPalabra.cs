using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_Entities
{
    public class clsPruebaPalabra
    {
        #region Atributos Privados
        private int idPrueba;
        private int idPalabra;
        #endregion

        #region Propiedades Públicas
        public int IdPrueba { get => idPrueba; set => idPrueba = value; }
        public int IdPalabra { get => idPalabra; set => idPalabra = value; }
        #endregion

        #region Constructor
        //Constructor por defecto
        public clsPruebaPalabra()
        {
            this.idPrueba = 0;
            this.idPalabra = 0;
        }
        //constructor por parámetros
        public clsPruebaPalabra(int idPrueba, int idPalabra)
        {
            this.idPrueba = idPrueba;
            this.idPalabra = idPalabra;
        }

        #endregion


    }
}
