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
    public class clsListadoPreguntasBL
    {
        /// <summary>
        /// Método que obtiene el listado completo de preguntas de la BD
        /// </summary>
        /// <returns>ObservableCollection<clsPregunta> con todas las preguntas de la BD</returns>
        public ObservableCollection<clsPregunta> getListadoPreguntasBL()
        {
            return new clsListadoPreguntasDAL().getListadoPreguntas();
        }
    }
}
