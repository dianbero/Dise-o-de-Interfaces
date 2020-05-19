using Hospital_BL.Handlers;
using Hospital_UI.ViewModels;
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

namespace Hospital_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Tareas : Page
    {
        private clsTareasVM tareasVM = null;

        public Tareas()
        {
            this.InitializeComponent();            
        }

        /// <summary>
        /// Método que recibe los datos mandados por la página anterior y obtiene el objeto clsMedico y clsControlDiario
        /// para ese código concreto
        /// </summary>
        /// <param name="e">NavigationEventArgs, con los datos de la página anterior</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tareasVM = (clsTareasVM)this.DataContext;

            string codigoMedico;

            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                //Obtengo el código enviado como parámetro
                codigoMedico = e.Parameter.ToString();

                tareasVM.CodigoMedico = codigoMedico;
            }
            else
            {
                codigoMedico = "";
            }
            base.OnNavigatedTo(e);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
