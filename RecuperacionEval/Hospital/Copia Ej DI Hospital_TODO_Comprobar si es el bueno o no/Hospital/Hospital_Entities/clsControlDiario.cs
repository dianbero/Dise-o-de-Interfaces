using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Entities
{
    public class clsControlDiario
    {
        #region Atributos Privados
        private string codigoMedico;
        private DateTime fecha;
        private string primeraSesion;
        private string segundaSesion;
        private string terceraSesion;
        private string cuartaSesion;
        #endregion

        #region Propiedades Públicas
        public string CodigoMedico { get; set; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string PrimeraSesion { get => primeraSesion; set => primeraSesion = value; }
        public string SegundaSesion { get => segundaSesion; set => segundaSesion = value; }
        public string TerceraSesion { get => terceraSesion; set => terceraSesion = value; }
        public string CuartaSesion { get => cuartaSesion; set => cuartaSesion = value; }
        #endregion

        #region Constructor
        public clsControlDiario()
        {
            this.codigoMedico = "000AAA0000";
            this.fecha = new DateTime();
            this.primeraSesion = "primeraSesion";
            this.segundaSesion = "segundaSesion";
            this.terceraSesion = "terceraSesion";
            this.cuartaSesion = "cuartaSesion";
        }

        public clsControlDiario(string codigoMedico, DateTime fecha, string primeraSesion, string segundaSesion, string terceraSesion, string cuartaSesion)
        {
            this.codigoMedico = codigoMedico;
            this.fecha = fecha;
            this.primeraSesion = primeraSesion;
            this.segundaSesion = segundaSesion;
            this.terceraSesion = terceraSesion;
            this.cuartaSesion = cuartaSesion;
        }
        #endregion
    }
}
