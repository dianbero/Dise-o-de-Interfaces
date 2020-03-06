using Proyecto_Juego_Parejas_UI.ViewModels;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Proyecto_Juego_Parejas_UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {

        clsJuegoVM juego;


        public Juego()
        {
            this.InitializeComponent();            
        }

        /// <summary>
        /// Al pulsar una carta realiza un animación de rotación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Storyboard story = (sender as Image).Resources["rotarCarta"] as Storyboard;
            juego = (clsJuegoVM) this.DataContext;
            /*
            1-Falla con juego.CartaSeleccionada.IsVolteada porque es null, por lo que cuando se clican las cartas ya volteadas (cuando hay dos),
            como no tienen valor salta una excepción y si sólo hay una, IsVolteada es true por lo que gira igualmente

            2-Con juego.CartaSeleccionada!=null no gira al haber dos cartas (evito excepción anterior) y si se clica otra después de clicar la última, si no esta última seguiría girando  
            hasta clicar otra, y también al mostrar sólo carta1, sigue girando
            */
            //Solución final para que no haga animación de giro una vez volteada la carta seleccionada:

            //Comprueba que la cartaSeleccionada tiene valor asignado
            if (juego.CartaSeleccionada!=null) {
                //Comprueba que no está volteada y en ese caso puede realizar animación de giro
                if (!juego.CartaSeleccionada.IsVolteada)
                {
                    story.Begin();
                    juego.CartaSeleccionada.IsVolteada = true;
                }
            }
        }

        

    }
}
