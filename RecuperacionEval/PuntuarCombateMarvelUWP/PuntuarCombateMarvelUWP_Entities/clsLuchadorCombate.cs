using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_Entities
{
    public class clsLuchadorCombate
    {
        #region Atributos Privados
        private int idCombate;
        private int idLuchador;
        private int puntuacionLuchador;
        #endregion

        #region Propiedades Públicas
        public int IdCombate { get => idCombate; set => idCombate = value; }
        public int IdLuchador { get => idLuchador; set => idLuchador = value; }
        public int PuntuacionLuchador { get => puntuacionLuchador; set => puntuacionLuchador = value; }
        #endregion

        #region Constructor
        public clsLuchadorCombate()
        {
            this.idCombate = 0;
            this.idLuchador = 0;
            this.puntuacionLuchador = 0;
        }

        public clsLuchadorCombate(int idCombate, int idLuchador, int puntuacionLuchador)
        {
            this.idCombate = idCombate;
            this.idLuchador = idLuchador;
            this.puntuacionLuchador = puntuacionLuchador;
        }
        #endregion
    }
}
