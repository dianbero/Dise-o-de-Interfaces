using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MiniJuegoTopitosUWP.Models
{
    public class clsPartida
    {
        /*Funciones:
         - Calcular puntos de jugadores
         - Calcular tiempo en que aparace topo
         -*/
        private static Timer timer;

        /// <summary>
        /// Método que suma un punto al gugador ganador del turno
        /// </summary>
        /// <param name="puntos"></param>
        /// <param name="isGanadorTurno"></param>
        /// <returns></returns>
        public static int sumarPuntos(int puntos, bool isGanadorTurno)
        {            
            if (isGanadorTurno)
            {
                puntos++;
            }
            return puntos;
        }

        //public static void setTimer()
        //{
        //    timer = new Timer(2000);
        //    timer.Elapsed += asignarPosicionTopo;
        //}

        //public static void asignarPosicionTopo(Object source, ElapsedEventArgs e)
        //{
        //    Random random = new Random();
        //    int posicion = random.Next(17); //Randoms de 0 - 16
        //}

        /// <summary>
        /// Método que genera un número aleatorio para la posición del todo en la casilla.
        /// </summary>
        /// <returns></returns>
        public static int asignarPosicionTopo()
        {
            Random random = new Random();
            int posicion = random.Next(16); //Randoms de 0 - 16
            return posicion;
        }
    }
}
