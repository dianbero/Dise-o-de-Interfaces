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

        public clsCarta(int idCarta, Uri imgVolteada)
        {
            //imgMostrar = new Uri("ms - appx:///Assets/Images/xmen.jpg");
            this.idCarta = idCarta;
            this.imgVolteada = imgVolteada;
        }

        public clsCarta(int idCarta, bool isVolteada, Uri imgVolteada)
        {
            this.idCarta = idCarta;
            this.isVolteada = isVolteada;
            this.imgVolteada = imgVolteada;
            this.imgNoVolteada = new Uri("ms - appx:///Assets/Images/xmen.jpg");
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
            get { return ImgNoVolteada; }
            set { ImgNoVolteada = value; }
        }
    }
}
