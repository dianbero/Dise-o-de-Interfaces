using SimonGame_Entities;
using SimonGame_UI.ViewModels.ViewmodelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonGame_UI.ViewModels
{
    public class clsRankingVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsJugador> rankingJugadores;
        #endregion

        #region Propiedades Públicas

        public ObservableCollection<clsJugador> RankingJugadores
        {
            get
            {
                return rankingJugadores;
            }            
        }
        #endregion

        #region Constructor
        public clsRankingVM()
        {
            //Relleno lista jugadores
            try
            {
                rankingJugadores = new clsOperacionesJugadorBL().GetListaJugadores();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
