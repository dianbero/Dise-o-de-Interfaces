using PuntuarCombateMarvelUWP_BL.Lists;
using PuntuarCombateMarvelUWP_Entities;
using PuntuarCombateMarvelUWP_UI.ModelsExtra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PuntuarCombateMarvelUWP_UI.ViewModels
{
    class clsClasificacionVM
    {
        #region Atributos Privados
        private ObservableCollection<clsLuchador> listadoLuchadores;
        private ObservableCollection<clsLuchadorConFoto> listadoLuchadoresConFoto;
        //private string mensajeError;
        #endregion

        #region Propiedades Públicas 
        public ObservableCollection<clsLuchador> ListadoLuchadores { get => listadoLuchadores; set => listadoLuchadores = value; }
        public ObservableCollection<clsLuchadorConFoto> ListadoLuchadoresConFoto { get => listadoLuchadoresConFoto; set => listadoLuchadoresConFoto = value; }

        //public string MensajeError { get => mensajeError; set => mensajeError = value; }
        #endregion

        #region Constructor
        public clsClasificacionVM()
        {
            getListadoLuchadoresOrdenados();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que obtiene el listado de los luchadores ordenados según el total de sus puntuaciones en todos los combates que han participado
        /// </summary>
        private void getListadoLuchadoresOrdenados()
        {
            try
            {
                // Convertir en uri imagen, usar quizás converter
                listadoLuchadores = new clsListadosLuchadoresBL().getListadoLuchadoresOrdenados();
                listadoLuchadoresConFoto = new ObservableCollection<clsLuchadorConFoto>();

                for (int i = 0; i < listadoLuchadores.Count; i++)
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
            catch (Exception e)
            {
                mostrarMensajeError();
            }
        }

        /// <summary>
        /// Método que muestra mensaje de error de conexión
        /// </summary>
        private async void mostrarMensajeError()
        {
            ContentDialog error = new ContentDialog
            {
                Title = "Error",
                Content = "Se produjo un fallo de conexión",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await error.ShowAsync();

            //Viaja a la página principal
            Frame frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(MainPage));
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
