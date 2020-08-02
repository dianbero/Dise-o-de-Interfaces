using PuntuarCombateMarvelUWP_UI.Views;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PuntuarCombateMarvelUWP_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Método que permite viajar a las distintas páginas ofrecidas en el menú
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args">NavigationViewItemInvokedEventArgs, con los datos del elemento seleccioando</param>
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            switch (args.InvokedItemContainer.Tag.ToString())
            {
                case "puntuarCombate":
                    contentFrame.Navigate(typeof(PuntuarCombate));
                    break;
                case "clasificacion":
                    contentFrame.Navigate(typeof(Clasificacion));
                    break;
            }
        }
    }
}
