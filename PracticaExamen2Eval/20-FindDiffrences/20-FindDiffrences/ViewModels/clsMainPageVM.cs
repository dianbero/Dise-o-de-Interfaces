using _20_FindDiffrences.Entities;
using _20_FindDiffrences.Utiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _20_FindDiffrences.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        #region Atributos Privados
        private clsCirculo circuloSeleccionado;
        private ObservableCollection<clsCirculo> listaCirculos;
        /*Help:
         https://stackoverflow.com/questions/7177432/how-to-display-items-in-canvas-through-binding
         */

        #endregion

        #region Propiedades Públicas
        public clsCirculo CirculoSeleccionado
        {
            get
            {
                return circuloSeleccionado;
            }
            set
            {
                circuloSeleccionado = value;
                NotifyPropertyChanged("CirculoSeleccionado");
            }
        }

        public ObservableCollection<clsCirculo> ListaCirculos
        {
            get
            {
                return listaCirculos;
            }
            set
            {
                listaCirculos = value;
            }
        }
        #endregion

        #region Constructor
        public clsMainPageVM()
        {
            listaCirculos = clsListaCirculos.listaCirculos();

        }
        #endregion


    }
}
