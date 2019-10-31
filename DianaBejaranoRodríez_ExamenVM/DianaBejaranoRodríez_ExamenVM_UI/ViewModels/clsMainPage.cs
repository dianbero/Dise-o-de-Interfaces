using DianaBejaranoRodríez_ExamenVM_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_UI.ViewModels
{
    public class clsMainPage : INotifyPropertychanged
    {
        private List<clsFabricante> listadoFabricantes;
        private List<clsModeloCoche> listadoModelo;
        private clsFabricante fabricanteSeleccionado;
        private clsModeloCoche modeloSeleccionado;

        public clsMainPage()
        {

        }
        
    }
}
