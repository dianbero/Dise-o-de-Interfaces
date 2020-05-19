using Camellos_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Camellos_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {
        private clsJuegoVM vm;
        public Juego()
        {
            this.InitializeComponent();
            vm = (clsJuegoVM)this.DataContext;
            //animacionCamello.Begin();
        }

        /// <summary>
        /// Método que obtiene el idJugador pasado como parámetro desde la vista anterior
        /// </summary>
        /// <param name="e">NavigationEventArgs, con los datos de la página anterior</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter is int && (int)e.Parameter != 0)
            {
                //Obtengo el código enviado como parámetro
                //idJugadorRegistrado = Convert.ToInt32(e.Parameter);
                vm.IdJugadorRegistrado = (int)e.Parameter;
            }
            else
            {
                vm.IdJugadorRegistrado = 0;
            }
            base.OnNavigatedTo(e);
        }

        //private void BtnabandonarPartida_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Menu));
        //}

        /// <summary>
        /// Método que se ejecuta al pulsar la tecla intro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PalabraIntroducida_KeyDown(object sender, KeyRoutedEventArgs e)
        {

            if(e.Key == VirtualKey.Enter)
            {
                vm.realizarPartida();
                //BtnCorrer_Click(sender, e);
                /*El buleano*/
                if (vm.PuedeMoverseCamello)
                {
                    animacionCamello.Begin();
                }

            }
            else
            {
                vm.PuedeContarTiempo = true;

            }

            vm.PuedeMoverseCamello = false;
        }

        //private void BtnCorrer_Click(object sender, RoutedEventArgs e)
        //{
        //    vm.realizarPartida();
        //}
    }
}
