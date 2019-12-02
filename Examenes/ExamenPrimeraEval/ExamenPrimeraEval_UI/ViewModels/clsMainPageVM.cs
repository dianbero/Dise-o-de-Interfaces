using ExamenPrimeraEval_BL.Lists;
using ExamenPrimeraEval_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Diana Bejarano

namespace ExamenPrimeraEval_UI.ViewModels
{
    class clsMainPageVM : clsVMBase
    {
        #region Atributos Privados
        private bool misionReservada;
        private ObservableCollection<clsSuperHeroe> listadoSuperHeroes;
        private ObservableCollection<clsMision> listadoMisiones;
        private clsSuperHeroe superHeroeSeleccionado;
        private clsMision misionSeleccionada;

        #endregion

        # region Propiedades Públicas

        public bool MisionReservada
        {
            get { return misionReservada; }
            set { misionReservada = value; }
        }

        public ObservableCollection<clsSuperHeroe> ListadoSuperHeroes
        {
            get { return listadoSuperHeroes; }
            set { listadoSuperHeroes = value; }
        }

        public ObservableCollection<clsMision> ListadoMisiones
        {
            get { return listadoMisiones; }
            set { listadoMisiones = value; }
        }

        public clsSuperHeroe SuperHeroeSeleccionado
        {
            get { return superHeroeSeleccionado; }
            set {
                if(SuperHeroeSeleccionado != null)
                {
                    superHeroeSeleccionado = value;
                    NotifyPropertyChanged("SuperHeroeSeleccionado");
                }                
            }
        }

        public clsMision MisionSeleccionada
        {
            get { return misionSeleccionada; }
            set { misionSeleccionada = value; }
        }

        #endregion

        #region Contructores
        public clsMainPageVM()
        {
            //Obtener lista superHeroes
            clsListadoSuperHeroesBL listaSuperHeoresBL = new clsListadoSuperHeroesBL();
            this.listadoSuperHeroes = listaSuperHeoresBL.ListadoSuperHeroes();
        }
        #endregion

        #region Commands


        #endregion


    }
}
