using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Entities
{
    public class clsMedico
    {
        #region Atributos Privados
        private string codigoMedico;
        private string nombreMedico;
        private string apellidosMedico;
        #endregion

        #region Propiedades Públicas
        public string CodigoMedico { get; set; }
        public string NombreMedio { get; set; }
        public string ApellidosMedico { get; set; }
        #endregion

        #region Constructor
        public clsMedico()
        {
            this.codigoMedico = "000AAA0000";
            this.nombreMedico = "Default name";
            this.apellidosMedico = "Default Surname";
        }
        public clsMedico(string codigoMedico, string nombreMedico, string apellidosMedico)
        {
            this.codigoMedico = codigoMedico;
            this.nombreMedico = nombreMedico;
            this.apellidosMedico = apellidosMedico;
        }
        #endregion
    }
}
