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
        clsRecogidaDatosVM objVM;
        public RecogidaDatos()
        {
            this.InitializeComponent();
            //Empieza animación
            cambioOpacidad.Begin();

        }

        /// <summary>
        /// Método que recibe los datos enviados desde la vista anterior
        /// </summary>
        /// <param name="e">NavigationEventArgs con los datos de navegación de la página anterior</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            objVM = (clsRecogidaDatosVM)this.DataContext;

            bool diagnosticoObtenido = false;
            
            if(e.Parameter is bool)
            {
                diagnosticoObtenido = (bool)e.Parameter;
                objVM.NuevaPersona.Diagnostico = diagnosticoObtenido;
            }
            //else
            //{
            //    objVM.NuevaPersona.Diagnostico = false;
            //}

            //int recogidaDatos;
            //if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            //{
            //    //Obtengo el código enviado como parámetro
            //    recogidaDatos = Convert.ToInt32(e.Parameter.ToString());
            //    objVM.PorcentajeObtenido = recogidaDatos;
            //    //objVM.CodigoMedico = codigoMedico;
            //}
            //else
            //{
            //    objVM.PorcentajeObtenido = 0;
            //}
            base.OnNavigatedTo(e);
        }

        //Sólo para mayor comodidad de pruebas
        private void BtnPruebasMovimientoQuitarEnFinal_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Preguntas));
        }
    }
}
