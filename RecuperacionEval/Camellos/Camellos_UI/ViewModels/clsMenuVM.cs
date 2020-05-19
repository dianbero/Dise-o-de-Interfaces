using Camellos_UI.ViewModels.VMTools;
using Camellos_UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Camellos_UI.ViewModels
{
    public class clsMenuVM
    {
        #region Atributos Privados
        private int idJugadorResgistrado;
        private DelegateCommand btnJugar;
        private DelegateCommand btnVerProgreso;
        private DelegateCommand btnSalir;
        private Frame frame;
        #endregion

        #region Propiedades Públicas
        public int IdJugadorResgistrado
        {
            set
            {
                idJugadorResgistrado = value;
                //cargarElementos();
            }
        }
        public DelegateCommand BtnJugar { get => btnJugar; set => btnJugar = value; }
        public DelegateCommand BtnVerProgreso { get => btnVerProgreso; set => btnVerProgreso = value; }
        public DelegateCommand BtnSalir { get => btnSalir; set => btnSalir = value; }
        #endregion

        #region Contructor
        public clsMenuVM()
        {
            cargarElementos();
        }       
        #endregion

        #region Métodos
        private void cargarElementos()
        {
            this.frame = (Frame)Window.Current.Content;
            this.btnJugar = new DelegateCommand(jugarExecute);
            this.btnVerProgreso = new DelegateCommand(verProgresoExecute);
            this.btnSalir = new DelegateCommand(salirExectue);
        }

        /// <summary>
        /// Método que permite viajar a la pantalla de juego, con el id del jugador registrado
        /// </summary>
        private void jugarExecute()
        {
            frame.Navigate(typeof(Juego), idJugadorResgistrado);
        }

        /// <summary>
        /// Método que permite viajar a la pantalla de progresos del jugador registrado
        /// </summary>
        private void verProgresoExecute()
        {
            frame.Navigate(typeof(Progreso), idJugadorResgistrado);
        }

        /// <summary>
        /// Método que permite que el jugador cierre su sesión
        /// </summary>
        private void salirExectue()
        {
            //Poner mensaje de seguro que desea salir
            mostrarMensajeComprobarSalir();
        }

        /// <summary>
        /// Mensaje que comprueba si el jugador quiere salir de su cuenta
        /// </summary>
        private async void mostrarMensajeComprobarSalir()
        {
            ContentDialog mensajeError = new ContentDialog
            {
                Title = "¿Seguro?",
                Content = "¿Seguro que desea salir de su cuenta?",
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await mensajeError.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                //Viaja a página de inicio
                frame.Navigate(typeof(MainPage));
            }
        }
        #endregion
    }
}
