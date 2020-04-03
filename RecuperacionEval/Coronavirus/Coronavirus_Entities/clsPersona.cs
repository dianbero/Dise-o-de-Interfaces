using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_Entities
{
    public class clsPersona
    {

        #region Atributos Privados
        private string dniPersona;
        private string nombrePersona;
        private string apellidosPersona;
        private string telefono;
        private string direccion;
        private bool diagnostico;
        #endregion

        #region Propiedades Públicas
        public string DniPersona
        {
            get
            {
                return dniPersona;
            }
            set
            {
                dniPersona = value;
            }
        }
        public string NombrePersona
        {
            get
            {
                return nombrePersona;
            }
            set
            {
                nombrePersona = value;
            }
        }
        public string ApellidosPersona
        {
            get
            {
                return apellidosPersona;
            }
            set
            {
                apellidosPersona = value;
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }
        public bool Diagnostico
        {
            get
            {
                return diagnostico;
            }
            set
            {
                diagnostico = value;
            }
        }
        #endregion
        #region Constructor
        public clsPersona()
        {
            //this.dniPersona = "dniDefault";
            //this.nombrePersona = "nombreDefault";
            //this.apellidosPersona = "apellidosDefault";
            //this.telefono = "telefonoDefault";
            //this.direccion = "direccionDefault";
            //this.diagnostico = false;
            this.dniPersona = "";
            this.nombrePersona = "";
            this.apellidosPersona = "";
            this.telefono = "";
            this.direccion = "";
            this.diagnostico = false;
        }
        public clsPersona(string dniPersona, string nombrePersona, string apellidosPersona, string telefono, string direccion, bool diagnostico)
        {
            this.dniPersona = dniPersona;
            this.nombrePersona = nombrePersona;
            this.apellidosPersona = apellidosPersona;
            this.telefono = telefono;
            this.direccion = direccion;
            this.diagnostico = diagnostico;
        }
        #endregion
    }
}
