using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.Models.Entities
{
    public class clsTopito
    {
        private int posicion;
        private bool isGolpeado;
        //Atributos que no tengo claro 
        private Uri fotoTopito; 
        private bool isVisible;

        public clsTopito()
        {
            this.Posicion = 0;
            this.IsGolpeado = false;
            this.FotoTopito = new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg");
            this.IsVisible = false;
        }

        //Constructor sin foto
        public clsTopito(int posicion, bool isGolpeado, bool isVisible)
        {
            this.Posicion = posicion;
            this.IsGolpeado = isGolpeado;
            this.IsVisible = isVisible;
        }
        //Constructor con foto
        public clsTopito(int posicion, bool isGolpeado, Uri fotoTopito, bool isVisible)
        {
            this.Posicion = posicion;
            this.IsGolpeado = isGolpeado;
            this.FotoTopito = fotoTopito;
            this.IsVisible = isVisible;
        }

        #region Propiedades Públicas
        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public bool IsGolpeado
        {
            get { return isGolpeado; }
            set { isGolpeado = value; }
        }

        public Uri FotoTopito
        {
            get { return fotoTopito; }

            set { fotoTopito = value; }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        #endregion
    }
}
