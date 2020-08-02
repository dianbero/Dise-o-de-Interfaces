using _16_Insertar_imagen_en_BBDD_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace _16_Insertar_imagen_en_BBDD_UI.Models.Ent
{
    public class clsImagen:clsVMBase
    {

        private StorageFile _fichero;

        public string nombreTabla { get; set; }
        public string nombrePK { get; set; }
        public int valorPK { get; set; }
        public string nombreCampoImagen { get; set; }
        public byte[] arrayFoto { get; set; }
        public BitmapImage imagenBitMap { get; set; }

        public StorageFile fichero
        {
            get { return _fichero; }
            set
            {
                _fichero = value;
                rellenarArray();
                rellenarImagen();
            }
        }

        public clsImagen()
        {
            nombreTabla = "SH_Luchadores";
            nombrePK = "IdLuchador";
            valorPK = 1;
            nombreCampoImagen = "FotoLuchador";
        }

        /// <summary>
        /// Convierte un StorageFile en un array de bytes.
        /// </summary>
        /// <param name=""></param>
        /// <returns>El Task que contendrá el array de bytes convertido.</returns>
        private async void rellenarArray()
        {
            if (_fichero != null)
            {
                //Crea un flujo de entrada sobre el StorageFile dado.
                using (var inputStream = await _fichero.OpenSequentialReadAsync())
                {

                    var readStream = inputStream.AsStreamForRead();

                    //Crea un array de bytes con el tamaño del stream de lectura.
                    var byteArray = new byte[readStream.Length];

                    //Lee la secuencia de bytes del readStream (creo?) y lo va guardando en el array byteArray definido arriba.
                    await readStream.ReadAsync(byteArray, 0, byteArray.Length);

                    arrayFoto = byteArray;
                    NotifyPropertyChanged("fichero");
                }
            }
        }

        /// <summary>
        /// Rellena la imagen BitMap desde el fichero
        /// </summary>
        private async void rellenarImagen()
        {
            if (_fichero != null)
            {
                using (var randomAccessStream = await _fichero.OpenAsync(FileAccessMode.Read))
                {
                    var result = new BitmapImage();
                    await result.SetSourceAsync(randomAccessStream);
                    imagenBitMap = result;
                    NotifyPropertyChanged("imagenBitMap");
                }
            }

        }
    }

}

