using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_Entities
{
    public class clsRespuesta
    {
        #region Atributos Privados
        private int idRespuesta;
        private int idPregunta;
        private string respuesta;
        private bool posibleCaso;
        #endregion

        #region Propiedades Públicas
        public int IdRespuesta { get; set; }
        public int IdPregunta { get; set; }
        //public string Respuesta { get; set; }
        public string Respuesta
        {
            get
            {
                return respuesta;
            }
            set
            {
                respuesta = value;
            }
        }
        public bool PosibleCaso { get; set; }
        #endregion

        #region Constructor
        public clsRespuesta()
        {
            this.idRespuesta = 1;
            this.idPregunta = 1;
            this.respuesta = "Default";
            this.posibleCaso = false;
        }
        public clsRespuesta(int idRespuesta, int idPregunta, string respuesta, bool posibleCaso)
        {
            this.idRespuesta = idRespuesta;
            this.idPregunta = idPregunta;
            this.respuesta = respuesta;
            this.posibleCaso = posibleCaso;
        }
        #endregion
    }
}
