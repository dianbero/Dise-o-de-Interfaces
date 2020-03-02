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
        //TODO añadir Command para navegación de página, en el método del command hacer la navegación al pulsar el botón de volver al menú y parar la música al volver

        #region Atributos Privados
        private ObservableCollection<clsBoton> listadoBotones;
        private clsBoton botonSeleccionado;
        private DispatcherTimer hacerSonidos;
        private DelegateCommand comandoAbandonarPartida;

        /*Al generarse la lista desde cero, las veces que se repita el método de generar nuevo sonido (lanzado por DispatcherTimer)
         correspondrá al número de la posición del sonido en la lista, es decir: repeticiones = índice lista */
        int repeticiones = 0;
        ObservableCollection<clsBoton> listaRandom;
        //clsListadoBotones operacionesListado;

       
        //Lista en la que se acumulan los botones generados aleatoriamente
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
                NotifyPropertyChanged("BotonSeleccionado");

            }
        }
        public DelegateCommand ComandoAbandonarPartida
        {
            get
            {
                return comandoAbandonarPartida;
            }
        }
        #endregion

        #region constructor
        public clsJuegoVM()
        {
            listadoBotones = new clsListadoBotones().ListadoBotones();
            comandoAbandonarPartida = new DelegateCommand(AbandonarPartidaExecute);
            listaRandom = new ObservableCollection<clsBoton>();

            //Cada segundo suena un sonido de la secuencia
            //Si jugador falla (dar tres oportunidades) se acaba la partida
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

        //Prueba con DispatcherTimer para iluminar botoner y hacer sonidos aleatorios
        public async void HacerSonidosIluminarBoton(object sender, object e)
        {
            /*
             Hacer sonar sonido y cambiar opacidad de botón mientras suena
             */

            clsListadoBotones operacionesListado = new clsListadoBotones();
            
            //Añado un nuevo sonido aleatorio a la lista
            /*listaRandom =*/ operacionesListado.GenerarSonidosAleatorios(listaRandom);

            int idListaRandom = listaRandom[repeticiones].Id;

            if(botonSeleccionado!= listadoBotones[idListaRandom]) //Esta comprobación creo que es innecesaria
            {
                botonSeleccionado = listadoBotones[idListaRandom];


                ReproducirSonido(listadoBotones[idListaRandom].Sonido);
                //Cambio opacidad del botón que suena para que se identifique el botón que hay que pulsar
                botonSeleccionado.Opacidad = "0.3";   
                //Retraso el cambio de opacidad para que se note el cambio
                Task atrasarCambioOpacidad = Task.Delay(700);
                await atrasarCambioOpacidad.AsAsyncAction();
                botonSeleccionado.Opacidad = "1";
            }
            

            
            //botonSeleccionado.Opacidad = "1";

            //operacionesListado.GenerarSonidosAleatorios(listaRandom);

            ////Compruebo que los id son iguales para comprobar que el botón pulsado es el que corresponde al orden de secuencia
            //if (idListaRandom == listadoBotones[idListaRandom].Id)
            //{
            //    //Reproduce el sonido del botón correspondiente
            //    ReproducirSonido(listadoBotones[idListaRandom].Sonido);
            //    //TODO implementar lógica para que se ilumine el botón al sonar sonido
            //}


            repeticiones++;
        }

        public void ReproducirSonido(string uriSonido)
        {
            MediaPlayer sound = new MediaPlayer();
            //MediaTimelineController playerController;
            //bool playing;

            Uri uri = new Uri(uriSonido);
            sound.AutoPlay = false;
            sound.Source = MediaSource.CreateFromUri(uri);

            //if (playing)
            //{
            //sound.Source = null;
            //    sound.Pause();
            //    playing = false;
            //}
            //else
            //{
            sound.Play();

            //    playing = true;
            //}
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
