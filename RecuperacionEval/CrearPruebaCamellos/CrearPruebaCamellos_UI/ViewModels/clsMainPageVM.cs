using CrearPruebaCamellos_BL.Handlers;
using CrearPruebaCamellos_Entities;
using CrearPruebaCamellos_UI.Models;
using CrearPruebaCamellos_UI.ViewModels.ToolsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CrearPruebaCamellos_UI.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        #region Atributos Privados
        //Con Bindeo
        private clsPalabra palabraIntroducida;
        private ObservableCollection<clsPalabraConAtributoYaExiste> listadoPalabras;
        private string tiempoPruebaMostrado;
        private DelegateCommand btnAddPalabra;
        private DelegateCommand btnBorrarPalabra;
        private DelegateCommand btnCrearPrueba;
        private clsPalabraConAtributoYaExiste palabraSeleccionada;

        //Sin bindeo
        private TimeSpan tiempoPrueba;
        private string mensajeError;
        #endregion

        #region Propiedades Públicas
        public clsPalabra PalabraIntroducida { get => palabraIntroducida; set => palabraIntroducida = value; }
        public ObservableCollection<clsPalabraConAtributoYaExiste> ListadoPalabras { get => listadoPalabras;  }
        public string TiempoPruebaMostrado { get => tiempoPruebaMostrado; }
        public DelegateCommand BtnAddPalabra { get => btnAddPalabra; set => btnAddPalabra = value; }
        public DelegateCommand BtnBorrarPalabra { get => btnBorrarPalabra; set => btnBorrarPalabra = value; }
        public DelegateCommand BtnCrearPrueba { get => btnCrearPrueba; set => btnCrearPrueba = value; }
        public clsPalabraConAtributoYaExiste PalabraSeleccionada { set => palabraSeleccionada = value; }
        #endregion

        #region Contructor
        public clsMainPageVM()
        {
            inicializarElementos();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que inicializa los elementos del ViewModel
        /// </summary>
        private void inicializarElementos()
        {
            this.palabraIntroducida = new clsPalabra();
            this.listadoPalabras = new ObservableCollection<clsPalabraConAtributoYaExiste>();
            this.tiempoPruebaMostrado = "00:00" ;
            this.btnAddPalabra = new DelegateCommand(addPalabraExecute);
            this.btnBorrarPalabra = new DelegateCommand(borrarPalabraExecute);
            this.btnCrearPrueba = new DelegateCommand(crearPruebaExecute);
            //this.btnCrearPrueba = new DelegateCommand(crearPruebaExecute, crearPruebaCanExecute); //Esto no me ha funcionado, en su lugar habilito siempre el botón y compruebo si el listado tiene palabras
            this.tiempoPrueba = new TimeSpan(0,0,0);
            this.mensajeError = "Se produjo un fallo de conexión";
        }

       

        /// <summary>
        /// Método que añade una nueva palabra al listado:
        /// Lógica:
        /// Valida la palabra:
        /// Si está bien validada:
        ///     -Si no está en el listado:
        ///         -Si la dificultad es mayor a 0:
        ///             -Si la palabra ya existe en la BBDD:
        ///                 -Obtiene la palabra de la BBDD, e indica que ya existe
        ///             -Si no existe:
        ///                 -Guarda los datos de la nueva palabra                  
        ///             -Añade la palabra al listado
        ///             -Suma al tiempo total de la prueba el correspondiente a la dificultad de la palabra
        ///         -Si no es mayo a 0: muestra mensaje indicándolo
        ///     -Si está en el listado: muestra mensaje indicándolo
        /// Si no está bien validada: muestra mensaje indicándolo
        /// </summary>
        public void addPalabraExecute()
        {
            //Creo objeto clsPalabraConAtributoYaExiste auxiliar para asignarle valores y después añadirlo en el listado de palabras
            clsPalabraConAtributoYaExiste palabraAux = new clsPalabraConAtributoYaExiste();

            try
            {
                //Si el campo de la palabra tiene texto y no supera 80 caracteres
                if (validarPalabra())
                {
                    //Si la palabra no está en el listado
                    if (!comprobarPalabraEstaListado())
                    {
                        //Si la dificultad de la palabra es mayor a 0
                        /*Podría haber puesto directamente que el slider fuese desde 1, pero el enunciado dice que debe ser de 0 a 20, 
                         * a pesar de que no debe permitirse que la dificultad sea 0*/
                        if (palabraIntroducida.Dificultad > 0)
                        {
                            //Si la palabra existe, se obtiene esa palabra  y se le asigna el valor a palabraAux
                            if (comprobarPalabraExiste())
                            {
                                //Obtengo la palabra existente de la BBDD y se la asigno a palabraIntroducida
                                palabraIntroducida = new clsHandlerPalabrasBL().getPalabraExistente(palabraIntroducida.Palabra);
                                NotifyPropertyChanged("PalabraIntroducida"); /*Si no notifico el cambio, la palabra se queda siempre con el valor obtenido de la BBDD, y siempre sale el mensaje de que la palabra ya está en el listado*/

                                //Asigno a la palabra auxiliar los datos de la palabra obtenida de la base de datos
                                palabraAux.IdPalabra = palabraIntroducida.IdPalabra;
                                palabraAux.Palabra = palabraIntroducida.Palabra;
                                palabraAux.Dificultad = palabraIntroducida.Dificultad;
                                //Indico que la palabra ya existe
                                palabraAux.YaExiste = true;
                            }
                            //Si no existe, le asigno los datos introducidos a la palabra Auxiliar
                            else
                            {
                                palabraAux.Palabra = palabraIntroducida.Palabra;
                                palabraAux.Dificultad = palabraIntroducida.Dificultad;
                            }

                            //Añado la palabra auxiliar al listado de palabras
                            listadoPalabras.Add(palabraAux);
                            NotifyPropertyChanged("ListadoPalabras");

                            //Sumo el tiempo correspondiente a la dificultad de la palabra al tiempo total
                            sumarTiempo();

                            //Vacío el campo
                            palabraIntroducida.Palabra = "";
                            NotifyPropertyChanged("PalabraIntroducida");
                        }
                        else
                        {
                            mensajeError = "La dificultad debe ser superior a 0";
                            mostrarMensajeError();
                        } 
                    }
                    else
                    {
                        mensajeError = "La palabra ya está en el listado, no puede repetirse.";
                        mostrarMensajeError();
                    }
                }
                else
                {
                    mensajeError = "El campo debe rellenarse y no superar los 80 caracteres";
                    mostrarMensajeError();
                }
            }
            catch(Exception e)
            {
                //throw e;
                mensajeError = "Se produjo un fallo de conexión";
                mostrarMensajeError();
            }

        }

        /// <summary>
        /// Método que elimina una palabra de la lista de palabras a añadir.
        /// </summary>
        public void borrarPalabraExecute()
        {
            //Elimina directamente la palabra seleccionada del listado de palabras
            listadoPalabras.Remove(palabraSeleccionada);
            //Resta su correspondiente en el tiempo total de la prueba
            restarTiempo();
        }


        /// <summary> 
        /// Método que crea una nueva prueba.
        /// Si el listado contiene palabras:
        ///     -Muestra un mensaje para asegurarse de que se quiere crear esa prueba.
        ///     -En caso positivo, la inserta.
        /// Si no hay palabras: muestra mensaje indicándolo
        /// </summary>
        private async void crearPruebaExecute()
        {
            //Si el listado tiene palabras
            if (listadoPalabras.Count > 0)
            {
                ContentDialog seguroPruebaDialog = new ContentDialog()
                {
                    Title = "¿Seguro?",
                    Content = "¿Seguro que desea insertar la prueba?",
                    PrimaryButtonText = "Ok",
                    CloseButtonText = "Cancelar"
                };

                ContentDialogResult result = await seguroPruebaDialog.ShowAsync();

                //Si pulsa Ok
                if (result == ContentDialogResult.Primary)
                {
                    //Inserta prueba (hace sus correspondientes comprobaciones)
                    insertarPruebaYPalabra();
                }
            }
            else
            {
                //Muestra mensaje indicando que debe contener palabras
                mensajeError = "Debe introducir palabras para insertar una prueba.";
                mostrarMensajeError();
            }            
        }

        //Esto no funcionó, no habilitaba el botón cuando metía palabras en el listado
        ///// <summary>
        ///// Método comprueba si hay palabras a insertar, para habilitar el botón
        ///// </summary>
        ///// <returns>bool puedeCrear, indica si se puede habilitar el botón para crear un prueba</returns>
        //private bool crearPruebaCanExecute()
        //{
        //    bool puedeCrear = false;

        //    //Si el listado tiene palabras, habilita el botón para insertar prueba
        //    if (listadoPalabras.Count > 0)
        //    {
        //        puedeCrear = true;
        //    }

        //    return puedeCrear;
        //}
        
        /// <summary>
        /// Método que muestra mensaje de error dependiendo de cuál sea éste
        /// </summary>
        private async void mostrarMensajeError()
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = "Error",
                Content = mensajeError,
                CloseButtonText = "Ok"
            };

            await errorDialog.ShowAsync();
        }

        /// <summary>
        /// Método que comprueba si una palabra ya existe
        /// </summary>
        /// <returns>bool ya Existe, indicando si existe o no</returns>
        private bool comprobarPalabraExiste()
        {
            bool yaExiste = false;

            int filasAfectadas = new clsHandlerPalabrasBL().checkExistePalabra(palabraIntroducida.Palabra);

            if (filasAfectadas > 0)
            {
                yaExiste = true;
            }

            return yaExiste;
        }


        /// <summary>
        /// Método que comprueba que una palabra ya está en el listado
        /// </summary>
        /// <returns>bool yaEnListado, indicando si está ya en el listado o no</returns>
        private bool comprobarPalabraEstaListado()
        {
            bool yaEnListado = false;

            //Si el tamaño del listado es mayor a cero, es decir, tiene palabras
            if (listadoPalabras.Count > 0)
            {
                for (int i = 0; i < listadoPalabras.Count; i++)
                {
                    //Si la palabra introducida es igual a alguna de las del listado, asigna buleano a true
                    if (listadoPalabras[i].Palabra.Equals(palabraIntroducida.Palabra))
                    {
                        yaEnListado = true;
                    }
                }
            }           

            return yaEnListado;
        }

        /// <summary>
        /// Método que valida la palabra introducida:
        /// - Que el campo no esté vacío
        /// - Que no supere los 80 caracteres
        /// </summary>
        /// <returns>bool correcto, indicando si la palabra es correcta o no</returns>
        private bool validarPalabra()
        {
            bool correcto = false;

            if(!palabraIntroducida.Palabra.Equals("") && palabraIntroducida.Palabra.Length <= 80)
            {
                correcto = true;
            }

            return correcto;
        }

        /// <summary>
        /// Método que inserta una nueva prueba con sus correspondientes palabras.
        /// Lógica del método:
        ///     - Inserta prueba
        ///     - Recorre el listado de palabras:
        ///         - Comprueba existencia de palabras
        ///             - Si la palabra[i] no existe: la inserta
        ///             - Si ya existe no hace nada
        ///         - Inserta en CJ_PruebasPalabras el idPalabra de la palabra[i] y el idPrueba (la que se acaba de insertar y que contiene la palabra[i])
        /// </summary>
        private void insertarPruebaYPalabra()
        {
            int idPrueba = 0;
            //int idPalabra = 0;          

            try
            {
                //Creo el nuevo objeto clsPrueba para insertar
                clsPrueba nuevaPrueba = new clsPrueba();
                nuevaPrueba.NumeroPalabras = listadoPalabras.Count;
                nuevaPrueba.TiempoMax = tiempoPrueba;

                //Inserta prueba
                idPrueba = new clsHandlerPruebasBL().insertarPrueba(nuevaPrueba);

                //Compruebo si las palabras del listado existe 
                for(int i = 0; i < listadoPalabras.Count; i++)
                {
                    //Si la palabra no existe, la inserta
                    if (!listadoPalabras[i].YaExiste)
                    {
                        //idPalabra = new clsHandlerPalabrasBL().insertarPalabra(listadoPalabras[i]);
                        listadoPalabras[i].IdPalabra = new clsHandlerPalabrasBL().insertarPalabra(listadoPalabras[i]);
                        ////Lo asigno a true, porque obviamente una vez insertada, ya si va a existir
                        //listadoPalabras[i].YaExiste = true;
                    }

                    //Inserto en CJ_PruebasPalabras
                    //new clsHandlersPruebasPalabrasBL().insertarPruebasPalabras(idPrueba, idPalabra);
                    new clsHandlersPruebasPalabrasBL().insertarPruebasPalabras(idPrueba, listadoPalabras[i].IdPalabra);
                }

                //Mensaje de prueba insertada correctamente
                mostrarMensajeExito();

                //Vacío el listado y el tiempo prueba
                listadoPalabras.Clear();
                tiempoPrueba = new TimeSpan(0, 0, 0);
                tiempoPruebaMostrado = tiempoPrueba.ToString(@"mm\:ss");
                NotifyPropertyChanged("TiempoPruebaMostrado");
            }
            catch (Exception e)
            {
                //throw e;
                mensajeError = "Se produjo un fallo de conexión";
                mostrarMensajeError();
            }
        }

        /// <summary>
        /// Método que muestra mensaje indicando que la prueba se ha insertado correctamente
        /// </summary>
        private async void mostrarMensajeExito()
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = "Éxito",
                Content = "La prueba se ha insertado correctamente",
                CloseButtonText = "Ok"
            };

            await errorDialog.ShowAsync();
        }

        /// <summary>
        /// Método que suma al tiempo de la prueba el correspondiente a la dificultad de la palabra introducida
        /// </summary>
        private void sumarTiempo()
        {
            //Convierto la dificultad de palabra a objetoTimeSpan
            TimeSpan tiempoDificultad = new TimeSpan(0, 0, palabraIntroducida.Dificultad); //Como el rango es de 0 a 20, no hay problema

            //Sumo el tiempoDificultad al total de la prueba
            tiempoPrueba += tiempoDificultad;
            tiempoPruebaMostrado = tiempoPrueba.ToString(@"mm\:ss");
            NotifyPropertyChanged("TiempoPruebaMostrado");
        }

        /// <summary>
        /// Método que resta al tiempo de la prueba el correspondiente a la dificultad de la palabra eliminada (palabraSeleccionada)
        /// </summary>
        private void restarTiempo()
        {
            //Compruebo que la palabra no sea nula, en caso de pulsar en espacio vacío, para que no haga nada
            if (palabraSeleccionada != null)
            {
                //Convierto la dificultad de palabra a objetoTimeSpan
                TimeSpan tiempoDificultad = new TimeSpan(0, 0, palabraSeleccionada.Dificultad);

                //Resto el tiempoDificultad al total de la prueba
                tiempoPrueba -= tiempoDificultad;
                tiempoPruebaMostrado = tiempoPrueba.ToString(@"mm\:ss");
                NotifyPropertyChanged("TiempoPruebaMostrado");
            }            
        }

        /// <summary>
        /// Método que permite que añadir una palabra al listado pulsando la tecla Intro
        /// </summary>
        /// <param name="sender">object que invoca el evento</param>
        /// <param name="e">KeyRoutedEventArgs cCon los datos del evento lanzado por el objeto</param>
        public void PalabraIntroducida_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                addPalabraExecute();
            }
        }
        #endregion
    }
}
