using PruebaCRUDXamarin_BL.Lists;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PruebaCRUDXamarin_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsPersona> listadoPersonas;
        private clsPersona personaSeleccionada;
        #endregion

        #region Propiedades Públicas
        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
            set
            {
                listadoPersonas = value;
            }
        }

        public clsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        #endregion

        #region Constructor
        public MainPageVM()
        {
            getListadoPersonas();
        }
        #endregion

        #region Métodos
        public async void getListadoPersonas()
        {
            ObservableCollection<clsPersona> listaPersonas = await new clsListadoPersonasBL().ListadoPersonas();

            listadoPersonas = listaPersonas;
            NotifyPropertyChanged("ListadoPersonas");
            
        }
        #endregion


    }
}
