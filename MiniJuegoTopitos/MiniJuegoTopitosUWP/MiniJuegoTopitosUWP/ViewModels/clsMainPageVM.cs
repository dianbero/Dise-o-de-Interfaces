using MiniJuegoTopitosUWP.Models.Entities;
using MiniJuegoTopitosUWP.Models.Utiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        #region Atributos Privados
        private Uri uriFoto;
        private DelegateCommand comandoMostrarTopo;

        private ObservableCollection<clsTopito> listaTopos;
        private clsTopito topoGolpeado;
        #endregion

        #region Propiedades Públicas
        public Uri UriFoto
        {
            get { return uriFoto; }
            set { uriFoto = value; }
        }

        public ObservableCollection<clsTopito> ListaTopos
        {
            get
            {
                return listaTopos;
            }
            set
            {
                listaTopos = value;
            }
        }

        public clsTopito TopoGolpeado
        {
            get
            {
                return topoGolpeado;
            }
            set
            {
                topoGolpeado = value;
                if (topoGolpeado.IsGolpeado)
                {
                    topoGolpeado.FotoTopito = new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg");
                    NotifyPropertyChanged("UriFoto");
                }
                NotifyPropertyChanged("ListaTopos");
            }
        }

        #endregion

        #region Constructores
        //Constructor por defecto
        public clsMainPageVM()
        {
            //comandoMostrarTopo = 
            //uriFoto = new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg");

            //TODO rellenar la lista
            clsUtil obtenerFoto = new clsUtil();
            //this.UriFoto = obtenerFoto.
        }

        #endregion

        #region Métodos

        #endregion

        #region Commands
        
        #endregion


    }
}
