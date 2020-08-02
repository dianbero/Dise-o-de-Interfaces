using PuntuarCombateMarvelUWP_BL.Handlers;
using PuntuarCombateMarvelUWP_BL.Lists;
using PuntuarCombateMarvelUWP_DAL.ViewModels.ToolsVM;
using PuntuarCombateMarvelUWP_Entities;
using PuntuarCombateMarvelUWP_UI.ModelsExtra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PuntuarCombateMarvelUWP_UI.ViewModels
{
    class clsPuntuarCombateVM : clsVMBase
    {
        #region Atributos Privados
        private DelegateCommand btnEnviarPuntuacion;
        private clsLuchador luchador1Seleccionado;
        //private clsLuchadorConFoto luchador1Seleccionado2;
        private clsLuchador luchador2Seleccionado;
        //private clsLuchadorConFoto luchador2Seleccionado2;
        private int puntuacionLuchador1;
        private int puntuacionLuchador2;
        //private string mensajeError;
        private ObservableCollection<clsLuchador> listadoLuchadores;
        private ObservableCollection<clsLuchadorConFoto> listadoLuchadoresConFoto;
        #endregion

        #region Propiedades Públicas 
        public DelegateCommand BtnEnviarPuntuacion { get => btnEnviarPuntuacion; set => btnEnviarPuntuacion = value; }

        //Aunque los objetos del listado son clsLuchadorConFoto, me acepta que SelectedItem sea clsLuchador:
        public clsLuchador Luchador2Seleccionado { get => luchador2Seleccionado; set => luchador2Seleccionado = value; }
        public clsLuchador Luchador1Seleccionado { get => luchador1Seleccionado; set => luchador1Seleccionado = value; } 
        //public clsLuchadorConFoto Luchador1Seleccionado2{ get => luchador1Seleccionado2; set => luchador1Seleccionado2 = value; }
        //public clsLuchadorConFoto Luchador2Seleccionado2 { get => luchador2Seleccionado2; set => luchador2Seleccionado2 = value; }
        public int PuntuacionLuchador1
        {
            get
            {
                return puntuacionLuchador1;
            }
            set
            {
                puntuacionLuchador1 = value;
                btnEnviarPuntuacion.RaiseCanExecuteChanged();
            }
        }
        public int PuntuacionLuchador2
        {
            get
            {
                return puntuacionLuchador2;
            }
            set
            {
                puntuacionLuchador2 = value;
                btnEnviarPuntuacion.RaiseCanExecuteChanged();
            }
        }
        //public string MensajeError { get => mensajeError; set => mensajeError = value; }
        public ObservableCollection<clsLuchador> ListadoLuchadores { get => listadoLuchadores; set => listadoLuchadores = value; }
        public ObservableCollection<clsLuchadorConFoto> ListadoLuchadoresConFoto { get => listadoLuchadoresConFoto; set => listadoLuchadoresConFoto = value; }


        #endregion

        #region Constructor
        public clsPuntuarCombateVM()
        {
            inicializarElementos();
        }        
        #endregion

        #region Métodos
        /// <summary>
        /// Método que inicializa los elementos del VM para la vista
        /// </summary>
        private void inicializarElementos()
        {
            getListadoLuchadores();
            this.btnEnviarPuntuacion = new DelegateCommand(enviarPuntuacionExecute, enviarPuntuacionCanExecute);
            //this.luchador1Seleccionado = new clsLuchador();
            //this.luchador1Seleccionado = new clsLuchador();

            //Inicializo los ptos a -1, para que no salga ninguna estrella marcada al inicio
            this.puntuacionLuchador1 = -1;
            this.PuntuacionLuchador2 = -1;
        }

        /// <summary>
        /// Método que obtiene el listado de los luchadores
        /// </summary>
        private void getListadoLuchadores()
        {
            try
            {
                listadoLuchadores = new clsListadosLuchadoresBL().getListadoLuchadores();
                listadoLuchadoresConFoto = new ObservableCollection<clsLuchadorConFoto>();

                for(int i = 0; i < listadoLuchadores.Count; i++)
                {
                    //Creo nuevo objeto luchador con foto
                    clsLuchadorConFoto luchadorConFoto = new clsLuchadorConFoto();

                    //Le paso los datos obtenido de la BBDD
                    luchadorConFoto.IdLuchador = listadoLuchadores[i].IdLuchador;
                    luchadorConFoto.NombreLuchador = listadoLuchadores[i].NombreLuchador;
                    luchadorConFoto.FotoLuchador = listadoLuchadores[i].FotoLuchador;
                    convertirArrayAImagen(luchadorConFoto);

                    //Añado el luchador al listado
                    listadoLuchadoresConFoto.Add(luchadorConFoto);
                }

            }
            catch(Exception e)
            {
                //throw e;
                mostrarMensaje("Error", "Se produjo un fallo de conexión");
            }
        }

        /// <summary>
        /// Método que envía los resultados a la BBDD
        /// Lógica:
        /// Si se ha marcado ambos luchadores:
        ///     -Si los luchadores son distintos:
        ///         -Si el combate no existe, lo inserta
        ///         -Si ya existe, actualiza la puntuación de los luchadores
        ///     -Si lo luchadores son el mismo:
        ///         -Muestra mensaje indicándolo
        /// Si no se han marcado ambos luchadores:
        ///     - Muestra mensaje indicándolo
        /// </summary>
        private void enviarPuntuacionExecute()
        {
            clsLuchadorCombate ptoLuchador1 = null;
            clsLuchadorCombate ptoLuchador2 = null;

            try
            {
                //Si se han marcado ambos luchadores
                if(luchador1Seleccionado!=null && luchador2Seleccionado != null)
                {
                    //Si se ha elegido distintos luchadores puede continuar
                    if (!luchador1Seleccionado.Equals(luchador2Seleccionado))
                    {
                        //Comprueba que existe un combate con esos luchadores y la fecha actual
                        DateTime fechaActual = DateTime.Now;
                        int filasAfectadas = new clsHandlerCombatesBL().checkExisteCombate(luchador1Seleccionado.IdLuchador, luchador2Seleccionado.IdLuchador, fechaActual);

                        //Si el combate no existe, lo inserta
                        if (filasAfectadas < 1)
                        {
                            clsCombate nuevoCombate = new clsCombate();
                            nuevoCombate.FechaCombate = fechaActual;

                            //Inserto el nuevo combate y obtiene su id
                            int idCombate = new clsHandlerCombatesBL().insertarCombate(nuevoCombate);

                            //Crea los objetos clsLuchadorCombate para insertar y registrar los luchadores en ese combate
                            ptoLuchador1 = new clsLuchadorCombate(idCombate, luchador1Seleccionado.IdLuchador, puntuacionLuchador1);
                            ptoLuchador2 = new clsLuchadorCombate(idCombate, luchador2Seleccionado.IdLuchador, puntuacionLuchador2);

                            //Registra los luchadores en ese combate
                            int filasLuchador1 = new clsHanlerLuchadoresCombatesBL().insertarLuchadorCombate(ptoLuchador1);
                            int filasLuchador2 = new clsHanlerLuchadoresCombatesBL().insertarLuchadorCombate(ptoLuchador2);

                            if (filasLuchador1 == 1 && filasLuchador2 == 1)
                            {
                                mostrarMensaje("Éxito", "Puntuaciones añadidas correctamente");
                            }
                        }
                        //Si ya existe, actualiza la puntuación de los luchadores
                        else
                        {
                            //Obtengo el id del combate existente
                            int idCombate = new clsListadosCombatesBL().getIdCombate(luchador1Seleccionado.IdLuchador, luchador2Seleccionado.IdLuchador, fechaActual);


                            //Datos de los luchadores
                            ptoLuchador1 = new clsLuchadorCombate(idCombate, luchador1Seleccionado.IdLuchador, puntuacionLuchador1);
                            ptoLuchador2 = new clsLuchadorCombate(idCombate, luchador2Seleccionado.IdLuchador, puntuacionLuchador2);
                            //Actualiza luchador 1
                            int filasLuchador1 = new clsHanlerLuchadoresCombatesBL().actualizarPuntuacionLuchadorCombate(ptoLuchador1);

                            //Actualiza luchador 2
                            int filasLuchador2 = new clsHanlerLuchadoresCombatesBL().actualizarPuntuacionLuchadorCombate(ptoLuchador2);

                            if (filasLuchador1 == 1 && filasLuchador2 == 1)
                            {
                                mostrarMensaje("Éxito", "Puntuaciones añadidas correctamente");
                            }
                        }

                        Frame frame = (Frame)Window.Current.Content;
                        frame.Navigate(typeof(MainPage));

                        ////Resetea los valores
                        //luchador1Seleccionado = null;
                        //luchador2Seleccionado = null;
                        //puntuacionLuchador1 = -1;
                        //puntuacionLuchador2 = -1;

                        //NotifyPropertyChanged("Luchador1Seleccionado");
                        //NotifyPropertyChanged("Luchador2Seleccionado");
                        //NotifyPropertyChanged("PuntuacionLuchador1");
                        //NotifyPropertyChanged("PuntuacionLuchador2");
                    }
                    else
                    {
                        mostrarMensaje("Error", "Debe elegir luchadores distintos");
                    }
                }
                else
                {
                    mostrarMensaje("Error", "Debe indicar ambos luchadores");
                }               
            }
            catch(Exception e)
            {
                //throw e;
                mostrarMensaje("Error", "Se produjo un fallo de conexión");
            }
            
        }

        /// <summary>
        /// Método que habilita el botón de enviar puntuación si se han indicado las puntuaciones de los dos luchadores de un combate
        /// </summary>
        /// <returns>bool botonHabilitado, indicando si se puede habilitar o no</returns>
        private bool enviarPuntuacionCanExecute()
        {
            bool botonHabilitado = false;

            if(puntuacionLuchador1 > 0 && puntuacionLuchador2 > 0)
            {
                botonHabilitado = true;
            }

            return botonHabilitado;
        }

        /// <summary>
        /// Método que muestra un mensaje según la situación dada
        /// </summary>
        private async void mostrarMensaje(string titulo, string mensaje)
        {
            ContentDialog error = new ContentDialog
            {
                Title = titulo,
                Content = mensaje,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await error.ShowAsync();

            //Si hay un fallo de conexión, muestra mensaje y viaja a la página principal
            if(mensaje.Equals("Se produjo un fallo de conexión"))
            {
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(MainPage));
            }
        }


        /// <summary>
        /// Método que convierte un array de bytes de un objeto clsLuchadorConFoto en Image
        /// </summary>
        /// <param name="luchador">clsLuchadorConFoto luchador</param>
        public async void convertirArrayAImagen(clsLuchadorConFoto luchador)
        {

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    //writer.WriteBytes(vm.ListadoLuchadores[2].FotoLuchador);
                    writer.WriteBytes(luchador.FotoLuchador);
                    await writer.StoreAsync();
                }

                var image = new BitmapImage();
                //await image.SetSourceAsync(stream); //Con esto me saltaba

                image.SetSource(stream); //Con esto me ejecuta lo que viene a continuación, no salta como el otro

                //Paso el objeto BitmapImage al del luchador concreto
                luchador.Imagen = image;
            }
        }
        #endregion
    }
}
