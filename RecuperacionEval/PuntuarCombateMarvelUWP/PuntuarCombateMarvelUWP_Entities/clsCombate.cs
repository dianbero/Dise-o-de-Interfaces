using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_Entities
{
    public class clsCombate
    {
        #region Atributos Privados
        private int idCombate;
        private DateTime fechaCombate;
        #endregion

        #region Propiedades Públicas
        public int IdCombate { get => idCombate; set => idCombate = value; }
        public DateTime FechaCombate { get => fechaCombate; set => fechaCombate = value; }

        #endregion

        #region Constructor
        public clsCombate()
        {
            this.idCombate = 0;
            this.fechaCombate = new DateTime();
        }
        public clsCombate(int idCombate, DateTime fechaCombate)
        {
            this.idCombate = idCombate;
            this.fechaCombate = fechaCombate;
        }

        #endregion


    }
}
