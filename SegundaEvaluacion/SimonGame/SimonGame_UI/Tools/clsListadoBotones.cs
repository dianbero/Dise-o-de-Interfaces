using SimonGame_UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonGame_UI.Tools
{
    public class clsListadoBotones
    {
        /// <summary>
        /// Método que devuelve los distintos botones
        /// </summary>
        /// <returns>ObservableCollection<clsBoton> listadoBotonesAux, lista con elementos</returns>
        public ObservableCollection<clsBoton> ListadoBotones()
        {
            ObservableCollection<clsBoton> listadoBotones = new ObservableCollection<clsBoton>();
            listadoBotones.Add(new clsBoton(0, "Red", "ms-appx:///Assets/Sonidos/Meow.ogg"));
            listadoBotones.Add(new clsBoton(1, "Blue", "ms-appx:///Assets/Sonidos/jump02.ogg"));
            listadoBotones.Add(new clsBoton(2, "Green", "ms-appx:///Assets/Sonidos/mutant_frog-1.ogg"));
            listadoBotones.Add(new clsBoton(3, "Yellow", "ms-appx:///Assets/Sonidos/coin02.ogg"));

            return listadoBotones;
        }

        //TODO método que genere la lista que irá mostrando los sonidos (botones) aleatorios
        /// <summary>
        /// Método que genera sonidos aleatorios y los va añadiendo a una lista
        /// </summary>
        /// <param name="listaSonidosAleatorio">Nueva lista donde se irán guardando los sonidos aleatorios generados</param>
        /// <returns>ObservableCollection<clsBoton> listaSonidosAleatorio, lista con los sonidos aleatorios guardados</returns>
        public void GenerarSonidosAleatorios(ObservableCollection<clsBoton> listaSonidosAleatorio)
        {
            //ObservableCollection<clsBoton> listaSonidosAleatorio = new ObservableCollection<clsBoton>();
            ObservableCollection<clsBoton> listadoConSonidosAux = ListadoBotones();

            Random random = new Random();
            int num = random.Next(listadoConSonidosAux.Count);
            listaSonidosAleatorio.Add(listadoConSonidosAux[num]);


            //return listaSonidosAleatorio;
        }
        
    }
}
