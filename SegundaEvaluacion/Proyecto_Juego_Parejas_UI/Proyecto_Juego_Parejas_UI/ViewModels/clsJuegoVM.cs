using Proyecto_Juego_Parejas_BL.Hanlders;
using Proyecto_Juego_Parejas_DAL.Utiles;
using Proyecto_Juego_Parejas_Entities;
using Proyecto_Juego_Parejas_UI.ViewModels.JuegoVMTools;
using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;

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
        private string tiempoAMostrar = "Good Luck!!!";
        private DateTime tiempoAMostrarFecha = new DateTime(1754, 1, 1, 0, 0, 0); //Fecha a partir de la cual no lanza excepción
        private int cartasAcertadas = 0;
        private DelegateCommand commandAbandonarPartida;

        //Intentos fallidos
        //Al final no hace falta
        //public bool puedeVoltear;
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
                        //puedeVoltear = true;
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

        public DispatcherTimer TiempoPuntuacion
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

        public DelegateCommand CommandAbandonarPartida
        {
            get
            {                
                return commandAbandonarPartida;
            }
            set
            {
                commandAbandonarPartida = value;
            }
        }

        public clsCarta Carta1
        {
            get
            {
                return carta1;
            }
        }

        //public bool PuedeVoltear
        //{
        //    get
        //    {
        //        return puedeVoltear;
        //    }
        //    set
        //    {
        //        puedeVoltear = value;
        //    }
        //}

        #endregion

        #region Constructores
        public clsJuegoVM()
        {
            //Relleno la lista de cartas
            clsListadoCompletoCartas listadoCartas = new clsListadoCompletoCartas();
            listadoCompletoCartas = listadoCartas.ListadoCompletoCartasEnCasilla();
            //El tablero inicialmente está habilitado
            tableroHabilitado = true;
            //Instancia el jugador de la partida
            objJugador = new clsJugador();
            commandAbandonarPartida = new DelegateCommand(ComprobarSalirPartida);

            //Cosas del DispatcherTimer
            tiempoPuntuacion = new DispatcherTimer();
            tiempoPuntuacion.Tick += MostrarTiempo;
            tiempoPuntuacion.Interval = new TimeSpan(0, 0, 1);
            //Empieza a contar el tiempo al comenzar la partida         
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
            //Está comentado porque se le asigna valor en codigoBehind para control de animación de giro
            //cartaSeleccionada.IsVolteada = true; 
            //Si es la primera carta
            //Siempre se muestra inicialmente la carta (isVolteada = true) (sea correcta o no)      
            if (carta1 == null)
            {
                carta1 = cartaSeleccionada;
            }
            //Si es la segunda carta:
            //- Se le asinga valor de cartaSeleccionada
            //- Se comprueba si carta1 y carta2 son iguales
            else 
            {
                carta2 = cartaSeleccionada;
                //Al ser la segunda carta, carta1 y carta2 ya tienen valor asignado (por lo que no saltará NullPointerException)
                //Bloqueo el tablero mientras se comprueban las cartas
                tableroHabilitado = false;
                NotifyPropertyChanged("TableroHabilitado");
                //Compruebo las cartas:
                //Si son iguales
                if (carta1.IdCarta == carta2.IdCarta)
                {
                    //Anulo las cartas por lo que el jugador puede seguir clicando otras cartas y verlas
                    carta1 = null;
                    carta2 = null;
                    //Al ser iguales, acierta y suma un punto
                    cartasAcertadas++;
                }
                //Si no son iguales
                else
                {
                    //Atraso volteo para mirar las cartas erróneas                 
                    Task atrasarVolteo = Task.Delay(500);
                    await atrasarVolteo.AsAsyncAction();

                    clsSegundaAnimacionCarta animacion = new clsSegundaAnimacionCarta();
                    //animacion.RotarCartaAgain(cartaSeleccionada);
                    //Tras el tiempo vuelvo a ocultar las cartas
                    carta1.IsVolteada = false;
                    carta2.IsVolteada = false;
                    //Asigno las cartas a null para poder volver a asignarle el valor a las nuevas cartas clicadas
                    carta1 = null;
                    carta2 = null;
                    //Intento que se deseleccione la carta para poder volver a clicar seguidamente
                    cartaSeleccionada = null;
                    NotifyPropertyChanged("CartaSeleccionada");                    
                    //No notifico el cambio de IsVolteada de las cartas, porque ya lo notifican las propias cartas en su set
                }
                //Vuelvo a habilitar el tablero una vez comprobadas la cartas
                tableroHabilitado = true;
                NotifyPropertyChanged("TableroHabilitado");
                if(cartasAcertadas == 6)
                {
                    //Asigno puntuación de jugador justo al terminar partida
                    objJugador.Puntuacion = tiempoAMostrarFecha;
                    MostrarMensajeFinPartida();                   
                }
            }
        }

        /// <summary>
        /// Método que se ejecuta cada segundo e indica el tiempo que pasa durante la partida.
        /// (Evento lanzado por DispatcherTimer)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MostrarTiempo(object sender, object e)
        {
            //Añade un segundo en cada reptición            
            tiempoAMostrarFecha = tiempoAMostrarFecha.AddSeconds(1);            

            //Conversión de DateTime a formato mm:ss en string
            tiempoAMostrar = tiempoAMostrarFecha.ToString("mm:ss");
            NotifyPropertyChanged("TiempoAMostrar");            
        }

        /// <summary>
        /// Método que muestra mensaje preguntando si desea abandonar la partida 
        /// y volver al menú principal o seguir jungando
        /// </summary>
        private async void ComprobarSalirPartida()
        {
            //Para tiempo 
            tiempoPuntuacion.Stop();

            ContentDialog comprobarSalirPartida = new ContentDialog
            {
                Title = "Seguro que desea salir?",
                Content = "Si sale se perderán los datos de la partida",
                PrimaryButtonText = "Abandonar Partida",
                CloseButtonText = "Seguir Jugando"
            };

            ContentDialogResult resultado = await comprobarSalirPartida.ShowAsync();

            //Si pulsa abandonar partida, vuelve al inicio
            if (resultado == ContentDialogResult.Primary)
            {   
                //Instancia un elemento Page 
                Frame frame = (Frame) Window.Current.Content;
               
                frame.Navigate(typeof(MainPage));
            }
            else
            {
                //Reanuda tiempo 
                tiempoPuntuacion.Start();
            }
        }

        //ContentDialog Fin de Partida
        /// <summary>
        /// Método que muestra un ContenDialog al final de la partida para que el usuario introduzca su nick y se guarde
        /// en la BD de forma que aparezca en el ranking
        /// </summary>
        public async void MostrarMensajeFinPartida()
        {
            /*Help for InputDialog:
             *https://comentsys.wordpress.com/2018/05/04/uwp-input-dialog/
             */

            //Se para el tiempo
            tiempoPuntuacion.Stop();
            //Creo TextBox para introducir nombre de usuario
            TextBox input = new TextBox();
            input.Height = (double)App.Current.Resources["TextControlThemeMinHeight"];
            input.PlaceholderText = "Introduce tu nick";

            ContentDialog dialog = new ContentDialog()
            {
                Title = "¡¡¡Fin de la partida!!!",
                PrimaryButtonText = "Guardar",     
                //Asigno como contenido el TextBox para introducir nick de usuario
                Content = input
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                //input = (TextBox)dialog.Content;
                //await new Windows.UI.Popups.MessageDialog($"Enhorabuena {input.Text}!!!").ShowAsync();
                
                //Volver a inicio 
                Frame frame = (Frame)Window.Current.Content;

                frame.Navigate(typeof(MainPage)); 
            }

            //Asigno a objJugador el nick del jugador actual
            objJugador.NombreJugador = input.Text;
            //Guardo nick y puntuación del jugador en BD
            clsOperacionesJugadorBL operacionBL = new clsOperacionesJugadorBL();            
            operacionBL.InsertNuevoJugador(objJugador);
        }

        #endregion


    }
}
