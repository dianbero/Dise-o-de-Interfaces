using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.ViewModels
{
    public class clsMainPageVM
    {
        #region Atributos Privados
        private Uri uriFoto;
        private DelegateCommand comandoMostrarTopo;
        


        #endregion

        #region Propiedades Públicas
        public Uri UriFoto
        {
            get { return uriFoto; }
            set { uriFoto = value; }
        }
        #endregion

        #region Constructores
        //Constructor por defecto
        public clsMainPageVM()
        {
            //comandoMostrarTopo = 
            uriFoto = new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg");
        }

        #endregion

        #region Métodos

        #endregion

        #region Commands
        
        #endregion


    }
}
