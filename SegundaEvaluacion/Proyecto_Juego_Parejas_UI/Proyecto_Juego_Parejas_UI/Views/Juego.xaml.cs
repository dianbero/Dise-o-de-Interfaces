using Proyecto_Juego_Parejas_UI.ViewModels;
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

namespace Proyecto_Juego_Parejas_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {
       
        public Juego()
        {
            this.InitializeComponent();
        }

        //private void BtnVolver_Click(object sender, RoutedEventArgs e)
        //{            
        //    ComprobarSalirPartida();

        //}        

        ///// <summary>
        ///// Método que muestra mensaje preguntando si desea abandonar la partida 
        ///// y volver al menú principal o seguir jungando
        ///// </summary>
        ///// 
        ////TODO poner en ViewModel y lanzarlo con el executeCommand
        //private async void ComprobarSalirPartida()
        //{
        //    //Parar tiempo DispatcherTimer ...TiempoPuntuacion.Stop()
        //    ContentDialog comprobarSalirPartida = new ContentDialog
        //    {
        //        Title = "Seguro que desea salir?",
        //        Content = "Si sale se perderán los datos de la partida",
        //        PrimaryButtonText = "Abandonar Partida",
        //        CloseButtonText = "Seguir Jugando"
        //    };

        //    ContentDialogResult resultado = await comprobarSalirPartida.ShowAsync();

        //    if (resultado == ContentDialogResult.Primary)
        //    {
        //        this.Frame.Navigate(typeof(MainPage));
        //        //Para hacerlo en Viewmodel:
        //        //Crear objeto Frame con Window.Current.Content as ... o algo así (buscar)
        //        //Con eso puedo usar el navigate y en teoría hacerlo de la misma forma que arriba
        //        //Porque son métodos de Frame
        //    }
        //    else
        //    {
        //        //Reanudar tiempo (DispatcherTimer)  ...TimenpoPuntuacion.Start()
        //    }
        //}
    }
}
