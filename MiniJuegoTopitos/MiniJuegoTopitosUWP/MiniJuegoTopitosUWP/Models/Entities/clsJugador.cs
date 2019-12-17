using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.Models.Entities
{
    public class clsJugador
    {
        private string nombreJugador;
        private int puntosJugador;
        private bool esGanadorTurno;

        //Constructor por defecto
        public clsJugador()
        {
            this.nombreJugador = "default name";
            this.puntosJugador = 0;
            this.esGanadorTurno = false;
        }

        public clsJugador(string nombreJugador, int puntosJugador, bool esGanadorTurno)
        {
            this.NombreJugador = nombreJugador;
            this.PuntosJugador = puntosJugador;
            this.EsGanadorTurno = esGanadorTurno;
        }

        //Propiedades públicas
        public string NombreJugador
        {
            get { return nombreJugador; }
            set { nombreJugador = value; }
        }

        public int PuntosJugador
        {
            get { return puntosJugador; }
            set { puntosJugador = value; }
        }
        
        public bool EsGanadorTurno
        {
            get { return esGanadorTurno; }
            set { esGanadorTurno = value; }
        }
    }
}
