using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Hospital_UI.ViewModels.ToolsVM
{
    public class clsConverterFecha : IValueConverter
    {
        DateTime fechaSinFormatear;
        /// <summary>
        /// Método que convierte la fecha de tipo DateTime en un string en el formato dd/MM/yyyy
        /// </summary>
        /// <param name="value">Valor del dato a convertir</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns> string fechaFormateada, con la fecha formateada</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            fechaSinFormatear  = (DateTime)value;
            string fechaFormateada = fechaSinFormatear.ToString("dd/MM/yyyy");
            return fechaFormateada;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
