using _16_Insertar_imagen_en_BBDD_UI.Models.DAL;
using _16_Insertar_imagen_en_BBDD_UI.Models.Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _16_Insertar_imagen_en_BBDD_UI.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {

        #region "Atributos"

        private DelegateCommand _seleccionarImagenCommand;
        private DelegateCommand _guardarCommand;
        private clsMyConnection _oConexion;
        private clsImagen _oImagen;

        #endregion

        #region "Propiedades"



        public clsMyConnection oConexion
        {
            get { return _oConexion; }
            set { _oConexion = value; }
        }

        public clsImagen oImagen
        {

            get { return _oImagen; }
            set { _oImagen = value; }
        }
        public DelegateCommand seleccionarImagenCommand
        {
            get
            {
                _seleccionarImagenCommand = new DelegateCommand(seleccionarImagenCommand_Executed);
                return _seleccionarImagenCommand;
            }
        }
        public DelegateCommand guardarCommand
        {
            get
            {
                _guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecute);
                return _guardarCommand;
            }
        }


        #endregion



        #region "Constructores"
        public clsMainPageVM()
        {
            _oConexion = new clsMyConnection();
            _oImagen = new clsImagen();
        }
        #endregion



        #region "Commands"
        /// <summary>
        /// Se ejecuta cuando se pulsa el botón para seleccionar un archivo
        /// </summary>
        public async void seleccionarImagenCommand_Executed()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                _oImagen.fichero = file;
                NotifyPropertyChanged("oImagen");



            }


        }


        /// <summary>
        /// Se ejecuta cuando pulsamos el botón "Guardar imagen". Manda los datos de la conexion y de la foto a guardar a la función InsertarFotoDAL de la capa DAL
        /// </summary>
        public async void GuardarCommand_Executed()
        {
            int respuesta;
            clsManejadoraFoto oManejadoraPersona = new clsManejadoraFoto();
            ContentDialog mensajeExito = new ContentDialog();

            try
            {

                respuesta = oManejadoraPersona.insertarImagenDAL(oConexion, oImagen);

                if (respuesta == 1) {
                    mensajeExito.Title = "Guardado con éxito";
                    mensajeExito.Content = "La imagen se ha guardado con éxito";

                    mensajeExito.SecondaryButtonText = "Aceptar";

                    ContentDialogResult resultado = await mensajeExito.ShowAsync();
                }
            }
            catch (Exception)
            {

                //Mostrar error;
            }


        }

        private bool GuardarCommand_CanExecute()
        {
            bool sePuedeBorrar = true;
            //Si no hay una persona seleccionada no se puede borrar
            //if (_personaSeleccionada == null)
            //{
            //    sePuedeBorrar = false;
            //}


            return sePuedeBorrar;
        }
        #endregion
    }
}
