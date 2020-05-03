using Coronavirus_BL.Handlers;
using Coronavirus_Entities;
using Coronavirus_UI.ViewModels.ViewModelTools;
using Coronavirus_UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Coronavirus_UI.ViewModels
{
    public class clsPreguntasVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsRespuesta> listadoRespuestas;
        private clsRespuesta respuestaSeleccionada;
        //private string textoPregunta;
        private string textoBoton;
        private DelegateCommand commandPulsarSiguente;

        private ObservableCollection<clsPregunta> listadoPreguntas;
        private int porcentajeRespuestasPositivas = 0;
        private int numRespuestasPositivas = 0;
        private int contadorPreguntas = 0;
        private clsPregunta preguntaActual;
        
        #endregion

        #region Propiedades Públicas
        public ObservableCollection<clsRespuesta> ListadoRespuestas
        {
            get
            {
                return listadoRespuestas;
            }
        }
        
        public clsRespuesta RespuestaSeleccionada
        {
            set
            {
                respuestaSeleccionada = value;
                commandPulsarSiguente.RaiseCanExecuteChanged();
            }
        }

        //public string TextoPregunta
        //{
        //    get
        //    {
        //        return textoPregunta;
        //    }
        //}

        public string TextoBoton
        {
            get
            {
                return textoBoton;
            }
        }

        public DelegateCommand CommandPulsarSiguente
        {
            get
            {
                return commandPulsarSiguente;
            }
            set
            {
                commandPulsarSiguente = value;
            }
        }

        public clsPregunta PreguntaActual
        {
            get
            {
                return preguntaActual;
            }
        }
        #endregion

        #region Constructor
        public clsPreguntasVM()
        {
            //Obtengo todas las preguntas
            //listadoPreguntas = new clsListadoPreguntasBL().getListadoPreguntasBL();
            obtenerListadoPreguntas();
            //asignarPregunta();
            this.textoBoton = "Siguiente";
            //Método que muestra preguntas, en este caso llamaría al iniciar, y se mostraría en primer lugar la primera pregunta de la lista
            this.commandPulsarSiguente = new DelegateCommand(pulsarSiguienteExecute, pulsarSiguienteCanExecute);

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que asigna la siguiente pregunta, según el orden que indica "contadorPregunta" que se habrá aunmentado previamente al pulsar el botón.
        /// Cambia las propiedades públicas correspondientes en la vista.
        /// </summary>
        /// <param name="contadorPregunta">int que indica el orden de las preguntas, es decir el índice de cada pregunta en la lista</param>
        public void asignarPregunta()
        {
            
            //this.textoPregunta = listadoPreguntas[contadorPreguntas].Pregunta;
            //NotifyPropertyChanged("TextoPregunta");
            preguntaActual = listadoPreguntas[contadorPreguntas];
            NotifyPropertyChanged("PreguntaActual");

            //Obtengo la lista de respuestas para la pregunta correspondiente
            try
            {
                //this.listadoRespuestas = new clsListadoRespuestasPorIdPreguntaBL().listadoRespuestasPorIdPregunta(listadoPreguntas[contadorPreguntas].IdPregunta);
                this.listadoRespuestas = new clsListadoRespuestasPorIdPreguntaBL().listadoRespuestasPorIdPregunta(preguntaActual.IdPregunta);
            }
            catch (Exception)
            {
                mensajeError();
            }

            NotifyPropertyChanged("ListadoRespuestas");

            //Si estamos en la última pregunta el texto del botón cambia a "Pulsar Siguiente"
            if(contadorPreguntas == listadoPreguntas.Count - 1)
            {
                this.textoBoton = "Ver Resultados";
                NotifyPropertyChanged("TextoBoton");
            }        
        }

        /// <summary>
        /// Método que obtiene el listado de preguntas de la BD
        /// </summary>
        public void obtenerListadoPreguntas()
        {
            try
            {
                listadoPreguntas = new clsListadoPreguntasBL().getListadoPreguntasBL();
                asignarPregunta();
            }
            catch (Exception)
            {
                mensajeError();
            }
        }

        /// <summary>
        /// Método que comprueba la respuesta seleccionada de una pregunta
        /// Si la respuesta corresponde con "Si" o ">38º" (en el caso de la pregunta 2) entonces:
        ///     el número de respuestas positivas aumenta en 1
        ///     el porcentaje de respuestas es igual al numRespuestasPositivas por 100 entre el total de preguntas de la lista
        /// </summary>
        public void comprobarRespuesta()
        {
            //Si tiene respuesta corresponde con positivo en coronavirus
            if(respuestaSeleccionada.Respuesta =="Si"||respuestaSeleccionada.Respuesta == ">38º")
            {
                numRespuestasPositivas++;
                porcentajeRespuestasPositivas = numRespuestasPositivas * 100 / listadoPreguntas.Count;
            }

            respuestaSeleccionada = null;
        }

        /// <summary>
        /// Método que suma en 1 el contador de pregunta
        /// Si el contador es menor al total de preguntas:
        ///     muestra la siguiente pregunta llamando al método asignarPregunta, que cambia las propiedades de la pregunta correspondiente en la vista
        ///     
        ///         (Si se trata de la última pregunta, el botón tendrá un nombre distinto cambiado previamente en asignarPregunta, 
        ///         y cuando se pulse cambiará la vista a la de recogida de datos)
        /// Si No:
        ///     Cambia la vista a la de Recogida de datos
        /// </summary>
        public void pulsarSiguienteExecute()
        {
            bool tieneCoronavirus = false; 

            contadorPreguntas++;

            //Si la pregunta no es la última, entonces muestra la siguiente pregunta
            if (contadorPreguntas < listadoPreguntas.Count)
            {
                comprobarRespuesta();
                asignarPregunta();
            }
            //Si es la última, entonces cambia la vista
            else
            {
                //Comprueba el diagnóstico en función del porcentaje
                if (porcentajeRespuestasPositivas > 70)
                {
                    tieneCoronavirus = true;
                }

                Frame frame = (Frame)Window.Current.Content;

                //string porcentaje = Convert.ToString(porcentajeRespuestasPositivas);

                frame.Navigate(typeof(RecogidaDatos), tieneCoronavirus);
                //frame.Navigate(typeof(RecogidaDatos), porcentaje); //Paso parámetro para que lo reciba el otro viewModel
            }
        }

        /// <summary>
        /// Método que comprueba si se puede pulsar el botón, comprobando que hay una respuesta seleccionada.
        /// Habrá respuesta seleccionada si, respuestaSeleccionada tiene algún valor, es decir, es distinto a null.
        /// </summary>
        /// <returns>bool hayRespuestaSeleccionada, indica si hay una respuesta seleccionada</returns>
        public bool pulsarSiguienteCanExecute()
        {
            bool hayRespuestaSeleccionada = false;

            if (respuestaSeleccionada != null)
            {
                hayRespuestaSeleccionada = true;
            }

            return hayRespuestaSeleccionada;
        }

        /// <summary>
        /// Método que muestra mensaje de error
        /// </summary>
        private async void mensajeError()
        {
            ContentDialog mensajeEnviarDatos = new ContentDialog()
            {
                Title = "Error de conexión",
                CloseButtonText = "Ok"
            };

            await mensajeEnviarDatos.ShowAsync();
        }

        #endregion
    }

}
