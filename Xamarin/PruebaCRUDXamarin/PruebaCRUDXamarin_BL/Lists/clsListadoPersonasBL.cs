using PruebaCRUDXamarin_DAL.Lists;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCRUDXamarin_BL.Lists
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Método que obtiene el listado de todas la personas
        /// </summary>
        /// <returns>List<clsPersona> con el listado de todas las personas</returns>
        public Task<ObservableCollection<clsPersona>> ListadoPersonas()
        {
            return new clsListadoPersonasDAL().ListadoPersonas();
        }
    }
}
