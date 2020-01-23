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
        
        private ObservableCollection<clsCarta> ListadoCompletoCartas()
        {
            ObservableCollection<clsCarta> listadoCartas = new ObservableCollection<clsCarta>();
            listadoCartas.Add(new clsCarta(0, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(1, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(2, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(3, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(4, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg")));
            listadoCartas.Add(new clsCarta(5, false, new Uri("ms - appx:///Assets/Images/spiderman.jpg")));

            return listadoCartas;
        }

        public ObservableCollection<clsCarta> ListadoCompletoCartasEnCasilla()
        {
            //lista con cartas
            ObservableCollection<clsCarta> listadoCartas = ListadoCompletoCartas();
            //listado de cartas para asignar en casillas
            ObservableCollection<clsCarta> listadoCasillas = new ObservableCollection<clsCarta>();
            Random random = new Random();
            int rdnNumber = random.Next(13); //genera numero entre de 0 a 12 (excluye 13)


            //TODO comprobar que esta implementación para asignar las cartas funciona
            //Asignar primeras 6 cartas a casilla
            for (int i = 0; i < 6; i++)
            {
                //listadoCasillas.Add(listadoCartas[rdnNumber]);
                for(int j=0; i<listadoCasillas.Count(); i++)
                {
                    //Si ninguna de las cartas anteriores es igual a la del numero random asignado entonces la añade al array
                    if(listadoCartas[rdnNumber] != listadoCartas[i])
                    {
                        listadoCasillas.Add(listadoCartas[rdnNumber]); 
                    }
                }
            }


            //Asignar parejas a casilla
            for (int i = 0; i < 6; i++)
            {
                //listadoCasillas.Add(listadoCartas[rdnNumber]);
                for (int j = 5; i < listadoCasillas.Count(); i++)
                {
                    //Si ninguna de las cartas anteriores es igual a la del numero random asignado entonces la añade al array
                    if (listadoCartas[rdnNumber] != listadoCartas[i])
                    {
                        listadoCasillas.Add(listadoCartas[rdnNumber]);
                    }
                }
            }

            ////Asignar parejas a casilla
            //for (int i = 0; i < 6; i++)
            //{
            //    listadoCasillas.Add(listadoCartas[rdnNumber]);
            //}

            return listadoCasillas;
        }
    }
}
