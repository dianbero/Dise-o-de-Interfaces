using Examen2EvalUWP_DAL.Lists;
using Examen2EvalUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_BL.Lists
{
    public class clsListadoPrediccionesBL
    {
        /// <summary>
        ///  Método que obtiene la prediccion en tres días de una ciudad según su id
        /// </summary>
        /// <param name="idCiudad">int con el id de la ciudad deseada</param>
        /// <returns>ObservableCollection<clsCiudad> prediccion, con lista de predicciones de tres días</returns>
        public async Task<ObservableCollection<clsPrediccion>> ObtenerPrediccionCiudad(int idCiudad)
        {
            return await new clsListadoPrediccionesDAL().ObtenerPrediccionCiudad(idCiudad);
        }
    }
}
