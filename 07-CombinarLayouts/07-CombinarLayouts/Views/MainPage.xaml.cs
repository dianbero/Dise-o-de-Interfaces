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
using _07_CombinarLayouts.Models;


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

        /// <summary>
        /// Botón para mandar datos del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clsPersona objPersona = new clsPersona();

            objPersona.Nombre = txtName.Text;
            objPersona.Apellido = txtSurname.Text;
            //objPersona.DateBirth = txtDateBirth.Text;

            DateTime dateBirth;
            
            //TODO falta comprobar que la fecha no es superior a la actual
            //Para poner una fecha igual a null hay que poner después del tipo de la variable un signo de interrogación
            if (String.IsNullOrEmpty(txtDateBirth.Text))
            {
                lblDateBirth.Text = "Debe introducir una fecha";                
            }else if(DateTime.TryParse(txtDateBirth.Text, out dateBirth))
            {
                objPersona.DateBirth = dateBirth;
                lblDateBirth.Text = "";
            }   
            
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

            lblResultadoFinal.Text = $"{objPersona.Nombre}, {objPersona.Apellido}, {objPersona.DateBirth.ToString("dd / MM / yyyy")}";  //Para mostrar sólo fecha no sirve .Date



            /*if (String.IsNullOrWhiteSpace(objPersona.DateBirth))
            {
                lblDateBirth.Text = "Debe introducir una fecha";
            }
            else
            {
                lblDateBirth.Text = "";
            }*/
        }
    }
}
