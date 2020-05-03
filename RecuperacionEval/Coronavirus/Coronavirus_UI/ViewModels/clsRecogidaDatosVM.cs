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
    public class clsRecogidaDatosVM : clsVMBase
    {
        #region Atributos Privados
        private clsPersona nuevaPersona;
        private string mensaje;
        private string colorMensaje;
        private DelegateCommand commandEnviarDatos;
        private int porcentajeObtenido;

        //Mensajes error campos
        private string mensajeNombre;
        private string mensajeApellidos;
        private string mensajeDni;
        private string mensajeTelefono;
        private string mensajeDireccion;

        //Alternativa a problema de bindear únicamente propiedades de clsPersona, esto funciona
        private string nombre;
        private string apellidos;
        private string dni;
        private string telefono;
        private string direccion;

        #endregion

        #region Propiedades Públicas
        public clsPersona NuevaPersona
        {
            get
            {
                return nuevaPersona;
            }
        }
        public string Mensaje
        {
            get
            {
                establecerMensaje();
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

        //Propiedades de mensajes de error
        public string MensajeNombre { get => mensajeNombre; set => mensajeNombre = value; }
        public string MensajeApellidos { get => mensajeApellidos; set => mensajeApellidos = value; }
        public string MensajeDni { get => mensajeDni; set => mensajeDni = value; }
        public string MensajeTelefono { get => mensajeTelefono; set => mensajeTelefono = value; }
        public string MensajeDireccion { get => mensajeDireccion; set => mensajeDireccion = value; }

        ////Propiedades prueba
        //public string Nombre
        //{
        //    set
        //    {
        //        nombre = value;

        //        commandEnviarDatos.RaiseCanExecuteChanged();
        //    }
        //}

        //public string Apellidos
        //{
        //    set
        //    {
        //        apellidos = value;

        //        commandEnviarDatos.RaiseCanExecuteChanged();
        //    }
        //}

        //public string Dni
        //{
        //    set
        //    {
        //        dni = value;

        //        commandEnviarDatos.RaiseCanExecuteChanged();
        //    }
        //}

        //public string Telefono
        //{
        //    set
        //    {
        //        telefono = value;

        //        commandEnviarDatos.RaiseCanExecuteChanged();
        //    }
        //}
        //public string Direccion
        //{
        //    set
        //    {
        //        direccion = value;

        //        commandEnviarDatos.RaiseCanExecuteChanged();
        //    }
        //}

        //public int PorcentajeObtenido { get => porcentajeObtenido; set => porcentajeObtenido = value; }

        #endregion

        #region Constructor
        public clsRecogidaDatosVM()
        {
            //establecerMensaje();
            
            //this.nombre = "";
            //this.apellidos = "";
            //this.dni = "";
            //this.telefono = "";
            //this.direccion = "";


            this.nuevaPersona = new clsPersona();
            //this.commandEnviarDatos = new DelegateCommand(enviarDatosExecute, enviarDatosCanExecute);
            this.commandEnviarDatos = new DelegateCommand(enviarDatosExecute); //Porque el botón siempre está habilitado
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que establece el mensaje según el diagnóstico obtenido de la persona
        /// Si diagnóstico es positivo (true)
        ///     Mensaje = "Llame a alguno de los siguientes números 900 400 061 / 955 545 060" (En rojo)
        /// Si No
        ///     Mensaje = "Parece no estar contagiado" (En verde)
        /// </summary>
        public void establecerMensaje()
        {
            //if (PorcentajeObtenido > 70)
            if (nuevaPersona.Diagnostico) 
            {
                this.mensaje = "Llame a alguno de los siguientes números 900 400 061 / 955 545 060";
                this.colorMensaje = "DarkRed";
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
            if (validarFormulario())
            {
                try
                {
                    clsInsertarPersonaBL objInsertar = new clsInsertarPersonaBL();
                    //nuevaPersona.NombrePersona = nombre;
                    //nuevaPersona.ApellidosPersona = apellidos;
                    //nuevaPersona.DniPersona = dni;
                    //nuevaPersona.Telefono = telefono;
                    //nuevaPersona.Direccion = direccion;

                    objInsertar.insertarPersona(nuevaPersona); //La inserción funciona bien

                    mensajeEnvioDatos("Datos enviados correctamente");

                }
                catch (Exception)
                {
                    mensajeEnvioDatos("Error al intentar enviar los datos");
                }
            }           
        }

        ///// <summary>
        ///// Método que comprueba que el botón puede ser pulsado, y esto ocurrirá cuando todos los campos estén completos y validados
        ///// </summary>
        ///// <returns>bool que indica que todos los campos han sido rellenados y validados</returns>
        //public bool enviarDatosCanExecute()
        //{
        //    return validarFormulario();
        //}

        /// <summary>
        /// Método que muestra un mensaje indicando si los datos se enviaron correctamente o se produjo un error
        /// </summary>
        /// <param name="mensaje">string que contiene el mensaje a mostrar, dependiendo de si hubo éxito o no al intentar enviar los datos</param>
        private async void mensajeEnvioDatos(string mensaje)
        {
            ContentDialog mensajeEnviarDatos = new ContentDialog()
            {
                Title = mensaje,
                CloseButtonText = "Ok"
            };

            await mensajeEnviarDatos.ShowAsync();
        }

        /// <summary>
        /// Método que valida todos los campos del formulario
        /// </summary>
        /// <returns>bool datosValidados, indica si los datos están correctamente validados o no</returns>
        public bool validarFormulario()
        {
            bool datosValidados = false;

            //No sé si esta es la forma más correcta de hacer esto
            bool nombreCorrecto = validarNombre();
            bool apellidosCorrecto = validarApellidos();
            bool dniCorrecto = validarDni();
            bool telefonoCorrecto = validarTelefono();
            bool direccionCorrecto = validarDireccion();

            //if (validarNombre() && validarApellidos() && validarDni() && validarTelefono() && validarDireccion()) //Inconveniente de esto: así llamo doblemente a los métodos
            if (nombreCorrecto && apellidosCorrecto && dniCorrecto && telefonoCorrecto && direccionCorrecto) 
            {
                datosValidados = true;
            }

            return datosValidados;
        }

        /// <summary>
        /// Método que valida el nombre:
        /// - Que no supere 15 carateres (máximo en la BD)
        /// - Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si el nombre es correcto</returns>
        public bool validarNombre()
        {
            bool correcto = false;

            mensajeNombre = ""; //Inicialmente no muestra mensaje error (se borraría, en caso de que lo hubiera previamente), después comprueba si lo hay

            //if (nombre.Length < 15 && !nombre.Equals(""))
            if (nuevaPersona.NombrePersona.Length < 15 && !nuevaPersona.NombrePersona.Equals(""))
            {
                correcto = true;
            }
            else
            {
                if(nuevaPersona.NombrePersona.Equals(""))
                {
                    mensajeNombre = "Campo obligatorio";
                }
                else
                {
                    mensajeNombre = mensajeSuperaCaracteres(15);
                }
            }

            NotifyPropertyChanged("MensajeNombre");

            return correcto;
        }
        /// <summary>
        /// Método que valida lo apellidos :
        /// - Que no supere 30 carateres (máximo en la BD)
        /// - Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si los apellidos son correctos</returns>
        public bool validarApellidos()
        {
            bool correcto = false;

            mensajeApellidos = "";

            //if (apellidos.Length < 30 && !apellidos.Equals(""))
            if (nuevaPersona.ApellidosPersona.Length < 30 && !nuevaPersona.ApellidosPersona.Equals(""))
            {
                correcto = true;
            }
            else
            {
                if (nuevaPersona.ApellidosPersona.Equals(""))
                {
                    mensajeApellidos = "Campo obligatorio";
                }
                else
                {
                    mensajeApellidos = mensajeSuperaCaracteres(30);
                }
            }

            NotifyPropertyChanged("MensajeApellidos");

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
            mensajeDni = "";
            //if (dni.Length == 9 && !dni.Equals("") && Regex.IsMatch(dni, "^[0-9]{8}[A-Za-z]$"))

            //Marcar como condición también el límite de caracteres es redundante si ya compruebo con la expresión regular
            if (!nuevaPersona.DniPersona.Equals("") && Regex.IsMatch(nuevaPersona.DniPersona, "^[0-9]{8}[A-Za-z]$"))
            {
                correcto = true;
            }
            else
            {
                if(nuevaPersona.DniPersona.Equals(""))
                {
                    mensajeDni = "Campo obligatorio";
                }
                else
                {
                    mensajeDni = "Debe cumplir formato 00000000f/00000000F";
                }
            }

            NotifyPropertyChanged("MensajeDni");

            return correcto;
        }


        /// <summary>
        /// Método que valida el teléfono :
        /// - Que no supere 15 carateres (máximo en la BD)
        /// - Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// - Que se escriban sólo números 
        /// </summary>
        /// <returns>bool correcto, indica si el teléfono es correcto</returns>
        public bool validarTelefono()
        {
            bool correcto = false;

            mensajeTelefono = "";

            //if (telefono.Length < 15 && !telefono.Equals("") && Regex.IsMatch(telefono, "^[0-9]*$"))
            if (/*nuevaPersona.Telefono.Length < 15 &&*/ !nuevaPersona.Telefono.Equals("") && Regex.IsMatch(nuevaPersona.Telefono, "^[0-9]{9}$"))
            {
                correcto = true;
            }
            else
            {
               if(nuevaPersona.Telefono.Equals(""))
                {
                    mensajeTelefono = "Campo obligatorio";
                }
                else
                {
                    mensajeTelefono = "Sólo 9 números";
                }
            }

            NotifyPropertyChanged("MensajeTelefono");

            return correcto;
        }

        /// <summary>
        /// Método que valida la dirección :
        /// - Que no supere 60 carateres (máximo en la BD)
        /// - Que el campo no esté vacío, para poder pulsar botón de enviar datos
        /// </summary>
        /// <returns>bool correcto, indica si la dirección es correcta</returns>
        public bool validarDireccion()
        {
            bool correcto = false;
            mensajeDireccion = "";
            //if (direccion.Length < 60 && !direccion.Equals(""))
            if (nuevaPersona.Direccion.Length < 60 && !nuevaPersona.Direccion.Equals(""))
            {
                correcto = true;
            }
            else
            {
                if (nuevaPersona.Direccion.Equals(""))
                {
                    mensajeDireccion = "Campo obligatorio";
                }
                else
                {
                    mensajeDireccion = mensajeSuperaCaracteres(60);
                }
            }

            NotifyPropertyChanged("MensajeDireccion");

            return correcto;
        }

        /// <summary>
        /// Método que devuelve un mensaje indicando que no debe superar el límite de caracteres especificado
        /// </summary>
        /// <param name="numeroLimiteCarateres">int con número de caracteres máximo</param>
        /// <returns>string con el mensaje</returns>
        private string mensajeSuperaCaracteres(int numeroLimiteCarateres)
        {
            return $"No debe superar {numeroLimiteCarateres} caracteres";
        }

        #endregion
    }
}
