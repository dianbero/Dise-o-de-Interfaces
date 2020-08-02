using PuntuarCombateMarvelUWP_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PuntuarCombateMarvelUWP_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PuntuarCombate : Page
    {
        private clsPuntuarCombateVM vm;
        private ObservableCollection<ListViewItem> items = new ObservableCollection<ListViewItem>();
        //internal clsPuntuarCombateVM Vm { get => vm; set => vm = value; }
        

        public PuntuarCombate()
        {
            this.InitializeComponent();
            vm = (clsPuntuarCombateVM)this.DataContext;

            //for (int i = 0; i < vm.ListadoLuchadoresConFoto.Count; i++)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.Content = vm.ListadoLuchadoresConFoto[i].Imagen;
            //    items.Add(item);

            //    listaLuchadores2.Items.Add(item);                

            //}

            //listaLuchadores2.ItemsSource = items;

            ////listaLuchadores2.SelectedItem = vm.Luchador2Seleccionado2;
            //listaLuchadores2.SelectedItem = vm.Luchador2Seleccionado;



        }

    }
}
