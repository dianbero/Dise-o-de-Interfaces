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
        /// <summary>
        /// Convierte el tiempo en DateTime a formato "mm:ss" para mostrar en la vista
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
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
