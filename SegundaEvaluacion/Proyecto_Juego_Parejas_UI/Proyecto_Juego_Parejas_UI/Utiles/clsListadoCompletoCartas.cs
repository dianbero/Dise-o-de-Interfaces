using Proyecto_Juego_Parejas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_DAL.Utiles
{
    public class clsListoCompletoCartas
    {
        Uri imgNoVolteada = new Uri("ms - appx:///Assets/Images/xmen.jpg");
        
        public ObservableCollection<clsCarta> ListadoCompletoCartas()
        {
            ObservableCollection<clsCarta> listadoCartas = new ObservableCollection<clsCarta>();
            listadoCartas.Add(new clsCarta(0, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg"), imgNoVolteada));
            listadoCartas.Add(new clsCarta(1, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg"), imgNoVolteada));
            listadoCartas.Add(new clsCarta(2, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg"), imgNoVolteada));
            listadoCartas.Add(new clsCarta(3, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg"), imgNoVolteada));
            listadoCartas.Add(new clsCarta(4, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg"), imgNoVolteada));
            listadoCartas.Add(new clsCarta(5, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg"), imgNoVolteada));

            return listadoCartas;
        }

        public ObservableCollection<clsCarta> ListadoCompletoCartasEnCasilla()
        {
            ObservableCollection<clsCarta> listadoCastas = ListadoCompletoCartas();
            Random random = new Random();
            int rdnNumber = random.Next(13); //genera numero entre de 0 a 12 (excluye 13)

            for (int i = 0; i < listadoCastas.Count(); i++)
            {

            }
        }
    }
}
