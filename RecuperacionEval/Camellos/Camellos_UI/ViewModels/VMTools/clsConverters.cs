using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Camellos_UI.ViewModels.VMTools
{
    public class clsConverters : IValueConverter
    {
        /// <summary>
        /// Método que castea las fechas a formarto 00:00 (minutos : segundos)
        /// </summary>
        /// <param name="value">object con el valor del dato a castear</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fechaOriginal = (DateTime)value;
            string fechaFormateada = fechaOriginal.ToString("mm:ss");

            return fechaFormateada;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
