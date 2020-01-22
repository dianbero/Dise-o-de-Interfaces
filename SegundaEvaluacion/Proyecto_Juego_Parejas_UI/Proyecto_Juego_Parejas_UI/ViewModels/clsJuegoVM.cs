using Proyecto_Juego_Parejas_Entities;
using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Propiedades Públicas
        private clsCarta cartaSelaccionada;
        private ObservableCollection<clsCarta> listadoCompletoCartas;
        #endregion
        #region Constructores
        public clsJuegoVM()
        {            
            listadoCompletoCartas = 
        }
        #endregion
    }
}
