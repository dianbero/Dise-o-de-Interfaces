﻿using System;
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
            
        }

        public void MoveEllipse (object sender, RoutedEvent e)
        {
            dropStar.Begin();
        }
        //private void Star_Moving(object sender, PointerRoutedEventArgs e)
        //{
        //    dropStar.Begin();
        //}

        //public void probandoEllipse(object sender, EventArgs e)
        //{

        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}

        // When the user taps the rectangle, the animation begins.
        //private void Rectangle_Tapped(object sender, PointerRoutedEventArgs e)
        //{
        //    myStoryboard.Begin();
        //}
    }
}
