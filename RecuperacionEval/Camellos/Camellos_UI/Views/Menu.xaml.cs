using Camellos_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Menu : Page
    {
        private clsMenuVM vm;
        public Menu()
        {
            this.InitializeComponent();
            vm = (clsMenuVM)this.DataContext;
        }

        /// <summary>
        /// Método que obtiene el idJugador pasado como parámetro desde la vista anterior
        /// </summary>
        /// <param name="e">NavigationEventArgs, con los datos de la página anterior</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            int idJugadorRegistrado = 0;

            
            if(e.Parameter is int && (int)e.Parameter != 0)
            {
                //Obtengo el código enviado como parámetro
                //idJugadorRegistrado = Convert.ToInt32(e.Parameter);
                idJugadorRegistrado = (int)e.Parameter;
                vm.IdJugadorResgistrado = idJugadorRegistrado;
            }
            else
            {
                vm.IdJugadorResgistrado = 0;
            }
            base.OnNavigatedTo(e);
        }

        //private void BtnJugar_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Juego));
        //}

        //private void BtnProgreso_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Progreso));
        //}
    }
}
