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

namespace _07_CombinarLayouts
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clsPersona objPersona = new clsPersona();

            objPersona.Nombre = txtName.Text;
            objPersona.Apellido = txtSurname.Text;
            //objPersona.DateBirth = txtDateBirth.Text;

            DateTime dateBirth;
            
            if (String.IsNullOrEmpty(txtDateBirth.Text))
            {
                lblDateBirth.Text = "Debe introducir una fecha";                
            }else if(DateTime.TryParse(txtDateBirth.Text, out dateBirth))
            {
                objPersona.DateBirth = dateBirth;
                lblDateBirth.Text = "";
            }
            

            //objPersona.DateBirth = txtDateBirth;  //Hacer conversión, probar TryParse

            if (String.IsNullOrWhiteSpace(objPersona.Nombre))
            {
                lblName.Text = "Debe introducir el nombre";
            }
            else
            {
                lblName.Text = "";
            }
            if (String.IsNullOrWhiteSpace(objPersona.Apellido))
            {
                lblSurname.Text = "Debe introducir el apellido";
            }
            else
            {
                lblSurname.Text = "";
            }
            /*if (String.IsNullOrWhiteSpace(objPersona.DateBirth))
            {
                lblDateBirth.Text = "Debe introducir una fecha";
            }
            else
            {
                lblDateBirth.Text = "";
            }*/

            lblResultadoFinal.Text = $"{objPersona.Nombre}, {objPersona.Apellido}, {objPersona.DateBirth.ToString("dd / MM / yyyy")}";  //Para mostrar sólo fecha no sirve .Date
            
        }
    }
}
