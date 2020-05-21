using CrearPruebaCamellos_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_UI.Models
{
    public class clsPalabraConAtributoYaExiste : clsPalabra
    {
        #region Atributos Privados
        private bool yaExiste;
        #endregion

        #region Porpiedaddes Públicas
        public bool YaExiste { get => yaExiste; set => yaExiste = value; }
        #endregion

        #region Constructor
        //Constructor por defecto
        public clsPalabraConAtributoYaExiste()
           : base()
        {
            this.yaExiste = false;
        }
        //Constructor con parámetros
        public clsPalabraConAtributoYaExiste(int idPalabra, string palabra, int dificultad, bool yaExiste) 
            : base(idPalabra, palabra, dificultad)
        {
            this.yaExiste = yaExiste;
        }

        #endregion
    }
}
