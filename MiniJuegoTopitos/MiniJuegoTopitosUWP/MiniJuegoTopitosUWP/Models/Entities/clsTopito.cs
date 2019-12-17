using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.Models.Entities
{
    public class clsTopito
    {
        private int posicion;
        private bool isGolpeado;

        public clsTopito()
        {
            this.Posicion = 0;
            this.IsGolpeado = false;
        }

        public clsTopito(int posicion, bool isGolpeado)
        {
            this.Posicion = posicion;
            this.IsGolpeado = isGolpeado;
        }
        //Propiedades públicas
        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public bool IsGolpeado
        {
            get { return isGolpeado; }
            set { isGolpeado = value; }
        }
    }
}
