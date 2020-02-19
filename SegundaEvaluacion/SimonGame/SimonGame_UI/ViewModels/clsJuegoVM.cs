using SimonGame_UI.Models;
using SimonGame_UI.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonGame_UI.ViewModels
{
    public class clsJuegoVM
    {
        #region Atributos Privados
        private ObservableCollection<clsBoton> listadoBotones;
        #endregion

        #region Propiedades Públicas
        public ObservableCollection<clsBoton> ListadoBotones
        {
            get
            {
                return listadoBotones;
            }
        }
        #endregion

        #region constructor
        public clsJuegoVM()
        {
            listadoBotones = new clsListadoBotones().ListadoBotones();
        }
        #endregion
    }
}
