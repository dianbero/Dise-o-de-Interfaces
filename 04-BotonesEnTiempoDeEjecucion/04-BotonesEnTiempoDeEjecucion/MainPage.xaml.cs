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
using System.Windows;
using Windows.UI.Popups; //Necesario para monstrar ventana emergente con MessageDialog
using Windows.Media.SpeechSynthesis;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _04_BotonesEnTiempoDeEjecucion
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Button boton3;
        //private bool botonPulsado = false;

        public MainPage()
        {
            this.InitializeComponent();
            
            boton3 = new Button();
            //StackPanel stack = new StackPanel();                       

            boton3.Content = "Boton3";
            boton3.Name = "boton3";
            boton3.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            boton3.Height = 70;
            boton3.Width = 200;
            boton3.FontFamily = new FontFamily("Verdana");              
            boton3.FontSize = 16;
            boton3.FontWeight = Windows.UI.Text.FontWeights.Bold;
            boton3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            boton3.HorizontalAlignment = HorizontalAlignment.Center;            
            boton3.VerticalContentAlignment = VerticalAlignment.Center;
            boton3.HorizontalContentAlignment = HorizontalAlignment.Center;
            boton3.Click += Boton3_Click; //Añade evento al hacer click en boton3

            //Añade botón al contenedor stackPanel
            stackpanel.Children.Add(boton3);
        }


        /// <summary>
        /// Método que muestra una ventana emergente que avisa de que el botón 1 ha sido pulsado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Boton1_Click(object sender, RoutedEventArgs e)
        {            
            var messageWindow = new MessageDialog("Has pulsado el botón 1, enhorabuena");
            await messageWindow.ShowAsync();
        }

        /// <summary>
        /// Boton2 lanza un mensaje voz que dice que se ha mostrado el botón 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton2_Click(object sender, RoutedEventArgs e)
        {
            MensajeVoz("Has pulsado el botón 2, enhorabuena");            
        }
        /// <summary>
        /// Boton3 lanza mensaje de voz que dice que se ha mostrado el botón 3 y cambia el color de fondo del botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Boton3_Click(object sender, RoutedEventArgs e)
        {       
                //Cambio color Background
                boton3.Background = new SolidColorBrush(Windows.UI.Colors.MediumPurple);
                //Voz
                MensajeVoz("Has pulsado el botón 3 y has camiado el fondo del botón a color MediumPurple, felicidades");
                   
        }

        /// <summary>
        /// Método para realizar mensaje de voz pasándole la frase correspondiente
        /// </summary>
        /// <param name="frase"></param>
        private async void MensajeVoz(string frase)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(frase);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }

    }
}
