using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Juego_Parejas_Entities
{
    public class clsJugador
    {
        //Atributos privados
        private int idJugador;
        private string nombreJugador;
        private DateTime puntuacion;

        public clsJugador()
        {
            idJugador = 0;
            nombreJugador = "default";
            puntuacion = new DateTime();
        }

        public clsJugador(int idJugador, string nombreJugador, DateTime puntuacion)
        {
            this.idJugador = idJugador;
            this.nombreJugador = nombreJugador;
            this.puntuacion = puntuacion;
        }

        //Propiedades públicas
        public int IdJugador
        {
            get { return idJugador; }
            set { idJugador = value; }
        }

        public string NombreJugador
        {
            get { return nombreJugador; }
            set { nombreJugador = value; }
        }

        public DateTime Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }

    }
}
