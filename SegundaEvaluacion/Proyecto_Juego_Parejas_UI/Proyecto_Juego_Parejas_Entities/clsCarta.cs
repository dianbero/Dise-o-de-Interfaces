using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_Entities
{
    public class clsCarta
    {
        //Atributos privados
        private int idCarta;
        private bool isVolteada;
        private Uri imgVolteada;
        private Uri imgNoVolteada;
        private Uri imgMostrar;

        public clsCarta(int idCarta, Uri imgNoVolteada)
        {
            //imgMostrar = new Uri("ms-appx:///Assets/Images/xmen.jpg");
            this.idCarta = idCarta;
            this.imgNoVolteada = imgNoVolteada;
        }

        public clsCarta(int idCarta, bool isVolteada, Uri imgVolteada)
        {
            this.idCarta = idCarta;
            this.isVolteada = isVolteada;
            this.imgVolteada = imgVolteada;
            this.imgMostrar = new Uri("ms-appx:///Assets/Images/xmen.jpg");
        }

        //Propieades públicas
        public int IdCarta
        {
            get { return idCarta; }
            set { idCarta = value; }
        }
        public bool IsVolteada
        {
            get { return isVolteada; }
            set { isVolteada = value; }
        }

        public Uri ImgVolteada
        {
            get { return imgVolteada; }
            set { imgVolteada = value; }
        }
        public Uri ImgNoVolteada
        {
            get { return imgNoVolteada; }
            set { imgNoVolteada = value; }
        }
        public Uri ImgMostrar
        {
            get { return imgMostrar; }
            set { imgMostrar = value; }
        }
    }
}
