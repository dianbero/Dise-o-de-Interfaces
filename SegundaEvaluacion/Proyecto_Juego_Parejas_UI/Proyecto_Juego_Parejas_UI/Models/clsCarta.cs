using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_Entities
{
    public class clsCarta : clsVMBase
    {
        //Atributos privados
        private int idCarta;
        private bool isVolteada;
        private Uri imgVolteada;
        private Uri imgNoVolteada;
        private Uri imgMostrar;

        public clsCarta()
        {

        }

        //public clsCarta(int idCarta, Uri imgNoVolteada)
        //{            
        //    this.idCarta = idCarta;
        //    this.imgNoVolteada = imgNoVolteada;
        //    this.imgMostrar = new Uri("ms-appx:///Assets/Images/xmen.jpg");
        //}

        public clsCarta(int idCarta, bool isVolteada, Uri imgVolteada)
        {
            this.idCarta = idCarta;
            this.isVolteada = isVolteada;
            this.imgVolteada = imgVolteada;
            this.imgNoVolteada = new Uri("ms-appx:///Assets/Images/xmen.jpg");
            this.imgMostrar = imgNoVolteada;
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
            set {
                isVolteada = value;

                if (isVolteada)
                {
                    imgMostrar = imgVolteada;
                }
                else
                {
                    imgMostrar = imgNoVolteada;
                }
                NotifyPropertyChanged("ImgMostrar");
            }
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
            get {
                return imgMostrar;
            }
            
        }
    }
}
