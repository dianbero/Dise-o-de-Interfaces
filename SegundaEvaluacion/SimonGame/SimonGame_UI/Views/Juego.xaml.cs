using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace SimonGame_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {
        //MediaPlayer sound;
        //MediaTimelineController playerController;
        //bool playing;

        public Juego()
        {
            this.InitializeComponent();
            //sound = new MediaPlayer();
            //sound.Source = null;
            
            //playing = false;
        }

        //public void BtnVolver_Click(object sender, RoutedEventArgs e)
        //{
        //    if (playing)
        //    {
        //        sound.Source = null;
        //        playing = false;
        //    }
        //    this.Frame.Navigate(typeof(MainPage));            
        //}

        //private void PruebaSonido_Click(object sender, RoutedEventArgs e)
        //{
        //    //Uri uri = new Uri("ms-appx:///Assets/Sonidos/AllyBrooke-NoGood.mp3");
        //    Uri uri = new Uri("ms-appx:///Assets/Sonidos/coin02.ogg");
        //    sound.AutoPlay = false;
        //    sound.Source = MediaSource.CreateFromUri(uri);

        //    if (playing)
        //    {
        //        //sound.Source = null;
        //        sound.Pause(); 
        //        playing = false;
        //    }
        //    else
        //    { 
        //        sound.Play();
        //        playing = true;
        //    }
        //}



        //private void PruebaSonido_Click(object sender, RoutedEventArgs e)
        //{

        //    //Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets/Sounds");
        //    //Windows.Storage.StorageFile file = await folder.GetFileAsync("AllyBrooke-NoGood.mp3");

        //    Uri uri = new Uri("ms-appx:///Assets/Sonidos/AllyBrooke-NoGood.mp3");
        //    sound.AutoPlay = false;
        //    //sound.Source = MediaSource.CreateFromStorageFile(file);
        //    sound.Source = MediaSource.CreateFromUri(uri);
        //    sound.TimelineController = playerController;

        //    //MediaPlayerElement mediaPlayerElement = new MediaPlayerElement();
        //    //mediaPlayerElement.SetMediaPlayer(sound);

        //    if (playerController.State == MediaTimelineControllerState.Running)
        //    {
        //        //sound.Source = null;
        //        sound.Pause();
        //        playerController.Pause();
        //        //playing = false;
        //    }
        //    else
        //    {
        //        //sound.Play();
        //        playerController.Resume();
        //        playing = true;
        //    }
        //}

        //private void Play_Click(object sender, RoutedEventArgs e)
        //{
        //    //if (!playing)
        //    //{
        //    //    playerController.Start();
        //    //}
        //}


    }
}
