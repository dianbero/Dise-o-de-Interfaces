using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using Entidades;


namespace TextoNarrador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Botón que al ser clicado hace que el narrador lea los datos introducidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            clsPersona objPersona = new clsPersona();

            objPersona.Nombre = txtNombre.Text;
            objPersona.Apellido = txtApellido.Text;

            //TODO activar speech Windows para leer mensaje
            SpeechSynthesizer narrador = new SpeechSynthesizer(); //Acceso a motor de voz
            narrador.SetOutputToDefaultAudioDevice(); //Lleva la salida del texto al dispositivo de audio predeterminado
            //narrador.Speak(txtHablar.Text);

            //Modificar validación para que en los if haga comprobación e instancie booleano de validado y la frase a decir
            if (String.IsNullOrWhiteSpace(objPersona.Nombre))
            {
                narrador.Speak("Debe introducir un nombre");
            }else if (String.IsNullOrWhiteSpace(objPersona.Apellido))
            {
                narrador.Speak("Debe introducir un apellido");
            }else
            {
                narrador.Speak($"Hola {objPersona.Nombre} {objPersona.Apellido}");
            }
        }
        
    }
}
