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
using Windows.UI;
using Windows.Media.Playback;//Para reproductor
using Windows.Media.Core;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _11_Controles
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //MediaPlayer _mediaPlayer;
        public MainPage()
        {
            this.InitializeComponent();
            //System.Uri manifestUri = new Uri("spotify:playlist:4YWIDk7ryNIout3u9daujl");
            //mediaPlayerElement.Source = MediaSource.CreateFromUri(manifestUri);
            //mediaPlayerElement.MediaPlayer.Play();

        }
        /// <summary>
        /// Método que cambia las características del botón, según el radioButton seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.btnGo.Width = btnGo.ActualWidth;
            //this.btnGo.Height = btnGo.ActualHeight;

            //Brush default = btnGo.Background;
            

            if ((bool)rb1.IsChecked)
            {
                this.btnGo.Width = 20;
                this.btnGo.Height = 20;
                this.btnGo.ClearValue(Button.BackgroundProperty);
            }
            else if((bool)rb2.IsChecked)
            {
                this.btnGo.Background = new SolidColorBrush(Colors.Red);
                this.btnGo.ClearValue(Button.WidthProperty);
                this.btnGo.ClearValue(Button.HeightProperty);
            }
            else //Reestablece características originales del botón
            {
                this.btnGo.ClearValue(Button.BackgroundProperty);
                this.btnGo.ClearValue(Button.WidthProperty);
                this.btnGo.ClearValue(Button.HeightProperty);
            }
        }

        private void BtnToolTipCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pagina2));
        }
    }
}
