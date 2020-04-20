using Hospital_UI.ViewModels;
using Hospital_UI.ViewModels.ToolsVM;
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

namespace Hospital_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        clsMainPageVM objVM = null;

        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Método que permite introducir el código pulsando la tecla intro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCodigo_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //Identifica la tecla Intro como la tecla pulsada
            if (e.Key == VirtualKey.Enter)
            {
                objVM = (clsMainPageVM)this.DataContext;
                /*Así funciona el intro, no sé si es correcto porque hago que el método enviarExecute sea público y siempre puede ejecutarse 
                 * aunque no haya nada escrito, el elemento que no puede usarse a no ser que se escriba algo es el botón por el command.
                 No sé si tiene sentido pero es la forma que he encontrado para que me funcione al pulsar con intro*/
                objVM.enviarExecute();
            }
        }
    }
}
