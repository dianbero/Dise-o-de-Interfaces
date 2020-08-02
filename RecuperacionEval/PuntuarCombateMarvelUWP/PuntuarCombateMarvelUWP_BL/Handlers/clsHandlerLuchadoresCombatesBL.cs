using PuntuarCombateMarvelUWP_DAL.Handlers;
using PuntuarCombateMarvelUWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_BL.Handlers
{
    public class clsHanlerLuchadoresCombatesBL
    {
        /// <summary>
        /// Método que inserta un nuevo registro en tabla SH_LuchadoresCombates
        /// </summary>
        /// <param name="nuevoLuchadorCombate">clsLuchadorCombate, con los datos del objeto a insertar</param>
        /// <returns>int filasAfectadas, con el número de filas afectadas por la sentencia</returns>
        public int insertarLuchadorCombate(clsLuchadorCombate nuevoLuchadorCombate)
        {
            return new clsHandlerLuchadoresCombatesDAL().insertarLuchadorCombate(nuevoLuchadorCombate);
        }

        /// <summary>
        /// Método que actualiza la puntuación de un lucchador en un combate
        /// </summary>
        /// <param name="nuevaPuntuacionLuchadorCombate">clsLuchadorCombate con los datos para actualizar el registro con la nueva puntuación</param>
        /// <returns>int filasAfectadas, con número de filas afectadas por la ejecución</returns>
        public int actualizarPuntuacionLuchadorCombate(clsLuchadorCombate nuevaPuntuacionLuchadorCombate)
        {
            return new clsHandlerLuchadoresCombatesDAL().actualizarPuntuacionLuchadorCombate(nuevaPuntuacionLuchadorCombate);
        }
    }
}
