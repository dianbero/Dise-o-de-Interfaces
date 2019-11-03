using DianaBejaranoRodríez_ExamenVM_Entities;
using DianaBejaranoRodríez_ExamenVM_UI.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_UI.ViewModels
{
    public class clsMainPage : INotifyPropertyChanged
    {
        private List<clsFabricante> listadoFabricantes;
        private List<clsModeloCoche> listadoModelos;

        public event PropertyChangedEventHandler PropertyChanged;

        private clsFabricante fabricanteSeleccionado;
        private clsModeloCoche modeloSeleccionado;

        public clsMainPage()
        {
            //TODO: rellenar listado modelos y fabricantes, poque los necesita la vista   
            this.ListadoFabricantes = clsListados.ListadoFabricantes(); //Relleno lista fabricantes
            this.ListadoModelos = clsListados.ListadoModelos(); //Relleno listado modelos
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<clsFabricante> ListadoFabricantes
        {
            get { return listadoFabricantes; }
            set { listadoFabricantes = value; }
        }

        public List<clsModeloCoche> ListadoModelos
        {
            get { return listadoModelos; }
            set { listadoModelos = value; }
        }     

        public clsFabricante FabricanteSeleccionado
        {
            get { return fabricanteSeleccionado; }
            set
            {
                fabricanteSeleccionado = value;
                NotifyPropertyChanged("FabricanteSeleccionado");
            }
        }
        public clsModeloCoche ModeloSeleccionado
        {
            get { return modeloSeleccionado; }
            set { modeloSeleccionado = value; }
        }
    }
}
