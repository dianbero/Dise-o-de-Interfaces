using PuntuarCombateMarvelUWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PuntuarCombateMarvelUWP_UI.ModelsExtra
{
    public class clsLuchadorConFoto : clsLuchador
    {
        #region Atributos Privados
        private BitmapImage imagen;
        #endregion

        #region Propiedades Públicas
        public BitmapImage Imagen { get => imagen; set => imagen = value; }
        #endregion

        #region Constructor
        public clsLuchadorConFoto()
        {
            this.imagen = new BitmapImage();
        }
        public clsLuchadorConFoto(int idLuchador, string nombreLuchador, byte[] fotoLuchador, BitmapImage imagen)
            : base(idLuchador, nombreLuchador, fotoLuchador)
        {
            this.imagen = imagen;
        }
        #endregion



    }
}
