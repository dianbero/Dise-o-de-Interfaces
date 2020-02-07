using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools
{
    public class clsConverterFecha : IValueConverter
    {
        DateTime fechaSinFormatear;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Convertir datetime en mm:ss para mostrar bonito en Ranking
            fechaSinFormatear = (DateTime)value;
            string fechaFormateada = fechaSinFormatear.ToString("mm:ss");

            return fechaFormateada;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
