using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_SpaceShipGame.Entities
{
    public class clsNave
    {
        private int EjeX { get; set; }
        private int EjeY { get; set; }
        private int Velocidad { get; set; }
        private  Uri Imagen { get; }

        public clsNave(int ejeX, int ejeY, int velocidad)
        {
            EjeX = ejeX;
            EjeY = ejeX;
            Velocidad = velocidad;
        }
    }
}
