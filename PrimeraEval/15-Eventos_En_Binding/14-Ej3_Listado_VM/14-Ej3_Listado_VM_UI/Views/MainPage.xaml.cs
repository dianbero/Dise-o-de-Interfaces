﻿using _14_Ej3_Listado_VM_UI.ViewModels;
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

namespace _14_Ej3_Listado_VM_UI
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public clsMainPageVM ViewModel { get; }
        public MainPage()
        {
            this.InitializeComponent();
            //Declaro objeto ViewModel
            this.ViewModel = new clsMainPageVM(); //para usarlo en xaml

            //No funciona, no hace nada:
            TextBox tbNombre = FindName("txtNombre") as TextBox;
            TextBox tbApellido = FindName("txtApellido") as TextBox;
            TextBox tbEdad = FindName("txtEdad") as TextBox;

            if (ViewModel.ListadoPersona.Count == 0)
            {
                tbNombre.Text = "";
                tbApellido.Text = "";
                tbEdad.Text = "";
            }
        }

    }
}
