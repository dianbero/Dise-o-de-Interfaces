using Proyecto_Juego_Parejas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_DAL.Utiles
{
    public class clsListadoCompletoCartas
    {
        /// <summary>
        /// Método que devuelve un listado auxiliar con las cartas y sus parejas
        /// </summary>
        /// <returns>ObservableCollection<clsCarta> listadoCartas, con el listado de las cartas del tablero</returns>
        private ObservableCollection<clsCarta> ListadoCartasAuxiliar()
        {
            ObservableCollection<clsCarta> listadoCartas = new ObservableCollection<clsCarta>();
            listadoCartas.Add(new clsCarta(0, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listadoCartas.Add(new clsCarta(1, new Uri("ms-appx:///Assets/Images/blackPanter.jpg")));
            listadoCartas.Add(new clsCarta(2, new Uri("ms-appx:///Assets/Images/captainAmerica.jpg")));
            listadoCartas.Add(new clsCarta(3, new Uri("ms-appx:///Assets/Images/deadpool.jpg")));
            listadoCartas.Add(new clsCarta(4, new Uri("ms-appx:///Assets/Images/ironman.jpg")));
            listadoCartas.Add(new clsCarta(5, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            
            //Mismos elementos para parejas
            listadoCartas.Add(new clsCarta(0, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listadoCartas.Add(new clsCarta(1, new Uri("ms-appx:///Assets/Images/blackPanter.jpg")));
            listadoCartas.Add(new clsCarta(2, new Uri("ms-appx:///Assets/Images/captainAmerica.jpg")));
            listadoCartas.Add(new clsCarta(3, new Uri("ms-appx:///Assets/Images/deadpool.jpg")));
            listadoCartas.Add(new clsCarta(4, new Uri("ms-appx:///Assets/Images/ironman.jpg")));
            listadoCartas.Add(new clsCarta(5, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));

            return listadoCartas;
        }

        /// <summary>
        /// Método que devuelve una lista de cartas ordenadas aleatoriamente
        /// </summary>
        /// <returns>ObservableCollection<clsCarta> listadoCartasAleatorias, con listado de cartas ordenadas aleatoriamente</returns>
        public ObservableCollection<clsCarta> ListadoCompletoCartasEnCasilla()
        {
            //lista con cartas            
            ObservableCollection<clsCarta> listadoCartas = ListadoCartasAuxiliar();
            //listado de cartas para asignar en casillas
            ObservableCollection<clsCarta> listadoCartasAleatorias = new ObservableCollection<clsCarta>();
            Random rdm = new Random();
            int random; 

            //Termina de generar cartas aleatorias cuando el listado auxiliar no tiene más cartas
            while (listadoCartas.Count > 0)
            {
                random = rdm.Next(0, listadoCartas.Count);
                listadoCartasAleatorias.Add(listadoCartas[random]);
                //Quita elementos para evitar repetición
                listadoCartas.RemoveAt(random);               
            }
                                 
            return listadoCartasAleatorias;
        }
    }
}
