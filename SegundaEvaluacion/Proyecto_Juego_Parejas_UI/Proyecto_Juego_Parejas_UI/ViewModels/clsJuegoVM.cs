using Proyecto_Juego_Parejas_DAL.Utiles;
using Proyecto_Juego_Parejas_Entities;
using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Atributos Privados
        private clsCarta cartaSeleccionada;
        private ObservableCollection<clsCarta> listadoCompletoCartas;
        #endregion

        #region Constructores
        public clsJuegoVM()
        {
            clsListadoCompletoCartas listadoCartas = new clsListadoCompletoCartas();
            //listadoCompletoCartas = listadoCartas.ListadoCompletoCartasEnCasilla();
            listadoCompletoCartas = listadoCartas.listadoCartas();
        }
        #endregion
        
        #region Propieades Públicas
        public clsCarta CartaSeleccionada
        {
            get
            {
                return cartaSeleccionada;
            }
            set
            {
                if(cartaSeleccionada!= value)
                {
                    cartaSeleccionada = value;
                    NotifyPropertyChanged("CartaSeleccionada");
                }              
            }
        }
        public ObservableCollection<clsCarta> ListadoCompletoCartas
        {
            get { return listadoCompletoCartas; }
            set { listadoCompletoCartas = value; }
        }
        #endregion
    }
}
