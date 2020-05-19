using Camellos_BL.Handlers;
using Camellos_Entities;
using Camellos_UI.ViewModels.VMTools;
using Camellos_UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Camellos_UI.ViewModels
{
    public class clsLoginVM
    {
        #region Atributos Privados
        private string nick;
        private string password;
        private DelegateCommand btnLogin;
        private int idJugador; //Se debe pasar a las demás vistas
        //private string mensajeError; //No uso esto realmente, por eso inicialmente no lo puse en el viewModel
        #endregion

        #region Propiedades Públicas
        public string Nick
        {
            set
            {
                nick = value;
                btnLogin.RaiseCanExecuteChanged();
            }
        }
        public string Password
        {
            set
            {
                password = value;
                btnLogin.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand BtnLogin { get => btnLogin; set => btnLogin = value; }
        public int IdJugador { get => idJugador; set => idJugador = value; }
        #endregion

        #region Contructor
        public clsLoginVM()
        {
            this.idJugador = 0;
            this.nick = "";
            this.password = "";
            this.btnLogin = new DelegateCommand(entrarExecute, entrarCanExecute);
        }       
        #endregion

        #region Métodos        
        /// Método que comprueba si los campos son correctos y permite entrar al jugador si lo son.
        /// Lógica del método:
        /// -Valida campos:
        ///     -Si campos son correctos:
        ///         -Si jugador existe (con nick y contraseña introducidos):
        ///             -Obtiene el idJugador
        ///             -Manda a siguiente pantalla con el idJugador como parámetro
        ///         -Si jugador no existe:
        ///             -Si no existe jugador con el nick introducido:
        ///                 -Muestra mensaje asegurando que quiere usar esos datos
        ///                     -En caso positivo: inserta el nuevo jugador con ese nick y contraseña
        ///             -Si existe jugador con ese nick:
        ///                 -Muestra mensaje de error indicándolo
        ///     -Si campos no son correctos:
        ///         -Muestra mensaje indicándolo
        /// </summary>
        public void entrarExecute()
        {
            //Si los campos son válidos
            if (validarCampos())
            {
                try
                {
                    int filasAfectadas = new clsHandlerJugadoresBL().checkExisteJugador(nick, password);

                    //Obtiene el idJugador del jugador registrado con ese nick
                    idJugador = new clsHandlerJugadoresBL().getIdJugador(nick);

                    //Si el jugador existe, entra a su cuenta
                    if (filasAfectadas == 1) 
                    {
                        //se manda el idJugador nuevo a la vista menu
                        Frame frame = (Frame)Window.Current.Content;
                        frame.Navigate(typeof(Menu), idJugador);
                    }
                    //Si el jugador no existe
                    else
                    {
                        //Si no existe jugador con ese nick, lo inserta
                        if (idJugador == 0)
                        {
                            mostrarMensajeComprobarRegistro(nick, password);
                        }
                        //Si el nick introducido coincide con el nick del jugador de la BBDD (sin coincidir la contraseña), muestra mensaje de que ese nick ya está en uso
                        else  
                        {
                            mostrarMensajeError("El nick introducido ya está en uso, elija otro nick");
                        }  
                    }                    
                }
                catch (Exception e)
                {
                    mostrarMensajeError("Se produjo un fallo de conexión");
                }
            }
            //Si los campos no son válidos
            else
            {
                //Muestra mensaje de error
                mostrarMensajeError("Alguno de los campos no son correctos." +
                    "\n\nEl nick y la contraseña son obligatorios y no deben superar los 25 caracteres.");
            }
            
        }

        /// <summary>
        /// Método que comprueba que los campos no están vacíos y habilita el botón
        /// </summary>
        /// <returns>bool camposTienenTexto, que indica si se puede habilitar el botón o no</returns>
        private bool entrarCanExecute()
        {
            bool camposTienenTexto = false;
            //Si los campos no están vacíos, entonces se activa el botón
            if (!nick.Equals("") && !password.Equals(""))
            {
                camposTienenTexto = true;
            }

            return camposTienenTexto;
        }

        /// <summary>
        /// Método que comprueba que los campos son correctos:
        /// El nick y la contraseña no deben tener más de 25 caracteres (máximo que acepta la BBDD)
        /// </summary>
        /// <returns></returns>
        private bool validarCampos()
        {
            bool camposValidados = false;

            if (validarNick() && validarPassword())
            {
                camposValidados = true;
            }

            return camposValidados;
        }

        /// <summary>
        /// Método que valida el nick:
        /// -Que el campo no esté vacío
        /// -Que no supere 25 caracteres
        /// </summary>
        /// <returns>bool correcto</returns>
        private bool validarNick()
        {
            bool correcto = false;

            if(!nick.Equals("") && nick.Length <= 25)
            {
                correcto = true;
            }

            return correcto;
        }

        /// <summary>
        /// Método que valida la contraseña:
        /// -Que el campo no esté vacío
        /// -Que no supere 25 caracteres
        /// </summary>
        /// <returns>bool correcto</returns>
        private bool validarPassword()
        {
            bool correcto = false;

            if (!password.Equals("") && password.Length <= 25)
            {
                correcto = true;
            }

            return correcto;
        }

        /// <summary>
        /// Método que muestra un mensaje preguntado si desea registrarse con el nick y contraseña introducidos
        /// </summary>
        private async void mostrarMensajeComprobarRegistro(string nick, string password)
        {
            ContentDialog mensajeError = new ContentDialog
            {
                Title = "¿Seguro?",
                Content = $"Seguro que desea usar este nick y contraseña?" +
                $"\n\nNick: {nick}" +
                $"\nContraseña: {password}",
                PrimaryButtonText = "Ok",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await mensajeError.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                //Inserta jugador y obtiene su idJugador
                idJugador = new clsHandlerJugadoresBL().insertarJugador(nick, password);

                //Manda el idJugador nuevo a la vista menu
                Frame frame = (Frame)Window.Current.Content;
                frame.Navigate(typeof(Menu), idJugador);
            }
        }

        /// <summary>
        /// Método que muestra un mensaje de error de fallo de conexión
        /// </summary>
        private async void mostrarMensajeError(string textoMensajeError)
        {
            ContentDialog mensajeError = new ContentDialog
            {
                Title = "Error",
                Content = textoMensajeError,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeError.ShowAsync();
        }

        #endregion
    }
}
