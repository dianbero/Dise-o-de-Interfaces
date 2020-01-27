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
        
        private ObservableCollection<clsCarta> ListadoCompletoCartas()
        {
            ObservableCollection<clsCarta> listadoCartas = new ObservableCollection<clsCarta>();
            listadoCartas.Add(new clsCarta(0, false, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listadoCartas.Add(new clsCarta(1, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(2, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(3, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(4, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(5, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));

            return listadoCartas;
        }

        public ObservableCollection<clsCarta> ListadoCompletoCartasEnCasilla()
        {
            //lista con cartas            
            ObservableCollection<clsCarta> listadoCartas = ListadoCompletoCartas();
            //listado de cartas para asignar en casillas
            ObservableCollection<clsCarta> listadoCasillas = new ObservableCollection<clsCarta>();
            Random random = new Random();
            int rdnNumber= random.Next(13); //genera numero entre de 0 a 12 (excluye 13)


            //TODO comprobar que esta implementación para asignar las cartas funciona
            //Asignar primeras 6 cartas a casilla
            //for (int i = 0; i < 6; i++)
            //{
            //    //listadoCasillas.Add(listadoCartas[rdnNumber]);
            //    for(int j=0; i<listadoCasillas.Count(); i++)
            //    {
            //        //Si ninguna de las cartas anteriores es igual a la del numero random asignado entonces la añade al array
            //        if(listadoCartas[rdnNumber] != listadoCartas[i])
            //        {
            //            listadoCasillas.Add(listadoCartas[rdnNumber]); 
            //        }
            //    }
            //}


            //Asignar parejas a casilla
            for (int i = 0; i < 6; i++)
            {
                if (listadoCartas[rdnNumber] != listadoCartas[i])
                {
                    listadoCasillas.Add(listadoCartas[rdnNumber]);
                }
                else
                {
                    rdnNumber = random.Next(13);
                }
            }
            //Asignación parejas
            for (int i = 5; i < listadoCasillas.Count(); i++)
            {
                //Si ninguna de las cartas anteriores es igual a la del numero random asignado entonces la añade al array
                if (listadoCartas[rdnNumber] != listadoCartas[i])
                {
                    listadoCasillas.Add(listadoCartas[rdnNumber]);
                }
                //TODO implementar qué hace cuando coincide con todas las cartas ya asignadas anteriormente
            }
            

            return listadoCasillas;
        }

        //Lista falsa para probar funcionamiento del bindeo
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsCarta> listadoCartas()
        {
            ObservableCollection<clsCarta> listado = new ObservableCollection<clsCarta>();
            //ObservableCollection<clsCarta> lis = ListadoCompletoCartas(); 

            listado.Add(new clsCarta(1, false, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listado.Add(new clsCarta(2, false, new Uri("ms-appx:///Assets/Images/blackPanter.jpg")));
            listado.Add(new clsCarta(3, true, new Uri("ms-appx:///Assets/Images/captainAmerica.jpg")));
            listado.Add(new clsCarta(4, false, new Uri("ms-appx:///Assets/Images/deadpool.jpg")));
            listado.Add(new clsCarta(5, false, new Uri("ms-appx:///Assets/Images/ironman.jpg")));
            listado.Add(new clsCarta(6, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));
            listado.Add(new clsCarta(7, false, new Uri("ms-appx:///Assets/Images/antman.jpg")));
            listado.Add(new clsCarta(8, true, new Uri("ms-appx:///Assets/Images/blackPanter.jpg")));
            listado.Add(new clsCarta(9, false, new Uri("ms-appx:///Assets/Images/captainAmerica.jpg")));
            listado.Add(new clsCarta(10, false, new Uri("ms-appx:///Assets/Images/deadpool.jpg")));
            listado.Add(new clsCarta(11, false, new Uri("ms-appx:///Assets/Images/ironman.jpg")));
            listado.Add(new clsCarta(12, false, new Uri("ms-appx:///Assets/Images/spiderman.jpg")));

            return listado;
        }
    }
}
