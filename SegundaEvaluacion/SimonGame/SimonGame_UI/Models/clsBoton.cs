using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonGame_UI.Models
{
    public class clsBoton
    {
        #region Atributos Privados
        private int id;
        private string color;
        private string sonido;
        private int ordenBoton; //No sé si hace falta, puede ser el id y yasta
        #endregion

        #region Propiedades Públicas
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public string Sonido
        {
            get
            {
                return sonido;
            }
            set
            {
                sonido = value;
            }
        }

        public int OrdenBoton
        {
            get
            {
                return ordenBoton;
            }
            set
            {
                ordenBoton = value;
            }
        }
        #endregion

        #region Constructor
        //Por defecto
        public clsBoton()
        {
            this.id = 0;
            this.color = "Red";
            this.sonido = "";
            this.ordenBoton = 0;
        }

        public clsBoton(int id, string color, string sonido, int ordenBoton)
        {
            this.id = id;
            this.color = color;
            this.sonido = sonido;
            this.ordenBoton = ordenBoton;
        }
        #endregion
    }
}
