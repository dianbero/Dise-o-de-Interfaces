using Camellos_BL.Handlers;
using Camellos_Entities;
using Camellos_UI.ViewModels.VMTools;
using Camellos_UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Camellos_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Atributos Privados
        //Con bindeo
        private clsPrueba pruebaActual;
        private ObservableCollection<clsPrueba> listadoCompletoPruebas;
        private ObservableCollection<clsPalabra> listadoPalabrasPorPrueba; 
        private int contadorTurnoPrueba; //Contador que se corresponde con la posición de la prueba la lista de pruebas obtenida
        //private string palabraActual;
        private clsPalabra palabraActual;
        private string palabraIntroducida;
        private DelegateCommand btnAbandonarPartida;
        private DelegateCommand introducirPalabra;
        private int distanciaFrom;
        private int distanciaTo;
        private string tiempoMostrado;
        private int datoDistanciaTotal;
        private string textoPalabraMal;
        private DateTime tiempoAMostrarSinFormatear;
        private string colorMensajeAcierto;
        private TimeSpan duracionAnimacion;

        //Sin bindeo
        private int desplazamientoTotal;
        private string mensajePartida;
        private int idJugadorRegistrado;
        private DispatcherTimer tiempoPartida;
        private int sumaDificultades = 0;
        private bool puedeContarTiempo;
        private int idUltimaPruebaJugador;
        private bool puedeMoverseCamello;
        private int posicionImagen;
        //private Storyboard moverCamelloAnimacion;
        //private DoubleAnimation doubleAnimation;
        #endregion

        #region Propiedades Públicas
        public clsPrueba PruebaActual { get => pruebaActual; set => pruebaActual = value; }
        //public string PalabraActual { get => palabraActual; }
        public string PalabraIntroducida { get => palabraIntroducida; set => palabraIntroducida = value; }
        public DelegateCommand BtnAbandonarPartida { get => btnAbandonarPartida; set => btnAbandonarPartida = value; }
        public int DistanciaFrom { get => distanciaFrom; set => distanciaFrom = value; }
        public int DistanciaTo { get => distanciaTo; set => distanciaTo = value; }
        //public int DesplazamientoTotal { get => desplazamientoTotal; set => desplazamientoTotal = value; }
        //public string MensajePartida { get => mensajePartida; set => mensajePartida = value; }
        public int IdJugadorRegistrado
        {
            set
            {
                idJugadorRegistrado = value;

                inicializarElementos();
            }
        }
        public string TiempoMostrado { get => tiempoMostrado; set => tiempoMostrado = value; }
        public clsPalabra PalabraActual { get => palabraActual; }
        public string TextoPalabraMal { get => textoPalabraMal; }
        public DelegateCommand IntroducirPalabra { get => introducirPalabra; }
        public bool PuedeContarTiempo
        {
            set
            {
                puedeContarTiempo = value;
                //prepararDispatcherTimer();
                //Empezar dispatcherTimer
                if (!tiempoPartida.IsEnabled && puedeContarTiempo)
                {
                    cambiarTextoPalabraMalOBien("Go!!!", "Pink");

                    tiempoPartida.Start();
                }
                
            }
        }

        public string ColorMensajeAcierto { get => colorMensajeAcierto; set => colorMensajeAcierto = value; }
        public bool PuedeMoverseCamello { get => puedeMoverseCamello; set => puedeMoverseCamello = value; }
        public TimeSpan DuracionAnimacion { get => duracionAnimacion; set => duracionAnimacion = value; }
        public int PosicionImagen { get => posicionImagen; set => posicionImagen = value; }


        //public ObservableCollection<clsPrueba> ListadoCompletoPruebas { get => listadoCompletoPruebas; set => listadoCompletoPruebas = value; } //No lo necesito para bindeo, por tanto no tengo por qué hacerle las propiedades
        #endregion

        #region Contructor
        public clsJuegoVM()
        {
            

        }
        #endregion

        #region Métodos

        public void inicializarElementos()
        {

            posicionImagen = 1250;
            //prepararAnimacion();

            this.tiempoAMostrarSinFormatear = new DateTime(1754, 1, 1, 0, 0, 0);
            this.contadorTurnoPrueba = 0;
            duracionAnimacion = new TimeSpan(0, 0, 1);

            prepararDispatcherTimer();
            try
            {
                this.listadoCompletoPruebas = new clsHandlerPruebasBL().getListadoCompletoPruebas();
                this.idUltimaPruebaJugador = new clsHandlerPruebasBL().getUltimaPruebaJugador(idJugadorRegistrado);

            }
            catch (Exception e)
            {
                //Mensaje de fallo de conexión
                mensajeFalloConexion();
            }


            if (contadorTurnoPrueba < listadoCompletoPruebas.Count)
            {
                
                ObtenerUltimaPruebaJugador();
                //Instancio la palabra actual a la primera palabra de la lista
                prepararDatosPartidaActual();

                this.palabraActual = new clsPalabra();

                //Inicialmente dintanciaFrom será la misma que la distancia total
                this.datoDistanciaTotal = 1250;
                this.distanciaTo = 1250;

                this.colorMensajeAcierto = "Pink";
                this.puedeMoverseCamello = false;


                //Calcula suma de dificultades, para cálculo
                calcularTotalDificultadesPalabras();

                obtenerPalabraActual(); 

                this.btnAbandonarPartida = new DelegateCommand(mostrarMensajeComprobarSalirExecute);
                this.introducirPalabra = new DelegateCommand(realizarPartida);
                                            
                
            }
   
        }

        /// <summary>
        /// Método que cambia el texto donde se indica si la palabra introducida está bien o mal,
        /// también muestra la prueba en la que se está y mensaje indicando que el tiempo empieza a correr
        /// cuando se pulsa teclado (Go!!!)
        /// </summary>
        /// <param name="texto">string con texto que se desea mostrar</param>
        /// <param name="color">string con el color que tendrá ese texto</param>
        private async void cambiarTextoPalabraMalOBien(string texto, string color)
        {
            textoPalabraMal = texto;
            colorMensajeAcierto = color;
            NotifyPropertyChanged("TextoPalabraMal");
            NotifyPropertyChanged("ColorMensajeAcierto");
            Task duracionmensajeMal = Task.Delay(1000);
            await duracionmensajeMal.AsAsyncAction();
            textoPalabraMal = "";
            colorMensajeAcierto = "";
            NotifyPropertyChanged("TextoPalabraMal");
            NotifyPropertyChanged("ColorMensajeAcierto");
        }


        /// <summary>
        /// Método con toda la lógica de la partida:
        ///     -Comprueba que el campo no está vacío
        ///     -Si no ha terminado la partida:         
        ///         -Si palabra escrita es igual a la que se muestra en pantalla:
        ///             -Calcula distancia camello y permite iniciar animación        ///             
        ///             -Si es la última palabra prepara los datos para la siguiente prueba
        ///         
        ///      -Si no quedan pruebas, muestra mensaje indicando que se ha terminado la partida
        ///     
        /// </summary>
        public async void realizarPartida()
        {
            int desplazamientoPorPalabra = 0;
            bool hayFallo = false; //Para poder tener dos contentDialog y poder mostrarlos  en función de la situación (si no, da fallo)
                                   


            distanciaFrom = distanciaTo;

            NotifyPropertyChanged("DistanciaFrom");

            if (!palabraIntroducida.Equals(""))
            {
                //Si el contador no supera el tamaño del listado (porque si no da error), es decir, mientras queden pruebas (si no ha terminado partida)
                if (contadorTurnoPrueba < listadoCompletoPruebas.Count)
                {    
                    if (listadoPalabrasPorPrueba.Count != -1) //Si quedan palabras (si no ha terminado la prueba)
                    {
                        if (palabraIntroducida.Equals(palabraActual.Palabra))
                        {
                            //Muestra mensaje indicando que se ha acertado

                            cambiarTextoPalabraMalOBien("Bien!!!", "SpringGreen");
                                
                            //Calculo el desplazamiento de la palabraActual
                            desplazamientoPorPalabra = palabraActual.Dificultad * datoDistanciaTotal / sumaDificultades;
                                                       
                            distanciaTo = distanciaFrom - desplazamientoPorPalabra;

                            NotifyPropertyChanged("DistanciaTo");

                            //Inicia animación y la nueva distanciaFrom pasa a ser la que ha sido distanciaTo (que volverá a cambiar para la siguiente palabra)

                                
                            //Indico que puede iniciarse animación de camello
                            puedeMoverseCamello = true;
                            
                        //Si es la última palabra, la inserta 
                        if (listadoPalabrasPorPrueba.Count == 0)
                        {
                            try
                            {
                                clsPruebasJugadores progresoActual = new clsPruebasJugadores(idJugadorRegistrado, listadoCompletoPruebas[contadorTurnoPrueba].IdPrueba, tiempoAMostrarSinFormatear);

                                new clsHandlerProgresosBL().insertarProgreso(progresoActual);

                            }
                            catch (Exception e)
                            {
                                //Controlo con buleano que no salte excepción de mostrar dos contentDialog a la vez
                                hayFallo = true;
                            }


                            if (hayFallo)
                            {
                                mensajeFalloConexion();
                            }
                            else
                            {
                                //Esto tal y como está actualmente creo que ni lo hace                                       
                                if (contadorTurnoPrueba != listadoCompletoPruebas.Count - 1)
                                {
                                    mensajeFinDePartida("Enhorabuena!!!", "Has superado la prueba");
                                }

                                    
                                //Aumento contador prueba para pasar a la siguiente
                                contadorTurnoPrueba++;

                                prepararDatosPartidaActual();

                                //obtenerPalabraActual();

                                sumaDificultades = 0;

                                //Vuelve a obtener la dificultad
                                calcularTotalDificultadesPalabras();
                            }

                        }

                            obtenerPalabraActual();

                        }
                        else
                        {
                            //muestra mensaje indicando que la ha escrito mal 
                            cambiarTextoPalabraMalOBien("Mal!!!", "Red");
                        }
                    }
                                               
                }
                //else
                //{
                //    //Vuelve al menú
                //    Frame frame = (Frame)Window.Current.Content;
                //    frame.Navigate(typeof(Menu), idJugadorRegistrado);


                //    mensajeFinDePartida("Enhorabuena!!!", "Has terminado la partida");
                //}

            }


        }

        /// <summary>
        /// Método que muestra mensaje indicando que se ha producido un fallo de conexión
        /// </summary>
        private async void mensajeFalloConexion()
        {
            //Paro el tiempo
            tiempoPartida.Stop();

            ContentDialog mensajeFalloConexion = new ContentDialog
            {
                Title = "Error",
                Content = "Se produjo un fallo de conexión",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeFalloConexion.ShowAsync();

            //Viaja a página de inicio
            Frame frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Menu), idJugadorRegistrado);

        }

        /// <summary>
        /// Método que muestra mensaje indicado que ha superado la prueba
        /// </summary>
        private async void mensajeFinDePartida(string titulo, string mensaje)
        {
            //Para el tiempo
            tiempoPartida.Stop();

            ContentDialog mensajeFinPartida = new ContentDialog
            {
                Title = titulo,
                Content = mensaje,
                //PrimaryButtonText = "Ok",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeFinPartida.ShowAsync();

            if(titulo.Equals("Ya te has pasado el juego"))
            {
                //Vuelve al menú
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(Menu), idJugadorRegistrado);
            }
            else
            {
                //Reinicia el tiempo
                tiempoAMostrarSinFormatear = new DateTime(1754, 1, 1, 0, 0, 0);

                tiempoMostrado = tiempoAMostrarSinFormatear.ToString("mm:ss");

                NotifyPropertyChanged("TiempoMostrado");

                textoPalabraMal = $"Prueba {pruebaActual.IdPrueba}";
                colorMensajeAcierto = "Pink";
                NotifyPropertyChanged("TextoPalabraMal");
                NotifyPropertyChanged("ColorMensajeAcierto");
            }            
        }

        /// <summary>
        /// Método que obtiene el total de las dificultades de las palabras.
        /// Esto se utilizará para el cálculo de la distancia que recorre el camello.
        /// </summary>
        private void calcularTotalDificultadesPalabras()
        {
            if (listadoPalabrasPorPrueba != null)
            {
                //Obtengo la suma de las dificultades de las palabras
                for (int i = 0; i < listadoPalabrasPorPrueba.Count; i++)
                {
                    sumaDificultades += listadoPalabrasPorPrueba[i].Dificultad;
                }
            }
        }

        /// <summary>
        /// Método que obtiene la palabra que debe escribir en ese momento el jugador, 
        /// que se mostrará en pantalla.
        /// </summary>
        private void obtenerPalabraActual()
        {
           
            if (listadoPalabrasPorPrueba!=null && listadoPalabrasPorPrueba.Count!=0) //Para que no salte error de indexOutOfRange
            {
                //Vacía la palabra introducida
                palabraIntroducida = "";
                NotifyPropertyChanged("PalabraIntroducida");

                Random rdm = new Random();
                int random;
                
                random = rdm.Next(0, listadoPalabrasPorPrueba.Count);
                palabraActual = listadoPalabrasPorPrueba[random];

                NotifyPropertyChanged("PalabraActual");
                //Quita elementos para evitar repetición de palabras
                listadoPalabrasPorPrueba.RemoveAt(random);

            }
        }

        /// <summary>
        /// Método que comprueba cuál es la última prueba que ha hecho el jugador o si es nuevo, 
        /// y devuelve el contador con la posición que tiene la prueba en el listado completo de pruebas.
        /// Si es nuevo, empieza la partida desde el principio.
        /// Si no es nuevo, continúa la partida por donde la dejó.      
        /// </summary>
        /// <returns>int contador, con posición de la prueba en el listado completo de pruebas</returns>
        private void ObtenerUltimaPruebaJugador()
        {
            if (idUltimaPruebaJugador != 0)
            {
                //Obtiene la última prueba registrada
                for (int i = 0; i < listadoCompletoPruebas.Count; i++)
                {
                    if (idUltimaPruebaJugador == listadoCompletoPruebas[i].IdPrueba)
                    {                        
                        contadorTurnoPrueba = i;
                    }
                }
                
                //Le suma 1 para obtener la prueba siguiente a la última registrada
                contadorTurnoPrueba++;

            }
        }

        /// <summary>
        /// Método que carga los datos de los elementos que serán necesarios en el turno correspondiente.
        /// Carga la prueba del turno correspondiente y la lista de palabras de esa prueba.
        /// </summary>
        private void prepararDatosPartidaActual()
        {
            //Coloca la imagen al principio
            posicionImagen = 1250;
            NotifyPropertyChanged("PosicionImagen");

            //Al inicio la distanciaFrom será la distanciaTo (es lioso, porque parece al contrario, pero es porque mi configuración de la vista está en sentido contrario)
            distanciaTo = datoDistanciaTotal;
            distanciaFrom = distanciaTo;

            NotifyPropertyChanged("DistanciaFrom");
            NotifyPropertyChanged("DistanciaTo");

            //Obtengo la prueba del turno correspondiente
            if (contadorTurnoPrueba < listadoCompletoPruebas.Count)
            {
                pruebaActual = listadoCompletoPruebas[contadorTurnoPrueba];

                this.textoPalabraMal = $"Prueba {pruebaActual.IdPrueba}";
                //Obtengo las palabras de esa prueba con su idPrueba
                try
                {
                    listadoPalabrasPorPrueba = new clsHandlerPalabrasBL().getPalabrasPorIdPrueba(pruebaActual.IdPrueba);
                }
                catch (Exception e)
                {
                    //Mensaje fallo de conexión
                    mensajeFalloConexion();
                }
            }
            else
            {
                //Mostrar mensaje de partida terminada
                mensajeFinDePartida("Ya te has pasado el juego", "");
            }

        }

        /// <summary>
        /// Método que prepara los elementos del DispatcherTimer que hace que transcurra el tiempo
        /// </summary>
        private void prepararDispatcherTimer()
        {
            this.tiempoMostrado = "00:00";
            
            this.tiempoPartida = new DispatcherTimer();
            tiempoPartida.Tick += EventoMostrarTiempo;
            tiempoPartida.Interval = new TimeSpan(0, 0, 1);

        }

        /// <summary>
        /// Método lanzado por DispatcherTimer que muestra el tiempo por intervalos de un segundo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventoMostrarTiempo(object sender, object e)
        {           

            //Paso a TimeSpan las fechas con sólo el tiempo
            TimeSpan tiempoMostrar = new TimeSpan(tiempoAMostrarSinFormatear.Hour, tiempoAMostrarSinFormatear.Minute, tiempoAMostrarSinFormatear.Second);
            TimeSpan tiempoPruebaActual = new TimeSpan(pruebaActual.TiempoMax.Hour, pruebaActual.TiempoMax.Minute, pruebaActual.TiempoMax.Second);


            //if (tiempoAMostrarSinFormatear < pruebaActual.TiempoMax)
            if (tiempoMostrar < tiempoPruebaActual)
            {
                //Añade un segundo en cada reptición            
                tiempoAMostrarSinFormatear = tiempoAMostrarSinFormatear.AddSeconds(1);

                //Conversión de DateTime a formato mm:ss en string
                tiempoMostrado = tiempoAMostrarSinFormatear.ToString("mm:ss");

                NotifyPropertyChanged("TiempoMostrado"); //Notifica cada vez que cambia
            }
            else
            {
                //Para el tiempo
                tiempoPartida.Stop();
                mensajeFinDePartida("Oh, oh...", "Se acabó el tiempo!!");
                tiempoAMostrarSinFormatear = new DateTime(1754, 1, 1, 0, 0, 0);
                prepararDatosPartidaActual();
                obtenerPalabraActual();
            }
            
                       
        }

        /// <summary>
        /// Método que muestra mensaje comprobando que el jugador quiere abandonar partida.
        /// En caso afirmativo, se vuelve al menu inicio
        /// </summary>
        private async void mostrarMensajeComprobarSalirExecute()
        {
            //Pauso el tiempo para que no corra mientras muestro el mensaje
            tiempoPartida.Stop();

            ContentDialog mensajeError = new ContentDialog
            {
                Title = "¿Abandonar partida?",
                Content = "Se perderán los datos de la partida actual",
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await mensajeError.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                //Viaja a página de inicio
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(Menu), idJugadorRegistrado);
            }
            else
            {
                //Si no abandona la partida, se reanuda el tiempo
                tiempoPartida.Start();
            }
        }
        #endregion


    }
}
