using Examen2EvalUWP_BL.Lists;
using Examen2EvalUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsPersona> listadoPersonas;
        #endregion

        #region Propiedades Públicas
        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
            set
            {
                listadoPersonas = value;
                
            }
        }
        #endregion

        #region Contructor
        public MainPageVM()
        {
            //relleno listado
            //listadopersonas = obtenerlistadopersonas();
            ObtenerListadoPersonas();
        }
        #endregion

        #region Métodos
        private async void ObtenerListadoPersonas()
        {
            this.listadoPersonas = new ObservableCollection<clsPersona>();
            Task<ObservableCollection<clsPersona>> listado = new clsListaPersonas_BL().ListadoPersonasBL();
            ObservableCollection<clsPersona> listaPersonas = await listado;
            this.listadoPersonas = listaPersonas;

            NotifyPropertyChanged("ListadoPersonas");


        }
        #endregion
    }
}
