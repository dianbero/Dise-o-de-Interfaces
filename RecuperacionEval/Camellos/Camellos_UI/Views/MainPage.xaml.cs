using Camellos_UI.ViewModels;
using Camellos_UI.ViewModels.VMTools;
using Camellos_UI.Views;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Camellos_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private clsLoginVM vm = null;
        public MainPage()
        {
            this.InitializeComponent();
            vm = (clsLoginVM)this.DataContext;
        }

        //private void BtnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Menu));
        //}

        /// <summary>
        /// Método que permite introducir los datos de los campos pulsando la tecla Intro 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Nick_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                vm.entrarExecute();
            }
        }

    }
}
