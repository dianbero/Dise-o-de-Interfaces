using SimonGame_UI.Models;
using SimonGame_UI.Tools;
using SimonGame_UI.ViewModels.ViewmodelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace SimonGame_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsBoton> listadoBotones;
        private clsBoton botonSeleccionado;
        DispatcherTimer hacerSonidos;
        #endregion

        #region Propiedades Públicas
        public ObservableCollection<clsBoton> ListadoBotones
        {
            get
            {
                return listadoBotones;
            }
        }

        public clsBoton BotonSeleccionado
        {
            get
            {
                return botonSeleccionado;
            }
            set
            {
                botonSeleccionado = value;
            }
        }
        #endregion

        #region constructor
        public clsJuegoVM()
        {
            listadoBotones = new clsListadoBotones().ListadoBotones();
            //Cada dos segundos(ver tiempo correcto) suena un sonido de la secuencia
            //Si falla se debe reiniciar
            hacerSonidos = new DispatcherTimer();
            //hacerSonidos.Tick += new EventHandler(HacerSonidosIluminarBoton);
            hacerSonidos.Interval = new TimeSpan(0, 0, 2);

            hacerSonidos.Start();                        
        }
        #endregion

        #region Métodos

        //Prueba con DispatcherTimer para iluminar botoner y hacer sonidos aleatorios
        public void HacerSonidosIluminarBoton(object sender, EventArgs e)
        {
            
        }


        //public void HacerSonidosIluminarBoton(object sender, EventArgs e)
        //{
        //    /*
        //     Muestra un primer sonido
        //     Si el jugador ha acertado, muestra otro sonido aleatorio (comprueba si id del boton pulsado = id del boton del orden correspondiente)
        //     Si no acierta, el juego se para (DispatcherTimer Stop())
        //     y guarda la puntuación en BD (Esto seguramente vaya fuera del método, y después)
        //     */
        //}
        #endregion

    }
}
