using _20_FindDiffrences.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_SpaceShipGame.Utiles
{
    public class clsListaCirculos
    {
        public static ObservableCollection<clsCirculo> listaCirculos()
        {
            ObservableCollection<clsCirculo> circulos = new ObservableCollection<clsCirculo>();
            circulos.Add(new clsCirculo(60, 190)); //calcetin
            circulos.Add(new clsCirculo(95, 70)); //patin
            circulos.Add(new clsCirculo(245, 90)); //mosca
            circulos.Add(new clsCirculo(90, 10)); //ropa
            circulos.Add(new clsCirculo(305, 30)); //cuadro
            circulos.Add(new clsCirculo(15, 315)); //mochila
            circulos.Add(new clsCirculo(398, 338)); //balón
            circulos.Add(new clsCirculo(390, 140)); //cabecero

            return circulos;
        }
    }
}
