using PruebaCRUDXamarin_BL.Handlers;
using PruebaCRUDXamarin_BL.Lists;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaCRUDXamarin_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsPersona> listadoPersonas;
        private clsPersona personaSeleccionada;
        private DelegateCommand comandoEnviar;
        private DelegateCommand comandoDetalles;
        private DelegateCommand comandoBorrar;
        private DelegateCommand comandoActualizar;
        private bool personaIsSeleccionada; //Para comprobar CanExecute de Borrar, Actualizar y Detalles
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
            comandoEnviar = new DelegateCommand(CrearPersonaExecute);
            //comandoDetalles = new DelegateCommand(DetallesPersonaExecute, DetallesCanExecute);
            //comandoBorrar = new DelegateCommand(EliminarPersonaExecute, EliminarCanExecute);
            //comandoActualizar = new DelegateCommand(ActualizarPersonaExecute, ActualizarCanExecute);

        }
        #endregion

        #region Métodos
        public async void getListadoPersonas()
        {
            ObservableCollection<clsPersona> listaPersonas = await new clsListadoPersonasBL().ListadoPersonas();

            listadoPersonas = listaPersonas;
            NotifyPropertyChanged("ListadoPersonas");            
        }

        #region Add Persona
        /// <summary>
        /// Método que inserta una nueva persona
        /// </summary>
        public async void CrearPersonaExecute()
        {
            //Navegar a ViewModel Crear Persona (Execute)

            //NavigationPage navPage = new NavigationPage(new MainPageVM());
            //Application.Current.MainPage = navPage;

            //await navPage.PushAsync(new InsertarVM());

            //Application.Current.MainPage.Navigation.PushAsync(InsertarVM);


        }
        #endregion

        #region Detalles Persona
        //Navegar a ViewModel Detalles Persona (Execute y CanExecute)
        #endregion

        #region Eliminar Persona
        //Comando eliminar persona (Execute y CanExecute)
        #endregion

        #region Actualizar Persona
        //Navegar a ViewModel Actualizar Persona (Execute y CanExecute)
        #endregion


        #endregion

        /*
         Para navegación:
         Xamarin.Forms.Application.Current.MainPage....
         xamarin.forms.application.current.mainpage.navigation.pushasync
         
         https://docs.microsoft.com/es-es/xamarin/xamarin-forms/app-fundamentals/navigation/hierarchical
         */

    }
}
