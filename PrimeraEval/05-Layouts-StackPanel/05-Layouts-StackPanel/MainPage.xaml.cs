using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _05_Layouts_StackPanel
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Para que se ajuste a la pantalla
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 20, Height = 20 });
        }

        private void BotonHelloWorld_Click(object sender, RoutedEventArgs e)
        {
            //Para navegar a la página BklankPage en carpeta MasVistas
            this.Frame.Navigate(typeof(MasVistas.PaginaNueva));
        }
    }
}
