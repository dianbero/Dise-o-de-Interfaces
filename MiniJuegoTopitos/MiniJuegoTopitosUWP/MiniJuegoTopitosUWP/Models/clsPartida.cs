using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.Models
{
    public class clsPartida
    {
        /*Funciones:
         - Calcular puntos de jugadores
         -*/

        public int sumarPuntos(int puntos, bool isGanadorTurno)
        {            
            if (isGanadorTurno)
            {
                puntos++;
            }
            return puntos;
        }
    }
}
