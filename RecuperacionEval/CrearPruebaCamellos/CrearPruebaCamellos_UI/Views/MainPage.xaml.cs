using CrearPruebaCamellos_UI.Models;
using CrearPruebaCamellos_UI.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CrearPruebaCamellos_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private clsMainPageVM vm;

        public clsMainPageVM Vm { get => vm; }

        public MainPage()
        {
            this.InitializeComponent();
            vm = (clsMainPageVM)this.DataContext;
        }
        
        /// <summary>
        /// Método que permite que aparezca un menu contextual al pulsar botón derecho del ratón sobre un elemento del listView
        /// </summary>
        /// <param name="sender">Objeto que envía la acción</param>
        /// <param name="e">Datos del evento asociado al objecto</param>
        private void ListaPalabras_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView listView = (ListView)sender;
            menuContextual.ShowAt(listView, e.GetPosition(listView));
            //Obtengo el elemento seleccionado
            var elementoSeleccionado = ((FrameworkElement)e.OriginalSource).DataContext as clsPalabraConAtributoYaExiste;

            //Asigno el elemento seleccionado a la propiedad PalabraSeleccionada del ViewModel
            vm.PalabraSeleccionada = elementoSeleccionado;
        }
    }
}
