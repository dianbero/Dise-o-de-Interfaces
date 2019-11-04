using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas_Entities
{
    public class clsCasilla : INotifyPropertyChanged
    {
        //Atributos privados
        public bool esBomba;
        private string imagenMostrada;
        public int posicion;

        public clsCasilla()
        {
            //Estado inicial de las casillas
            this.EsBomba = false;
            this.ImagenMostrada = "Assets\\Imagenes\\presionar.png"; //Imagen que se muestra al principio
        }

        public clsCasilla(bool esBomba, int posicion)
        {
            this.esBomba = esBomba;
            this.Posicion = posicion;
            //No instancio imagen porque se la asignamos más tarde en Propiedad ImagenMostrada
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ImagenMostrada
        {
            get
            {
                cambiarImagen(); //Entiendo que si esBomba = true, la imagen cambia a la de bomba, por eso se llama al método aquí y devuelve la imagen cambiada
                return imagenMostrada;
            }
            set
            {
                imagenMostrada = value;
            }
        }
        public bool EsBomba
        {
            get
            {
                //Con una sola imagen, cambiar imagen en get... -> No lo entiendo
                return esBomba;
            }
            set
            {
                esBomba = value;
                NotifyPropertyChanged("ImagenMostrada"); //Entiendo que esBomba notifica el cambio de ImagenMostrada
            }
        }

        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        /// <summary>
        /// Si la casilla es una bomba, la imagen cambia a la de bomba
        /// </summary>
        private void cambiarImagen()
        {
            if (EsBomba)
            {
                imagenMostrada = "/Assets/Imagenes/bomba.png"; //Imagen de bomba
            }
            else
            {
                imagenMostrada = "/Assets/Imagenes/salvado.png"; //Imagen salvado si no es bomba
            }
        }
    }
}
