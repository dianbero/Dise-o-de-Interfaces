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
            listadoBotones.Add(new clsBoton(1, "Red", "ms-appx:///Assets/Sonidos/Meow.ogg"));
            listadoBotones.Add(new clsBoton(2, "Blue", "ms-appx:///Assets/Sonidos/jump02.ogg"));
            listadoBotones.Add(new clsBoton(3, "Green", "ms-appx:///Assets/Sonidos/mutant_frog-1.ogg"));
            listadoBotones.Add(new clsBoton(4, "Yellow", "ms-appx:///Assets/Sonidos/coin02.ogg"));

            return listadoBotones;
        }

        //TODO método que genere la lista que irá mostrando los sonidos (botones) aleatorios
        public ObservableCollection<clsBoton> GenerarSonidosAleatorios()
        {
            ObservableCollection<clsBoton> listaSonidosAleatorio = new ObservableCollection<clsBoton>();

            return listaSonidosAleatorio;
        }

        /// <summary>
        /// Método que genera un lista con los elementos ordenados aleatoriamente
        /// </summary>
        /// <returns>ObservableCollection<clsBoton> listaBotonesDefinitiva, lista con elementos aleatorios</returns>
        public ObservableCollection<clsBoton> GenerarRandom()
        {
            int num;
            ObservableCollection<clsBoton> listaBotonesAux = ListadoBotones();
            ObservableCollection<clsBoton> listaBotonesDefinitiva = new ObservableCollection<clsBoton>();
            Random radom = new Random();
            
            //TODO cambiar, no quiero que los muestre de form aleatoria sino que vayan sonando de forma aleatoria
            while (listaBotonesDefinitiva.Count < 5)
            {
                num = radom.Next(listaBotonesAux.Count);
                listaBotonesDefinitiva.Add(listaBotonesAux[num]);
                listaBotonesAux.RemoveAt(num);
            }

            return listaBotonesDefinitiva;
        }
    }
}
