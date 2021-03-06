﻿using SimonGame_BL.Hanlders;
using SimonGame_Entities;
using SimonGame_UI.Models;
using SimonGame_UI.Tools;
using SimonGame_UI.ViewModels.ViewmodelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace SimonGame_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsBoton> listadoBotones;
        private clsBoton botonSeleccionado;
        private DispatcherTimer hacerSonidos;
        private DelegateCommand comandoAbandonarPartida;
        private clsListadoBotones operacionesListado = new clsListadoBotones();
        private clsJugador objJugador;

        private bool tableroHabilitado = false; //Para deshabilitar tablero mientras suenan sonidos, inicialmente estará deshabilitado porque empiezan los sonidos
        private int totalBotonesAcertados = 0; //Para comparar con botón correspondiente (será su ídice de lista) y contar si alcanza el final de la lista para así reiniciar la secuencia
        
        /*Al generarse la lista desde cero, las veces que se repita el método de generar nuevo sonido (lanzado por DispatcherTimer)
         correspondrá al número de la posición del sonido en la lista, es decir: repeticiones = índice lista */
        int repeticiones;
        private ObservableCollection<clsBoton> listaRandom;  //Lista en la que se acumulan los botones generados aleatoriamente
        private int indiceQuitarSeleccionBoton;
        private int repeticionDialog = 0; //Para controlar que no se escriben más de 20 caracteres (máximo en BBDD)
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
                if (tableroHabilitado)
                {
                    botonSeleccionado = value;
                    ComprobarJugada();
                    //NotifyPropertyChanged("BotonSeleccionado");  
                    //indiceQuitarSeleccionBoton = 0;
                    //NotifyPropertyChanged("IndiceQuitarSeleccionBoton");
                }
            }
        }
        public DelegateCommand ComandoAbandonarPartida
        {
            get
            {
                return comandoAbandonarPartida;
            }
        }

        public bool TableroHabilitado
        {
            get
            {
                return tableroHabilitado;
            }
        }

        public int IndiceQuitarSeleccionBoton
        {
            get
            {
                return indiceQuitarSeleccionBoton;
            }
        }
        #endregion

        #region constructor
        public clsJuegoVM()
        {
            listadoBotones = new clsListadoBotones().ListadoBotones();
            comandoAbandonarPartida = new DelegateCommand(AbandonarPartidaExecute);
            listaRandom = new ObservableCollection<clsBoton>();
            objJugador = new clsJugador();


            //Genera un primer sonido
            operacionesListado.GenerarSonidosAleatorios(listaRandom);
            //Al generar un primer sonido, contamos como que se ha generado una repetición (para que corresponda con el índice de la lista)
            repeticiones = 0;

            //Cada segundo suena un sonido de la secuencia
            //Si jugador falla se acaba la partida
            hacerSonidos = new DispatcherTimer();
            hacerSonidos.Tick += HacerSonidosIluminarBoton;
            hacerSonidos.Interval = new TimeSpan(0, 0, 1);
            hacerSonidos.Start();

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que permite abandonar la partida sin terminarla y vuelve a pantalla inicio
        /// Sale mensaje preguntando si abandona partida y los sonidos se paran
        /// Si acepta, vuelve a inicio
        /// Si cancela, se reinician los sonidos y reanuda la partida
        /// </summary>
        public async void AbandonarPartidaExecute()
        {
            //Para sonidos 
            hacerSonidos.Stop();

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
                //Reanuda sonido 
                hacerSonidos.Start();
            }
        }

        /// <summary>
        /// Método que hace sonar los elementos de la secuencia y resalta el elemento correspondiente para identificarlo
        /// Realiza sonido y cambia la opacidad del botón mientras suena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void HacerSonidosIluminarBoton(object sender, object e)
        {
            //Deshabilita Tablero
            tableroHabilitado = false;
            NotifyPropertyChanged("TableroHabilitado");
            
            /*Si las veces que se repite el evento son menores al tamaño de la lista
             sigue reproduciendo los sonidos de la secuencia*/
            if (repeticiones < listaRandom.Count)
            {
                int idListaRandom = listaRandom[repeticiones].Id;
                               
                    ReproducirSonido(listadoBotones[idListaRandom].Sonido);
                    //ReproducirSonido(botonSeleccionado.Sonido); //Hace lo mismo que lo anterior

                    //Cambio opacidad del botón que suena para que se identifique el botón que hay que pulsar
                    //botonSeleccionado.Opacidad = "0.3";
                    listadoBotones[idListaRandom].Opacidad = "0.3";
                    //Retraso el cambio de opacidad para que se note el cambio
                    Task atrasarCambioOpacidad = Task.Delay(700);
                    await atrasarCambioOpacidad.AsAsyncAction();
                    //botonSeleccionado.Opacidad = "1";
                    listadoBotones[idListaRandom].Opacidad = "1";

                repeticiones++;
            }
            //Si llega al final, deja de reproducir sonidos (para que el jugador pueda pulsar)
            else
            {
                hacerSonidos.Stop();
            }

            //Habilito tablero para poder clicar los botones
            tableroHabilitado = true;
            NotifyPropertyChanged("TableroHabilitado");
            //botonSeleccionado = null;

        }

        /// <summary>
        /// Método que reproduce un sonido según la uri pasada por parámetro
        /// </summary>
        /// <param name="uriSonido">Uri del sonido a reproducir</param>
        public void ReproducirSonido(string uriSonido)
        {
            MediaPlayer sound = new MediaPlayer();
            //MediaTimelineController playerController;
            //bool playing;

            Uri uri = new Uri(uriSonido);
            //sound.AutoPlay = false;
            sound.Source = MediaSource.CreateFromUri(uri);

            sound.Play();
        }

        /// <summary>
        /// Método que:
        /// - Comprueba si botonSeleccionado es igual al elemento que corresponde en la secuencia: 
        ///           botonSeleccionado.Id == listadoBotones[botonesAcertados].Id
        ///     - Si acierta (son iguales): suma un punto al total de aciertos (totalBotonesAcertados) y sigue pulsando hasta final de secuencia
        ///                                 Si llega al final (acierta toda la secuencia actual): se añade un nuevo sonido aleatorio y se reinicia la secuencia             
        ///     - Si No Acierta (no son iguales): el juego se para, aparece un contentDialog para introducir nick y lo guarda en la BBDD
        /// </summary>
        public void ComprobarJugada()
        {            
            //Si acierta (id del botonSeleccionado es igual al id del botón correspondiente en la secuencia)
            if(botonSeleccionado.Id == listaRandom[totalBotonesAcertados].Id)
            {
                //TODO mostrar mensaje indicando que acierta, o mostrar puntos (o ambos)
                totalBotonesAcertados++;
                
                //Una vez que ha comprobado que ha acertado, llega al final de la secuencia
                if (totalBotonesAcertados == listaRandom.Count)
                {
                    //Añade un nuevo sonido aleatorio 
                    operacionesListado.GenerarSonidosAleatorios(listaRandom);
                    //Reinicia la secuencia para que vuelva a sonar desde el principio
                    repeticiones = 0;
                    //Al terminar secuencia reinicia el total de aciertos
                    totalBotonesAcertados = 0;
                    //Reinicia el temporizador de DispatcherTimer
                    hacerSonidos.Start();
                }
            }
            //Si falla, se acaba la partida y se guardan los datos
            else
            {
                //Puntuación del jugador obtenida
                objJugador.Aciertos = totalBotonesAcertados;
                //ContentDialog pide nick y guarda en BBDD
                MostrarMensajeFinPartida();
            }

            //Aquí viene la oveja negra del proyecto
            //indiceQuitarSeleccionBoton = -1;
            //NotifyPropertyChanged("IndiceQuitarSeleccionBoton");

            botonSeleccionado = null;
            NotifyPropertyChanged("BotonSeleccionado");

        }

        //ContentDialog Fin de Partida
        /// <summary>
        /// Método que muestra un ContenDialog al final de la partida para que el usuario introduzca su nick y se guarde
        /// en la BD de forma que aparezca en el ranking
        /// </summary>
        public async void MostrarMensajeFinPartida()
        {
            //Se para el sonido
            hacerSonidos.Stop();
            //Creo TextBox para introducir nombre de usuario
            TextBox input = new TextBox();
            input.Height = (double)App.Current.Resources["TextControlThemeMinHeight"];

            //Si se repite el contentDialog porque se pasaron los 20 caracteres, cambia el mensaje de placeholder
            if (repeticionDialog < 1)
            {
                input.PlaceholderText = "Introduce tu nick";
            }
            else
            {
                input.PlaceholderText = "Nick debe ser menor a 20 caracteres";
            }

            ContentDialog dialog = new ContentDialog()
            {
                Title = "¡¡¡Fin de la partida!!!",
                PrimaryButtonText = "Guardar",
                //Asigno como contenido el TextBox para introducir nick de usuario
                Content = input
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                //Si supera 20 caracteres (máximo en BD)
                if (input.Text.Length <= 20)
                {
                    //Volver a inicio 
                    Frame frame = (Frame)Window.Current.Content;

                    frame.Navigate(typeof(MainPage));

                    //Asigno a objJugador el nick del jugador actual
                    //Si no escribe nada se le asigna como anónimo
                    if (input.Text.Equals(""))
                    {
                        objJugador.NombreJugador = "Anonimo";
                    }
                    else
                    {
                        objJugador.NombreJugador = input.Text;
                    }
                    //Guardo nick y puntuación del jugador en BD
                    try
                    {
                        clsOperacionesJugadorBL operacionBL = new clsOperacionesJugadorBL();
                        operacionBL.InsertNuevoJugador(objJugador);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else
                {
                    repeticionDialog++;
                    //Repite mensaje al pasar de 20 caracteres
                    MostrarMensajeFinPartida();
                }
            }
        }
        #endregion

    }
}
