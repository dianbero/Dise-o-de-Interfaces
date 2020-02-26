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
        private bool isSonando = false;
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
            //Cada segundo suena un sonido de la secuencia
            //Si juegador falla (dar tres oportunidades) se acaba la partida
            hacerSonidos = new DispatcherTimer();
            hacerSonidos.Tick += HacerSonidosIluminarBoton;
            hacerSonidos.Interval = new TimeSpan(0, 0, 1);
            hacerSonidos.Start();

            comandoAbandonarPartida = new DelegateCommand(AbandonarPartidaExecute);          

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que permite abandonar la partida sin terminarla y vuelve a pantalla inicio
        /// Sale mensaje preguntando si abandona partida y los sonidos se paran
        /// Si acepta vuelve a inicio
        /// Si cancela se reinician los sonidos y reanuda la partida
        /// </summary>
        public async void AbandonarPartidaExecute()
        {
            //Para sonidos 
            //tiempoPuntuacion.Stop();
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
                Frame frame = (Frame)Window.Current.Content;

                frame.Navigate(typeof(MainPage));
            }
            else
            {
                //Reanuda sonido 
                //tiempoPuntuacion.Start();
                hacerSonidos.Start();
            }
        }

        //Prueba con DispatcherTimer para iluminar botoner y hacer sonidos aleatorios
        public void HacerSonidosIluminarBoton(object sender, object e)
        {
            /*
             Hacer sonar sonido y cambiar opacidad de botón mientras suena
             */
            int repeticiones = 0;

            clsListadoBotones operacionesListado = new clsListadoBotones();
            ObservableCollection<clsBoton> listaRandom = new ObservableCollection<clsBoton>();

            listaRandom = operacionesListado.GenerarSonidosAleatorios(listaRandom);

            int idListaRandom = listaRandom[repeticiones].Id;
            //Compruebo que los id son iguales
            if (idListaRandom == listadoBotones[idListaRandom].Id)
            {
                //Reproduce el sonido del botón correspondiente
                ReproducirSonido(listadoBotones[idListaRandom].Sonido);
                //TODO implementar lógica para que se ilumine el botón al sonar sonido
            }

            operacionesListado.GenerarSonidosAleatorios(listaRandom);
            
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
