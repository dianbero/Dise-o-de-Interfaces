using CrearPruebaCamellos_Entities;
using CrearPruebaCamellos_UI.Models;
using CrearPruebaCamellos_UI.ViewModels.ToolsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_UI.ViewModels
{
    public class clsMainPageVM
    {
        #region Atributos Privados
        //Con Bindeo
        private clsPalabra palabraIntroducida;
        private ObservableCollection<clsPalabraConAtributoYaExiste> listadoPalabras;
        private string tiempoPruebaMostrado;
        private DelegateCommand btnAddPalabra;
        private DelegateCommand btnBorrarPalabra;
        private DelegateCommand btnCrearPrueba;

        //Sin bindeo
        private TimeSpan tiempoPrueba;
        private string mensajeError;
        private clsPalabraConAtributoYaExiste palabraAux;
        #endregion

        #region Propiedades Públicas
        public clsPalabra PalabraIntroducida { get => palabraIntroducida; set => palabraIntroducida = value; }
        public ObservableCollection<clsPalabraConAtributoYaExiste> ListadoPalabras { get => listadoPalabras; set => listadoPalabras = value; }
        public string TiempoPruebaMostrado { get => tiempoPruebaMostrado; set => tiempoPruebaMostrado = value; }
        public DelegateCommand BtnAddPalabra { get => btnAddPalabra; set => btnAddPalabra = value; }
        public DelegateCommand BtnBorrarPalabra { get => btnBorrarPalabra; set => btnBorrarPalabra = value; }
        public DelegateCommand BtnCrearPrueba { get => btnCrearPrueba; set => btnCrearPrueba = value; }
        public TimeSpan TiempoPrueba { get => tiempoPrueba; set => tiempoPrueba = value; }
        public string MensajeError { get => mensajeError; set => mensajeError = value; }
        #endregion

        #region Contructor
        public clsMainPageVM()
        {
            inicializarElementos();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Métodos que inicializa los elementos del ViewModel
        /// </summary>
        private void inicializarElementos()
        {
            this.palabraIntroducida = new clsPalabra();
            //this.listadoPalabras = listadoPalabras;
            //this.tiempoPruebaMostrado = tiempoPruebaMostrado;
            //this.btnAddPalabra = btnAddPalabra;
            //this.btnBorrarPalabra = btnBorrarPalabra;
            //this.btnCrearPrueba = btnCrearPrueba;
            //this.tiempoPrueba = tiempoPrueba;
            //this.mensajeError = mensajeError;
        }
        #endregion
    }
}
