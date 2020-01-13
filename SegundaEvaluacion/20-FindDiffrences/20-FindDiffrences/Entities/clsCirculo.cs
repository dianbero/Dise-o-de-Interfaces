using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace _20_FindDiffrences.Entities
{
    public class clsCirculo
    {
        #region Propiedades Públicas
        public bool IsSeleccionado { get; set; }
        //public bool IsVisible { get; set; }
        public double EjeX { get; set; }
        public double EjeY { get; set; }
        public int Diametro { get; set; }
        public Ellipse Circulo { get; set; }
        #endregion


        #region Constructor
        //Constructor por defecto
        public clsCirculo()
        {
            EjeX = 0;
            EjeY = 0;
            Diametro = 60;            
            IsSeleccionado = false;
            //IsVisible = false;
            Circulo = asignarPropiedadesEllipse(Diametro, IsSeleccionado);            
        }
        public clsCirculo(double x, double y)
        {
            EjeX = x;
            EjeY = y;
            Diametro = 60;
            IsSeleccionado = false;
            //IsVisible = false;
            Circulo = asignarPropiedadesEllipse(Diametro, IsSeleccionado);
        }
        #endregion

        #region Métodos
        public Ellipse asignarPropiedadesEllipse(int diametro, bool seleccionado)
        {
            Ellipse circulo = new Ellipse();
            circulo.Width = diametro;
            circulo.Height = diametro;
            circulo.Stroke = new SolidColorBrush(Colors.Black);
            circulo.StrokeThickness = 5;
            if (seleccionado)
            {
                circulo.Opacity = 1;
            }
            else
            {
                circulo.Opacity = 0;
            }
            return circulo;
        }
        
        #endregion
    }
}
