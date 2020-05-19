using Camellos_BL.Handlers;
using Camellos_Entities;
using Camellos_UI.Models;
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

namespace Camellos_UI.ViewModels
{
    public class clsProgresoVM
    {

        #region Atributos Privados
        private int idJugadorRegistrado;
        private DelegateCommand btnVolverAMenu;
        private ObservableCollection<clsPruebasJugadores> listaPruebasJugador;
        //private ObservableCollection<DateTime> listaTiemposMaxPruebas;
        private ObservableCollection<clsElementosProgreso> listaElementosProgreso;
        private Frame frame;
        #endregion

        #region Propiedades Públicas
        public int IdJugadorRegistrado
        {
            set
            {
                idJugadorRegistrado = value;
                cargarListaProgreso();
            }
        }
        public DelegateCommand BtnVolverAMenu { get => btnVolverAMenu; set => btnVolverAMenu = value; }
        public ObservableCollection<clsPruebasJugadores> ListaPruebasJugador { get => listaPruebasJugador; set => listaPruebasJugador = value; }
        //public ObservableCollection<DateTime> ListaTiemposMaxPruebas { get => listaTiemposMaxPruebas; set => listaTiemposMaxPruebas = value; }
        public ObservableCollection<clsElementosProgreso> ListaElementosProgreso { get => listaElementosProgreso; set => listaElementosProgreso = value; }
        #endregion

        #region Contructor
        public clsProgresoVM()
        {
            this.btnVolverAMenu = new DelegateCommand(volverExecute);
            this.frame = (Frame)Window.Current.Content;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que obtiene el listado del progreso del jugador registrado
        /// </summary>
        private void cargarListaProgreso()
        {
            clsPrueba pruebaAux;
            clsElementosProgreso objProgresoAux;
            this.listaElementosProgreso = new ObservableCollection<clsElementosProgreso>();
            try
            {
                //Obtengo la lista de los objetos clsPruebasJugadores
                listaPruebasJugador = new clsHandlerProgresosBL().getProgresoJugador(idJugadorRegistrado);
                //Si tiene progresos, los muestra
                if (listaPruebasJugador.Count != 0)
                {
                    //Obtengo la lista de los tiempos
                    for (int i = 0; i < listaPruebasJugador.Count; i++)
                    {
                        pruebaAux = new clsHandlerPruebasBL().getPrueba(listaPruebasJugador[i].IdPrueba); //TODO revisar esto, no sé si mejor obtener todas las pruebas del tirón, creo que no porque no voy a querer todas las pruebas, sino sólo aquellas que ha superado el jugador
                                                                                                          //listaTiemposMaxPruebas.Add(pruebaAux.TiempoMax); //Esto es residuo de cuando no tenía la clase clsElementosProgreso

                        //Paso los elementos obtenidos a la clase que los contendrá todos, necesarios para el GridView de la lista
                        objProgresoAux = new clsElementosProgreso(listaPruebasJugador[i].IdJugador, listaPruebasJugador[i].IdPrueba, listaPruebasJugador[i].TiempoJugador, pruebaAux.TiempoMax);
                        //Paso ese objeto a la lista con todos los objetos obtenidos
                        listaElementosProgreso.Add(objProgresoAux);
                    }
                }
                //Si no tiene progresos, muestra mensaje indicándolo
                else
                {
                    mostrarMensajeNoTieneProgresos();
                }
                
            }
            catch (Exception e)
            {
                mostrarMensajeError();
            }
        }

        /// <summary>
        /// Método que navega a la página de menu enviando como parámetro el idJugadorRegistrado
        /// </summary>
        private void volverExecute()
        {
            frame.Navigate(typeof(Menu), idJugadorRegistrado);
        }

        /// <summary>
        /// Método que en caso de que no haya registros de progreso, muestra mensaje indicándolo
        /// </summary>
        private async void mostrarMensajeNoTieneProgresos()
        {
            ContentDialog mensajeError = new ContentDialog
            {
                Title = "Ningún progreso registrado",
                //Content = mensaje,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeError.ShowAsync();

            //Vuelve a la pantalla de menu
            frame.Navigate(typeof(Menu), idJugadorRegistrado);
        }

        /// <summary>
        /// Método que muestra un mensaje de error de fallo de conexión
        /// </summary>
        private async void mostrarMensajeError()
        {
            ContentDialog mensajeError = new ContentDialog
            {
                Title = "Se produjo un fallo de conexión",
                //Content = mensaje,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeError.ShowAsync();
        }
        #endregion
    }
}
