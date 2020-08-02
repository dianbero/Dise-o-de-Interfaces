using PuntuarCombateMarvelUWP_DAL.Lists;
using PuntuarCombateMarvelUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_BL.Lists
{
    public class clsListadosLuchadoresBL
    {
        /// <summary>
        /// Método que obtiene el listado de todos los luchadores de la BBDD
        /// </summary>
        /// <returns>ObservableCollection<clsLuchador> listadoLuchadores, con todos los luchadores</returns>
        public ObservableCollection<clsLuchador> getListadoLuchadores()
        {
            return new clsListadosLuchadoresDAL().getListadoLuchadores();
        }

        /// <summary>
        /// Método que obtiene el listado de todos los luchadores de la BBDD ordenados por el total de sus rating en todos los combates que han participado
        /// </summary>
        /// <returns>ObservableCollection<clsLuchador> listadoLuchadores, con todos los luchadores</returns>
        public ObservableCollection<clsLuchador> getListadoLuchadoresOrdenados()
        {
            return new clsListadosLuchadoresDAL().getListadoLuchadoresOrdenados();
        }


    }
}
