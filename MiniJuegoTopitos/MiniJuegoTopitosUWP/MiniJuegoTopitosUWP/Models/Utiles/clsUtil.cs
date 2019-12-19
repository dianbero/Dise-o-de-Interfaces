using MiniJuegoTopitosUWP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.Models.Utiles
{
    public class clsUtil
    {
        public ObservableCollection<clsTopito> listaCasillasTopo()
        {
            ObservableCollection<clsTopito> listaTopos = new ObservableCollection<clsTopito>();
            for(int posicionTopo=0; posicionTopo<16; posicionTopo++)
            {
                listaTopos.Add(new clsTopito(posicionTopo, false, false)); 
            }

            return listaTopos;
        }

        public ObservableCollection<clsTopito> asignarPosiciontopo()
        {
            int random = clsPartida.asignarPosicionTopo();

            ObservableCollection<clsTopito> listaTopos = new ObservableCollection<clsTopito>();
            listaTopos[random].IsVisible = true;
            return listaTopos;

        }
    }
}
