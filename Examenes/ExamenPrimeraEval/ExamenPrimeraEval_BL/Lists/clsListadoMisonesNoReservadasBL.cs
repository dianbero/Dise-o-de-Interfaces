using _17_CRUD_Personas_UWP_DAL.Lists;
using ExamenPrimeraEval_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEval_BL.Lists
{
    public class clsListadoMisonesNoReservadasBL
    {
        /// <summary>
        /// Método que obtiene el listado de misiones no reservadas de la BBDD
        /// </summary>
        /// <returns>Lista de misiones no reservadas</returns>
        public ObservableCollection<clsMision> ListadoMisionesNoReservadasBL()
        {
            clsListadoMisionesDAL listaMisionesNoReservadas = new clsListadoMisionesDAL();

            return listaMisionesNoReservadas.ListadoMisionesNoReservadas();
        }
    }
}
