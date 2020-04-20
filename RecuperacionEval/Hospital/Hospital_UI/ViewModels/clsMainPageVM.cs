using Hospital_BL.Handlers;
using Hospital_UI.ViewModels.ToolsVM;
using Hospital_UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Hospital_UI.ViewModels
{
    public class clsMainPageVM
    {
        #region Atributos Privados
        private string codigoMedico;
        private DelegateCommand botonEnviar;
        #endregion

        #region Porpiedades Públicas
        public string CodigoMedico {

            set
            {
                codigoMedico = value;
                botonEnviar.RaiseCanExecuteChanged();
            }

        }
        public DelegateCommand BotonEnviar { get => botonEnviar; set => botonEnviar = value; }
        #endregion

        #region Constructor
        public clsMainPageVM()
        {
            this.codigoMedico = "";
            this.botonEnviar = new DelegateCommand(enviarExecute, enviarCanExecute);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que comprueba que el código es válido y en caso de serlo manda el objeto clsMedico obtenido y 
        /// lo manda a la segunda vista y la muestra
        /// Lógica del método:
        /// - Valida código:
        ///     - Si cumple formato:
        ///            -Si existe médico con ese código manda a la vista siguiente
        ///            -Si no existe muestra mensaje indicándolo
        ///     - Si no cumple formato:
        ///         -Muestra mensaje indicándolo
        /// </summary>
        public void enviarExecute()
        {
            //Si código es correcto
            if (validarCodigoEsCorrecto())
            {
                //Compruebo que existe édico asociado a ese código
                if (validarMedicoExiste())
                {
                    Frame frame = (Frame)Window.Current.Content;
                    //Navega a la segunda vista enviándole el codigo como parámetro
                    frame.Navigate(typeof(Tareas), codigoMedico);
                }
                else
                {
                    mostrarMensajeError("No existe médico con el código introducido");
                }
            }
            else
            {
                mostrarMensajeError("Código no correcto");
            }
        }

        /// <summary>
        /// Método que comprueba que el campo del código no está vacío y por tanto se puede pulsar el botón de Enviar
        /// </summary>
        /// <returns>bool hayAlgoEscrito, que indica si se habilita el botón o no</returns>
        private bool enviarCanExecute()
        {
            bool hayAlgoEscrito = false;

            if (!codigoMedico.Equals(""))
            {
                hayAlgoEscrito = true;
            }
            return hayAlgoEscrito;
        }

        /// <summary>
        /// Método indica si el código cumple el formato 000AAA000
        /// </summary>
        /// <returns>bool codigoCorrecto, indicando si cumple o no</returns>
        private bool validarCodigoEsCorrecto()
        {
            bool codigoCorrecto = false;

            if(Regex.IsMatch(codigoMedico, "[0-9]{3}[A-Z]{3}[0-9]{4}"))
            {
                codigoCorrecto = true;
            }

            return codigoCorrecto;
        }

        /// <summary>
        /// Método que comprueba que el médico existe llamando a la BD
        /// </summary>
        /// <returns>bool medicoExiste, indicando si existe</returns>
        private bool validarMedicoExiste()
        {
            bool medicoExiste = false;

            try
            {
                int filasAfectadas = new clsHandlerHospitalBL().checkExisteMedico(codigoMedico);

                if (filasAfectadas == 1)
                {
                    medicoExiste = true;
                }

            }catch(Exception e)
            {
                throw e;
            }           

            return medicoExiste;
        }

        /// <summary>
        /// Método que muestra mensaje de error según el tipo de error que se haya cometido
        /// </summary>
        /// <param name="mensaje"></param>
        private async void mostrarMensajeError(string mensaje)
        {
            ContentDialog mensajeErroneo = new ContentDialog
            {
                Title = "Se produjo un error",
                Content = mensaje,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeErroneo.ShowAsync();
        }

        #endregion
    }
}
