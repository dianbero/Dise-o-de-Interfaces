using Proyecto_Juego_Parejas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Proyecto_Juego_Parejas_UI.ViewModels.JuegoVMTools
{
    public class clsSegundaAnimacionCarta 
    {
        //Storyboard rotarAgain = new Storyboard();

        public void RotarCartaAgain(clsCarta cartaSeleccionada) //No sé si esto va bien 
        {
            Storyboard rotarAgain = new Storyboard();
            DoubleAnimation animacion = new DoubleAnimation();
            animacion.From = 180.0;
            animacion.To = 0.0;
            animacion.Duration = TimeSpan.FromMilliseconds(2);
            Storyboard.SetTargetName(animacion, "carta");
            Storyboard.SetTargetProperty(animacion, "(UIElement.Projection).(PlaneProjection.RotationY)");

            rotarAgain.Begin();
        }
    }
}
