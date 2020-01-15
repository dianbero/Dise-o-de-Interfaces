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
        //public bool IsSeleccionado { get; set; }
        //public bool IsVisible { get; set; }
        public int EjeX { get; set; }
        public int EjeY { get; set; }
        public int Diametro { get; set; }
        public double Opacidad { get; set; }
        public Ellipse Circulo { get; set; }
        #endregion


        #region Constructor
        //Constructor por defecto
        public clsCirculo()
        {
            EjeX = 0;
            EjeY = 0;
            Diametro = 60;
            Opacidad = 1;
            //IsSeleccionado = false;
            //IsVisible = false;
            Circulo = asignarPropiedadesEllipse(Diametro, Opacidad);            
        }
        public clsCirculo(int x, int y, double opacidad)
        {
            EjeX = x;
            EjeY = y;
            Diametro = 60;
            Opacidad = opacidad;
            //IsSeleccionado = false;
            //IsVisible = false;
            Circulo = asignarPropiedadesEllipse(Diametro, Opacidad);
        }
         public clsCirculo(int x, int y, int diametro, double opacidad)
        {
            EjeX = x;
            EjeY = y;
            Diametro = diametro;
            Opacidad = opacidad;
            //IsSeleccionado = false;
            //IsVisible = false;
            //Circulo = asignarPropiedadesEllipse(Diametro);
        }

        #endregion

        #region Métodos
        public Ellipse asignarPropiedadesEllipse(int diametro, double opacidad)
        {
            Ellipse circulo = new Ellipse();
            circulo.Width = diametro;
            circulo.Height = diametro;
            circulo.Stroke = new SolidColorBrush(Colors.Purple);
            circulo.StrokeThickness = 5;
            circulo.Opacity = opacidad;
            return circulo;
        }
        
        #endregion
    }
}
