using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PuntuarCombateMarvelUWP_Entities
{
    public class clsLuchador
    {
        #region Atributos Privados
        private int idLuchador;
        private string nombreLuchador;
        byte[] fotoLuchador;
        //Prueba
        BitmapImage foto;
        private Image imagen;

        #endregion

        #region Propiedades Públicas
        public int IdLuchador { get => idLuchador; set => idLuchador = value; }
        public string NombreLuchador { get => nombreLuchador; set => nombreLuchador = value; }
        public byte[] FotoLuchador { get => fotoLuchador; set => fotoLuchador = value; }


        #endregion

        #region Constructor
        public clsLuchador()
        {
            this.idLuchador = 0;
            this.nombreLuchador = "Default";
            this.fotoLuchador = new byte[5];
        }
        public clsLuchador(int idLuchador, string nombreLuchador, byte[] fotoLuchador)
        {
            this.idLuchador = idLuchador;
            this.nombreLuchador = nombreLuchador;
            this.fotoLuchador = fotoLuchador;

        }

        #endregion


    }
}
