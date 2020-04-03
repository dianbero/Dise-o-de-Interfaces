using Coronavirus_BL.Handlers;
using Coronavirus_Entities;
using Coronavirus_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Coronavirus_UI.ViewModels
{
    public class clsRecogidaDatosVM : Page, INotifyPropertyChanged /*clsVMBase*/ //Esto está así por unas pruebas que estuve haciendo para intentar el intercambio de datos entre viewModels y no resultó
    {
        #region Atributos Privados
        private clsPersona nuevaPersona;
        private string mensaje;
        private string colorMensaje;
        private DelegateCommand commandEnviarDatos;

        //Alternativa a problema de bindear únicamente propiedades de clsPersona, esto funciona
        private string nombre;
        private string apellidos;
        private string dni;
        private string telefono;
        private string direccion;

        #endregion

        #region Propiedades Públicas
        public event PropertyChangedEventHandler PropertyChanged;
        //Como al final no uso la propiedad pública de clsPersona, lo tengo comentado
        //public clsPersona NuevaPersona {
        //    get
        //    {
        //        return nuevaPersona;
        //    }
        //    set
        //    {
        //        nuevaPersona = value;
        //    }
        //}
        public string Mensaje
        {
            get
            {
                return mensaje;
            }
        }
        public string ColorMensaje
        {
            get
            {
                return colorMensaje;
            }
        }
        public DelegateCommand CommandEnviarDatos
        {
            get
            {
                return commandEnviarDatos;
            }
            set
            {
                commandEnviarDatos = value;
            }
        }

        //Propiedades prueba
        public string Nombre
        {
            set
            {
                nombre = value;

                commandEnviarDatos.RaiseCanExecuteChanged();
            }
        }

        public string Apellidos
        {
            set
            {
                apellidos = value;

                commandEnviarDatos.RaiseCanExecuteChanged();
            }
        }

        public string Dni
        {
            set
            {
                dni = value;

                commandEnviarDatos.RaiseCanExecuteChanged();
            }
        }

        public string Telefono
        {
            set
            {
                telefono = value;

                commandEnviarDatos.RaiseCanExecuteChanged();
            }
        }
        public string Direccion
        {
            set
            {
                direccion = value;

                commandEnviarDatos.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region Constructor
        public clsRecogidaDatosVM()
        {
            establecerMensaje();

            this.nombre = "";
            this.apellidos = "";
            this.dni = "";
            this.telefono = "";
            this.direccion = "";

            this.nuevaPersona = new clsPersona();
            this.commandEnviarDatos = new DelegateCommand(enviarDatosExecute, enviarDatosCanExecute);
            //this.commandEnviarDatos = new DelegateCommand(enviarDatosExecute);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que establece el mensaje según el diagnóstico obtenido de la persona
        /// Si porcentaje>70% entonces
        ///     Mensaje = "Llame a alguno de los siguientes números 900 400 061 / 955 545 060" (En rojo)
        /// Si No
        ///     Mensaje = "Parece no estar contagiado" (En verde)
        /// </summary>
        public void establecerMensaje()
        {
            if (porcentajeObtenido > 70)
            {
                this.mensaje = "Llame a alguno de los siguientes números 900 400 061 / 955 545 060";
                this.colorMensaje = "Red";
            }
            else
            {
                this.mensaje = "Parece no estar contagiado";
                this.colorMensaje = "Green";
            }

        }


        /// <summary>
        /// Método que envía los datos obtenidos de los campos rellenados a la BD
        /// Se ejecuta al pulsar el botón "Enviar datos" que debe habilitarse al rellenar todos los campos
        /// </summary>
        public void enviarDatosExecute()
        {
            try
            {
                clsInsertarPersonaBL objInsertar = new clsInsertarPersonaBL();
                //nuevaPersona = new clsPersona("123M", "Pepito", "González", "123456789", "Calle de la torcuata", true);
                //clsPersona nuevaPerson = new clsPersona(nuevaPersona.DniPersona, nuevaPersona.NombrePersona, nuevaPersona.ApellidosPersona, nuevaPersona.Telefono, nuevaPersona.Direccion, true);
                nuevaPersona.NombrePersona = nombre;
                nuevaPersona.ApellidosPersona = apellidos;
                nuevaPersona.DniPersona = dni;
                nuevaPersona.Telefono = telefono;
                nuevaPersona.Direccion = direccion;

                objInsertar.insertarPersona(nuevaPersona); //La inserción funciona bien

                mensajeEnvioDatos("Datos enviados correctamente");

            }catch(Exception e)
            {
                mensajeEnvioDatos("Error al intentar enviar los datos");
            }
        }

        /// <summary>
        /// Método que comprueba que el botón puede ser pulsado, y esto ocurrirá cuando todos los campos estén completados
        /// </summary>
        /// <returns>bool que indica que todos los campos han sido rellenados y validados</returns>
        public bool enviarDatosCanExecute()
        {
            return validarFormulario();
        }

        /// <summary>
        /// Método que muestra un mensaje indicando si los datos se enviaron correctamente o se produjo un error
        /// </summary>
        /// <param name="mensaje">string que contiene el mensaje a mostrar, dependiendo de si hubo éxito o no al intentar enviar los datos</param>
        private async void mensajeEnvioDatos(string mensaje)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = mensaje,
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }

        /// <summary>
        /// Método que valida todos los campos del formulario
        /// </summary>
        /// <returns>bool datosValidados, indica si los datos están correctamente validados o no</returns>
        public bool validarFormulario()
        {
            bool datosValidados = false;
            //if (nuevaPersona != null) {
            //    if (!nuevaPersona.NombrePersona.Equals("")
            //    && !nuevaPersona.ApellidosPersona.Equals("")
            //    && !nuevaPersona.DniPersona.Equals("")
            //    && !nuevaPersona.Telefono.Equals("")
            //    && !nuevaPersona.Direccion.Equals(""))
            //    {
            //        datosValidados = true;

            //    //commandEnviarDatos.RaiseCanExecuteChanged();
            //}
            //}

           
            if (validarNombre() && validarApellidos() && validarDni() && validarTelefono() && validarDireccion())
            {
                datosValidados = true;
            }

            return datosValidados;
        }
        /// <summary>
        /// Método que valida el nombre:
        /// Que no supere 15 carateres (máximo en la BD)
        /// Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si el nombre es correcto</returns>
        public bool validarNombre()
        {
            bool correcto = false;
            if (nombre.Length < 15 && !nombre.Equals(""))
            {
                correcto = true;
            }

            return correcto;
        }
        /// <summary>
        /// Método que valida lo apellidos :
        /// Que no supere 30 carateres (máximo en la BD)
        /// Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si los apellidos son correctos</returns>
        public bool validarApellidos()
        {
            bool correcto = false;
            if (apellidos.Length < 30 && !apellidos.Equals(""))
            {
                correcto = true;
            }

            return correcto;
        }

        /// <summary>
        /// Método que valida el dni :
        /// - Que sea igual a 9 caracteres (longitud de Dni y máximo en BD)
        /// - Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// - Que coincida con lo caracteres propios de un dni
        /// </summary>
        /// <returns>bool correcto, indica si el dni es correcto</returns>
        public bool validarDni()
        {
            bool correcto = false;
            if (dni.Length == 9 && !dni.Equals("") && Regex.IsMatch(dni, "[0-9]{8,8}[A-Za-z]"))
            {
                correcto = true;
            }

            return correcto;
        }


        /// <summary>
        /// Método que valida el teléfono :
        /// Que no supere 15 carateres (máximo en la BD)
        /// Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si el teléfono es correcto</returns>
        public bool validarTelefono()
        {
            bool correcto = false;
            if (telefono.Length < 15 && !telefono.Equals("") && Regex.IsMatch(telefono, "[0-9]"))
            {
                correcto = true;
            }

            return correcto;
        }

        /// <summary>
        /// Método que valida la dirección :
        /// Que no supere 60 carateres (máximo en la BD)
        /// Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si la dirección es correcta</returns>
        public bool validarDireccion()
        {
            bool correcto = false;
            if (direccion.Length < 60 && !direccion.Equals(""))
            {
                correcto = true;
            }

            return correcto;
        }

        //Esto no funciona:
        int porcentajeObtenido;
        /// <summary>
        /// Método que recibe el porcentaje de la vista anterior para comprobar el diagnóstico
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            porcentajeObtenido = Convert.ToInt32(e.Parameter.ToString());
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Método que permite notificar los cambios a la vista
        /// No implemento clsVMBase, porque no me permite implementar varias clases Base
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
