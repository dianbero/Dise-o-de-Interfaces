using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_HolaMundoWindowsForms_CSharp
{
    public partial class FrmHolaMundo : Form
    {
        public FrmHolaMundo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al clic del botón saludar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaludo_Click(object sender, EventArgs e)
        {
            clsPersona objPersona = new clsPersona();
            //Recoge campo de textBox
            objPersona.Nombre = txtNombre.Text;
            objPersona.Apellido = txtApellido.Text;
            objPersona.Edad = Convert.ToInt32(txtEdad.Text); //Hago conversión porque el atributo edad es de tipo int
            //objPersona.Edad = Int32.Parse(txtEdad.Text);


            //Mostrar mensaje
            //MessageBox.Show("Hola " + nombre);

            //Otra forma de mostrar mensaje
            //MessageBox.Show($"Hola {nombre}");

           
            //Comprobar casilla Nombre
            if (String.IsNullOrWhiteSpace(objPersona.Nombre))
            {
                MessageBox.Show("Debe introducir un nombre");
            }
            else if (String.IsNullOrWhiteSpace(objPersona.Apellido)) //Comprobar casilla Apellido
            {
                MessageBox.Show("Debe introducir un apellido");
            }
            else if (String.IsNullOrWhiteSpace(Convert.ToString(objPersona.Edad))) //Convierte edad a string para comprobar si de ha introducido
            {
                MessageBox.Show("Debe introducir una edad");
            }
            else 
            {
                MessageBox.Show($"{objPersona.Nombre} {objPersona.Apellido} tiene {objPersona.Edad} años de edad");
            }
                       
                       

            //Opción para conrtolar qué radioButton se ha pulsado
            

            


        }
        //No tiene acción porque es sólo una etiqueta para indicar  dónde introducir el apellido
        

        

        

       
    }
}
