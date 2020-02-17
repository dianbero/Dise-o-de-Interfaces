using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace _01_HolaMundo_WebForms.WebForms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Models.clsPersona objPersona = new Models.clsPersona();
            objPersona.Nombre = txtNombre.Text;
            objPersona.Apellido = txtApellido.Text;
            objPersona.Edad = ;

            if (String.IsNullOrEmpty(objPersona.Nombre))
            {
                lblSaludo.Text = $"Debe introducir un nombre";
                lblSaludo.Visible = true;
            }
            else if (String.IsNullOrEmpty(objPersona.Apellido)){
                lblSaludo.Text = $"Debe introducir un apellido";
                lblSaludo.Visible = true;
            }
            else if (String.IsNullOrEmpty(objPersona.Edad))
            {
                lblSaludo.Text = $"debe introducir una edad";
            }
            else
            {
                lblSaludo.Text = $"Hola {objPersona.Nombre} {objPersona.Apellido}";
                lblSaludo.Visible = true;
            }
            
        }

        /*protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }*/
    }
}