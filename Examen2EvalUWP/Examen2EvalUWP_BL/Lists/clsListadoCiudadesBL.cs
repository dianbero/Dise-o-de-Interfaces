using Examen2EvalUWP_DAL.Handlers;
using Examen2EvalUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_BL.Lists
{
    public class clsListadoCiudadesBL
    {
        /// <summary>
        /// Método que obtiene el listado de ciudades
        /// </summary>
        /// <returns>ObservableCollection<clsCiudad> listaCiudades, con el listado de las ciudades</returns>
        public async Task<ObservableCollection<clsCiudad>> ListadoCiudades()
        {
            return await new clsListadoCiudadesDAL().ListadoCompletoCiudadesDAL();
        }
    }
}
