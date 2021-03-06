﻿using CrearPruebaCamellos_DAL.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_BL.Handlers
{
    public class clsHandlersPruebasPalabrasBL
    {
        /// <summary>
        /// Método que inserta un nuevo registro en la tabla CJ_PruebasPalabras de la BBDD
        /// </summary>
        /// <param name="idPrueba"></param>
        /// <param name="idPalabra"></param>
        /// <returns>int filasAfectas, indicando número de registros afectados</returns>
        public int insertarPruebasPalabras(int idPrueba, int idPalabra)
        {
            return new clsHandlerPruebasPalabrasDAL().insertarPruebasPalabras(idPrueba, idPalabra);
        }
    }
}
