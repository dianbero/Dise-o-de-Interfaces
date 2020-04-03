using Coronavirus_DAL.Handlers;
using Coronavirus_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_BL.Handlers
{
    public class clsListadoRespuestasPorIdPreguntaBL
    {
        /// <summary>
        /// Método que obtiene el listado completo de las respuestas de una pregunta en concreto según su id
        /// </summary>
        /// <param name="idPregunta">int con el id de la pregunta de la que se desean obtener las respuestas</param>
        /// <returns>ObservableCollection<clsRespuesta> con las respuestas de la pregunta en concreto</returns>
        public ObservableCollection<clsRespuesta> listadoRespuestasPorIdPregunta(int idPregunta)
        {
            return new clsListadoRespuestasPorIdPreguntaDAL().listadoRespuestasPorIdPregunta(idPregunta);
        }
    }
}
