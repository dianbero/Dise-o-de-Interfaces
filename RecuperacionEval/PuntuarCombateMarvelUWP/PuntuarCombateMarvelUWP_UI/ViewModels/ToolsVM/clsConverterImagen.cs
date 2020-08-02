using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using System.Drawing;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;

namespace PuntuarCombateMarvelUWP_UI.ViewModels.ToolsVM
{
    public class clsConverterImagen : IValueConverter
    {
        private Image img = new Image();
        
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            byte[] array = (byte[])value;
                        
            return convertirArrayAImagen(array);

            //return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }


        /// <summary>
        /// Método que convierte un array de bytes en Image
        /// </summary>
        /// <param name="luchador"></param>
        public async Task<BitmapImage> convertirArrayAImagen(byte[] arrayFoto)
        {

            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    //writer.WriteBytes(vm.ListadoLuchadores[2].FotoLuchador);
                    writer.WriteBytes(arrayFoto);
                    await writer.StoreAsync();
                }

                var image = new BitmapImage();
                //await image.SetSourceAsync(stream); //Con esto me saltaba

                image.SetSource(stream); //Con esto me ejecuta lo que viene a continuación, no salta como el otro

                return image;

                //listaFotos.Add(image);

                //Paso el BitmapImage a una nueva imagen
                //img.Source = image;

            }
        }







    }
}
