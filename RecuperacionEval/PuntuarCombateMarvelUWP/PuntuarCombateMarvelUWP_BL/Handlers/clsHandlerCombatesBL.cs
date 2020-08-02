using PuntuarCombateMarvelUWP_DAL.Handlers;
using PuntuarCombateMarvelUWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_BL.Handlers
{
    public class clsHandlerCombatesBL
    {
        /// <summary>
        /// Método que inserta un nuevo combate en la BBDD
        /// </summary>
        /// <param name="nuevoCombate">clsCombate con los datos del nuevo combate</param>
        /// <returns>int idCombate, del combate recién insertado</returns>
        public int insertarCombate(clsCombate nuevoCombate)
        {
            return new clsHandlerCombatesDAL().insertarCombate(nuevoCombate);
        }

        /// <summary>
        /// Método que comprueba si existe un combate según su fecha y los luchadores que participan
        /// </summary>
        /// <param name="idLuchador1">int con id del luchador 1</param>
        /// <param name="idLuchador2">int con id del luchador 2</param>
        /// <param name="fechaCombate">DateTime con la fecha del combate</param>
        /// <returns>int filasAfectadas, con número de filas afectadas</returns>
        public int checkExisteCombate(int idLuchador1, int idLuchador2, DateTime fechaCombate)
        {
            return new clsHandlerCombatesDAL().checkExisteCombate(idLuchador1, idLuchador2, fechaCombate);
        }
    }
}
