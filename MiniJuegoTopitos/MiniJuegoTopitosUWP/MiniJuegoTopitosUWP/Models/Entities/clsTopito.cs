using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.Models.Entities
{
    public class clsTopito
    {
        private int posicionCasilla;
        private bool isGolpeado;
        private Uri fotoTopito;
        private bool isVisible;

        public clsTopito()
        {
            this.Posicion = 0;
            this.IsGolpeado = false;
        }

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
        //Propiedades públicas
        public int Posicion
        {
            get { return posicionCasilla; }
            set { posicionCasilla = value; }
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
    }
}
