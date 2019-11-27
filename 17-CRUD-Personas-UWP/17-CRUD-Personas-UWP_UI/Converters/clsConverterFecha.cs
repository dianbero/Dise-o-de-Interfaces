using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CRUD_Personas_UWP_UI.Converters
{
    public class clsConverterFecha : IValueconverter
    {
        public object Convert(object value, Type targetType, object parameter)
        {
            DateTime fechaConvertida = (DateTime)value;
            

            return DateTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter)
        {
            
            if(value != DateTimeOffset)
            {
                DateTimeOffSet fechaConvertBack = (DateTimeOffset)value;
                
            }
        }
    }
}
