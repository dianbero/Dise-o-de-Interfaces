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
    public class clsListadoSuperHeroesBL
    {
        /// <summary>
        /// Método que obtiene un listado de los superhéroes de la BBDD
        /// </summary>
        /// <returns>Lista de superhéroes</returns>
       public ObservableCollection<clsSuperHeroe> ListadoSuperHeroes()
        {
            clsListadoSuperHeroesDAL listaSuperHeores = new clsListadoSuperHeroesDAL();
            return listaSuperHeores.ListadoSuperHeroes();
        }
    }
}
