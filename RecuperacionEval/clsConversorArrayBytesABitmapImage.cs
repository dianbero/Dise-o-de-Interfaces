using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace UWP_CRUD___UI.Utils
{
    class clsConversorArrayBytesABitmapImage
    {
        /// <summary>
        /// Convierte un array de bytes en BitmapImage.
        /// El array de bytes debe ser una imagen.
        /// </summary>
        /// <param name="imagenEnBytes">El array de bytes que contiene los datos de una imagen.</param>
        /// <returns>El Task que contendrá el BitmapImage. Si el array dado no es una imagen, devolverá null.</returns>
        public async Task<BitmapImage> ArrayBytesToBitmapImage(byte[] imagenEnBytes)
        {
            //Crea un nuevo stream de salida de acceso aleatorio.
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                //Crea un nuevo writer a partir del stream anterior.
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    //Escribe el aray de bytes en el stream con el writer.
                    writer.WriteBytes(imagenEnBytes);

                    //Confirma los datos y los almacena en el stream.
                    await writer.StoreAsync();
                }

                //Crea el objeto BitmapImage que se devolverá.
                var image = new BitmapImage();

                //Establece la imagen a partir de la fuente de datos, que será el stream definido anteriormente y cargado con el array de bytes.
                try
                {
                    await image.SetSourceAsync(stream);
                }
                catch(Exception)            //Puede saltar excepción cuando el array de bytes dado no se puede convertir en imagen, en tal caso, el método devolverá un null para indicar que no se realizó correctamente la conversión.
                {
                    image = null;
                }

                return image;
            }
        }

        /// <summary>
        /// Convierte un BitmapImage en un array de bytes.
        /// </summary>
        /// <param name="imageSource">El BitmapImage con la imagen a convertir.</param>
        /// <returns>El Task que contendrá el array de bytes.</returns>
        public async Task<Byte[]> BitmapImageToByteArray(BitmapImage imageSource)
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(imageSource.UriSource);
            return await StorageFileToByteArray(file);
        }

        /// <summary>
        /// Convierte un StorageFile en un array de bytes.
        /// </summary>
        /// <param name="file">El StorageFile a convertir.</param>
        /// <returns>El Task que contendrá el array de bytes convertido.</returns>
        public async Task<Byte[]> StorageFileToByteArray(StorageFile file)
        {
            //Crea un flujo de entrada sobre el StorageFile dado.
            using (var inputStream = await file.OpenSequentialReadAsync())
            {
                //No se lo que hace 🤔 (es un stream de lectura, pero no entiendo el método "AsStreamForRead()" (no tiene SUMMARY, gracias Microsoft) )
                var readStream = inputStream.AsStreamForRead();

                //Crea un array de bytes con el tamaño del stream de lectura.
                var byteArray = new byte[readStream.Length];
                
                //Lee la secuencia de bytes del readStream (creo?) y lo va guardando en el array byteArray definido arriba.
                await readStream.ReadAsync(byteArray, 0, byteArray.Length);

                return byteArray;
            }
        }
    }
}
