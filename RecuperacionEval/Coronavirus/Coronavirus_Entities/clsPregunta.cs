using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_Entities
{
    public class clsPregunta
    {
        #region Atributos Privados
        private int idPregunta;
        public string pregunta;
        #endregion

        #region Propiedades Públicas
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        #endregion

        #region Constructor
        public clsPregunta()
        {
            this.idPregunta = 1;
            this.pregunta = "preguntaDefault";
        }

        public clsPregunta(int idPregunta, string pregunta)
        {
            this.idPregunta = idPregunta;
            this.pregunta = pregunta;
        }
        #endregion
    }
}
