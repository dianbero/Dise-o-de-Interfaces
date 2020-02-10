using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_Entities
{
    public class clsCiudad
    {
        #region Atributos Privados
        private int idCiudad;
        private string nombreCiudad;
        #endregion

        #region Propiedades Públicas
        public int IdCiudad
        {
            get
            {
                return idCiudad;
            }
            set
            {
                idCiudad = value;
            }
        }

        public string NombreCiudad
        {
            get
            {
                return nombreCiudad;
            }
            set
            {
                nombreCiudad = value;
            }
        }
        #endregion

        #region Contructor
        public clsCiudad()
        {
            this.idCiudad = 1;
            this.nombreCiudad = "Albacete";
        }

        public clsCiudad(int idCiudad, string nombreCiudad)
        {
            this.idCiudad = idCiudad;
            this.nombreCiudad = nombreCiudad;
        }
        #endregion
    }
}
