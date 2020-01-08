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
        /// <summary>
        /// Crea lista inicial con topos 
        /// </summary>
        /// <returns>ObservableCollection<clsTopito> listaToposInicial: Lista de inicio</returns>
        public ObservableCollection<clsTopito> listaCasillasTopoInicial()
        {
            ObservableCollection<clsTopito> listaToposInicial = new ObservableCollection<clsTopito>();
            for (int posicionTopo = 0; posicionTopo < 16; posicionTopo++)
            {
                //listaToposInicial.Add(new clsTopito(posicionTopo, false, true));
                //listaToposInicial.Add(new clsTopito(posicionTopo, false, new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg"), true));
                listaToposInicial.Add(new clsTopito());
            }
            return listaToposInicial;
        }

        //Para una prueba
        //public ObservableCollection<clsTopito> listaCasillasTopoInicial()
        //{
        //    ObservableCollection<clsTopito> listaToposInicial = new ObservableCollection<clsTopito>();
        //    listaToposInicial.Add(new clsTopito(1, false, new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg"), true));
        //    listaToposInicial.Add(new clsTopito(2, false, new Uri("ms-appx:///Assets/Imagen_Topo/PokeTopo.jpg"), true));
        //    listaToposInicial.Add(new clsTopito(3, false, new Uri("ms-appx:///Assets/Imagen_Topo/PokeTopo.jpg"), true));
        //    return listaToposInicial;
        //}

        /// <summary>
        /// Asigna al topo que se mostrará en pantalla una posición aleatoria
        /// </summary>
        /// <returns>ObservableCollection<clsTopito> listaTopos: Lista con un topo en una posicion aleatoria</returns>
        public ObservableCollection<clsTopito> listaConPosicionTopoAsignada()
        {
            int random = clsPartida.asignarPosicionTopo(); //Asigna posición aleatoria

            ObservableCollection<clsTopito> listaTopos = listaCasillasTopoInicial();
            listaTopos[random].IsGolpeado = false;
            return listaTopos;
        }
    }
}
