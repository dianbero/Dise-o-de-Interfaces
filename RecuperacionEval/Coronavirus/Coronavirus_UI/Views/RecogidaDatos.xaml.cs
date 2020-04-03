using Coronavirus_UI.ViewModels;
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

namespace Coronavirus_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class RecogidaDatos : Page
    {
        clsRecogidaDatosVM vm;
        public RecogidaDatos()
        {
            this.InitializeComponent();
            //Prueba
            //vm = (clsRecogidaDatosVM)this.DataContext;

        }

        private void BtnPruebasMovimientoQuitarEnFinal_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Preguntas));
        }

        //int porcetajeObtenido;
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    porcetajeObtenido = Convert.ToInt32(e.Parameter.ToString());
        //    base.OnNavigatedTo(e);
        //}

        //public void establecerMensaje()
        //{
        //    if (porcetajeObtenido > 70)
        //    {
        //        vm.Mensaje = "Llame a alguno de los siguientes números 900 400 061 / 955 545 060";
        //        vm.ColorMensaje = "Red";
        //    }
        //    else
        //    {
        //        vm.Mensaje = "Parece no estar contagiado";
        //        vm.ColorMensaje = "Green";
        //    }

        //    //NotifyPropertyChanged("Mensaje");

        //    //NotifyPropertyChanged("ColorMensaje");

        //}
    }
}
