using BuscaMinas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas_UI.Utilidades
{
    public class clsListadoCasillas
    {
        //public List<clsCasilla> ListadoCompletoCasillas()
        //{
        //    List<clsCasilla> listadoCasillas = new List<clsCasilla>();

        //    listadoCasillas.Add(new clsCasilla(true, 1));
        //    listadoCasillas.Add(new clsCasilla(true, 2));
        //    listadoCasillas.Add(new clsCasilla(true, 3));
        //    listadoCasillas.Add(new clsCasilla(true, 4));
        //    listadoCasillas.Add(new clsCasilla(false, 5));
        //    listadoCasillas.Add(new clsCasilla(false, 6));
        //    listadoCasillas.Add(new clsCasilla(false, 7));
        //    listadoCasillas.Add(new clsCasilla(false, 8));
        //    listadoCasillas.Add(new clsCasilla(false, 9));
        //    listadoCasillas.Add(new clsCasilla(false, 10));
        //    listadoCasillas.Add(new clsCasilla(false, 11));
        //    listadoCasillas.Add(new clsCasilla(false, 12));
        //    listadoCasillas.Add(new clsCasilla(false, 13));
        //    listadoCasillas.Add(new clsCasilla(false, 14));
        //    listadoCasillas.Add(new clsCasilla(false, 15));
        //    listadoCasillas.Add(new clsCasilla(false, 16));

        //    return listadoCasillas;
        }

        //Creación de lista para 12 casillas que no son bomba

        /// <summary>
        /// Método para la creación de listados de Casillas
        /// </summary>
        /// <returns></returns>
        public List<clsCasilla> ListacoCompletoCasillas()
        {
            List<clsCasilla> listaCasillas = new List<clsCasilla>();

            for (int posicionB = 0; posicionB < 4; posicionB++)
            {
                listaCasillas.Add(new clsCasilla(true, posicionB));
            }

            for (int posicion = 4; posicion < 16; posicion++)
            {
                listaCasillas.Add(new clsCasilla(false, posicion));
            }

            return listaCasillas;
        }
        //Falta implementación de posicionamiento aleatorio en grid y la cuenta de 5 pulsaciones

    }
}
