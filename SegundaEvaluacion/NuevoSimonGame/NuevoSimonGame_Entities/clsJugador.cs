﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevoSimonGame_Entities
{
    public class clsJugador
    {
        //Atributos privados
        private int idJugador;
        private string nombreJugador;
        private int aciertos;

        public clsJugador()
        {
            idJugador = 0;
            nombreJugador = "default";
            aciertos = 0;
        }

        public clsJugador(int idJugador, string nombreJugador, int aciertos)
        {
            this.idJugador = idJugador;
            this.nombreJugador = nombreJugador;
            this.aciertos = aciertos; 
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

        public int Aciertos
        {
            get { return aciertos; }
            set { aciertos = value; }
        }

    }
}
