//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _17_CRUD_Personas_UWP_UI.Converters
//{
//    public class clsConverterFecha : IValueconverter
//    {
//        public object Convert(object value, Type targetType, object parameter)
//        {
//            DateTime fechaConvertida = (DateTime)value;
//            //String fecha = fechaConvertida.ToString("dd/MM/yyyy");
//            String fecha = fechaConvertida.ToShortDateString();
//            return fecha;
//        }

//        public object ConvertBack(object value, Type targetType, object parameter)
//        {
            
//            string fechaConvertBack = (string)value;                
            
//            return DateTime.Parse(fechaConvertBack);
//        }
//    }
//}
