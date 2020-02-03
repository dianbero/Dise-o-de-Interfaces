using Proyecto_Juego_Parejas_DAL.Utiles;
using Proyecto_Juego_Parejas_Entities;
using Proyecto_Juego_Parejas_UI.Utiles;
using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Proyecto_Juego_Parejas_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Atributos Privados
        private clsCarta cartaSeleccionada;// sustituir en carta1 y carta2
        /*Al seleccionar carta2 se comprueba si son iguales*/
        private clsCarta carta1;
        private clsCarta carta2;
        private clsJugador objJugador;
        private ObservableCollection<clsCarta> listadoCompletoCartas;
        private DispatcherTimer tiempoPuntuacion;
        //private DispatcherTimer tiempoVolteoCarta;
        private bool tableroHabilitado;
        private string tiempoAMostrar = "Hola tiempo";
        private DateTime tiempoAMostrarFecha = new DateTime(1,1,1,0,0,0);
        private int cartasAcertadas = 0;

        #endregion

        #region Propiedades Públicas       
        public clsCarta CartaSeleccionada
        {
            get
            {
                return cartaSeleccionada;
            }
            set
            {
                //Si el tablero está habilitado, se le asigna el valor de cartaSeleccionada a la carta clicada
                if (tableroHabilitado)
                {
                    cartaSeleccionada = value;
                    /*Para que una carta ya volteada no vuelva a ocultarse al clicarla
                     * (estará volteada porque se ha encontrado su pareja)*/
                    if (cartaSeleccionada.IsVolteada)
                    {
                        //Si está volteada le quito la selección (no le asigno ningún valor)
                        cartaSeleccionada = null;
                    }
                    else
                    {
                        ComprobarJugada();
                    }
                }            
            }
        }               

        public ObservableCollection<clsCarta> ListadoCompletoCartas
        {
            get { return listadoCompletoCartas; }
            set { listadoCompletoCartas = value; }
        }

        private DispatcherTimer TiempoPuntuacion
        {
            get
            {
                return tiempoPuntuacion;
            }
        }
        
        public string TiempoAMostrar
        {
            get
            {
                return tiempoAMostrar;
            }
            set
            {
                tiempoAMostrar = value;
                //NotifyPropertyChanged("TiempoAMostrar");
            }
        }

        //De solo lectura porque se le cambia el valor dentro del ViewModel, fuera sólo se accede a él
        public bool TableroHabilitado
        {
            get
            {
                return tableroHabilitado; 
            }
        }

        #endregion

        #region Constructores
        public clsJuegoVM()
        {
            clsListadoCompletoCartas listadoCartas = new clsListadoCompletoCartas();
            //listadoCompletoCartas = listadoCartas.ListadoCompletoCartasEnCasilla();
            listadoCompletoCartas = listadoCartas.listadoCartas();
            //El tablero inicialmente está habilitado
            tableroHabilitado = true;

            //Cosas del DispatcherTimer
            tiempoPuntuacion = new DispatcherTimer();
            tiempoPuntuacion.Tick += MostrarElementosTiempo;
            tiempoPuntuacion.Interval = new TimeSpan(0, 0, 1);
            //TODO: decidir cuándo empieza el timer, en principio, justo al mostrar la pantalla del juego
            tiempoPuntuacion.Start();
            
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que comprueba la jugada al pulsar las cartas:
        /// - Si las cartas no tienen valor asignado se le asigna a cartaSelecccionada y se voltean para verse
        /// - Una vez volteadas, si ambas cartas son distintas a null comprueba si son iguales con sus id.
        /// - Mientras se comprueban, el tablero de deshabilita, y se vuelve a habilitar una vez comprobadas la cartas
        /// - Tarda un tiempo en habilitar el tablero si las cartas son erróneas, para que el jugador pueba ver las cartas
        /// </summary>
        private async void ComprobarJugada()
        {            
            //Hago que cartaSeleccionada esté volteada
            cartaSeleccionada.IsVolteada = true;
            //Si es la primera carta
            //Siempre se muestra inicialmente la carta (isVolteada = true) (sea correcta o no)      
            if (carta1 == null)
            {
                carta1 = cartaSeleccionada;
            }
            //Si es la segunda carta
            //Se le asinga valor de cartaSeleccionada
            //Se comprueba si carta1 y carta2 son iguales
            else 
            {
                carta2 = cartaSeleccionada;
                //Al ser la segunda carta, carta1 y carta2 ya tienen valor asignado (por lo que no saltará NullPointerException)
                //Bloqueo el tablero mientras se comprueban las cartas
                tableroHabilitado = false;
                NotifyPropertyChanged("TableroHabilitado");
                //Compruebo las cartas
                if (carta1.IdCarta == carta2.IdCarta)
                {
                    //Anulo las cartas por lo que el jugador puede seguir clicando otras cartas y verlas
                    carta1 = null;
                    carta2 = null;
                    //Al ser iguales, acierta y suma un punto
                    cartasAcertadas++;
                }
                else
                {
                    //Atraso volteo para mirar las cartas erróneas                 
                    Task atrasarVolteo = Task.Delay(400);
                    await atrasarVolteo.AsAsyncAction();
                    //Tras el tiempo vuelvo a ocultar las cartas
                    carta1.IsVolteada = false;
                    carta2.IsVolteada = false;
                    //Asigno las cartas a null para poder volver a asignarle el valor a las nuevas cartas clicadas
                    carta1 = null;
                    carta2 = null;
                    /*TODO: añadir contador para que cuando llegue a 6 se termine la partida y se le asigne al jugador ganador
                     su tiempo como puntuación*/
                    //No notifico el cambio de IsVolteada de las cartas, porque ya lo notifican las propias cartas en su set
                }
                //Vuelvo a habilitar el tablero una vez comprobadas la cartas
                tableroHabilitado = true;
                NotifyPropertyChanged("TableroHabilitado");
                if(cartasAcertadas == 6)
                {
                    //Mostrar mensaje de fin de partida
                    //Asignar tiempoPuntuacion al jugador
                    //objJugador.Putuacion = tiempoAMostrar;
                }
            }
        }

        /// <summary>
        /// Método que se ejecuta cada segundo e indica el tiempo que pasa durante la partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MostrarElementosTiempo(object sender, object e)
        {
            //Añade un segundo en casa reptición
            tiempoAMostrarFecha = tiempoAMostrarFecha.AddSeconds(1);
            //Conversión de DateTime a formato mm:ss en string
            tiempoAMostrar = tiempoAMostrarFecha.ToString("mm:ss");
            NotifyPropertyChanged("TiempoAMostrar");            
        }
        #endregion


    }
}
