using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas_Entities
{
    class clsCasilla : INotifyPropertyChanged
    {
        //Atributos privados
        public bool esBomba;
        private string imagenMostrada;
        public int posicion;

        public clsCasilla()
        {
            this.esBomba = false;
            this.imagenMostrada = "Assets\\Imagenes\\presionar.png"; //Imagen que se muestra al principio
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ImagenMostrada
        {
            get
            {
                //cambiarImagen();
                return imagenMostrada;
            }
            set
            {

            }
        }
        public bool esbomba
        {
            get
            {
                //Con una sola imagen, cambiar imagen en get
                return esbomba;
            }
            set
            {
                esBomba = value;
            }
        }
    }
}
