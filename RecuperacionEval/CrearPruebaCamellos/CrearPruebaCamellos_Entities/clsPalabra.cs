using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_Entities
{
    public class clsPalabra
    {               
        #region Atributos Privados
        private int idPalabra;
        private string palabra;
        private int dificultad;
        #endregion

        #region Propiedades Públicas
        public int IdPalabra { get => idPalabra; set => idPalabra = value; }
        public string Palabra { get => palabra; set => palabra = value; }
        public int Dificultad { get => dificultad; set => dificultad = value; }
        #endregion

        #region Contructor
        public clsPalabra()
        {
            this.idPalabra = 1;
            this.palabra = "Camellos";
            this.dificultad = 3;
        }
        public clsPalabra(int idPalabra, string palabra, int dificultad)
        {
            this.idPalabra = idPalabra;
            this.palabra = palabra;
            this.dificultad = dificultad;
        }

        #endregion


    }
}
