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

namespace _21_SpaceShipGame
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
                
        public MainPage()
        {
            this.InitializeComponent();
            dropStar.Begin();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1); //comprueba cada milisegundo si se pulsa tecla
            timer.Tick += moverNave; //cada milisegundo realiza esta función
            bool moviendoX = false;
            bool moviendoY = false;
        }

        /// <summary>
        /// Con cada tick se llama al método moverNaveLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void moverNave(object sender, object e)
        {
            moverNaveLoad();
        }
        public void moverNaveLoad()
        {
            double posicionFutura;
            if()
        }

        
    }
}
