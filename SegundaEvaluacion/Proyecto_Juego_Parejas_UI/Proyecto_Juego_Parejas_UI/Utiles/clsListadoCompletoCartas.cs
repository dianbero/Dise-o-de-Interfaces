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
        //Uri imgNoVolteada = new Uri("ms-appx:///Assets/Images/xmen.jpg");
        
        private ObservableCollection<clsCarta> ListadoCartasAuxiliar()
        {
            ObservableCollection<clsCarta> listadoCartas = new ObservableCollection<clsCarta>();
            listadoCartas.Add(new clsCarta(0, false, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listadoCartas.Add(new clsCarta(1, false, new Uri("ms-appx:///Assets/Images/blackPanter.jpg")));
            listadoCartas.Add(new clsCarta(2, false, new Uri("ms-appx:///Assets/Images/captainAmerica.jpg")));
            listadoCartas.Add(new clsCarta(3, false, new Uri("ms-appx:///Assets/Images/deadpool.jpg")));
            listadoCartas.Add(new clsCarta(4, false, new Uri("ms-appx:///Assets/Images/ironman.jpg")));
            listadoCartas.Add(new clsCarta(5, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            
            //Mismos elementos para parejas
            listadoCartas.Add(new clsCarta(0, false, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listadoCartas.Add(new clsCarta(1, false, new Uri("ms-appx:///Assets/Images/blackPanter.jpg")));
            listadoCartas.Add(new clsCarta(2, false, new Uri("ms-appx:///Assets/Images/captainAmerica.jpg")));
            listadoCartas.Add(new clsCarta(3, false, new Uri("ms-appx:///Assets/Images/deadpool.jpg")));
            listadoCartas.Add(new clsCarta(4, false, new Uri("ms-appx:///Assets/Images/ironman.jpg")));
            listadoCartas.Add(new clsCarta(5, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));

            return listadoCartas;
        }

        public ObservableCollection<clsCarta> ListadoCompletoCartasEnCasilla()
        {
            //lista con cartas            
            ObservableCollection<clsCarta> listadoCartas = ListadoCartasAuxiliar();
            //listado de cartas para asignar en casillas
            ObservableCollection<clsCarta> listadoCasillas = new ObservableCollection<clsCarta>();
            Random rdm = new Random();
            int random; 

            while (listadoCartas.Count > 0)
            {
                random = rdm.Next(0, listadoCartas.Count);
                listadoCasillas.Add(listadoCartas[random]);
                //Quitar elementos para evitar repetición
                listadoCartas.RemoveAt(random);
               
            }
                                 
            return listadoCasillas;
        }
    }
}
