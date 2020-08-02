using PuntuarCombateMarvelUWP_DAL.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntuarCombateMarvelUWP_BL.Lists
{
    public class clsListadosCombatesBL
    {
        /// <summary>
        /// Método que obtiene el id de un combate según los luchadores que participan y la fecha 
        /// </summary>
        /// <param name="idLuchador1">int con id del luchador 1</param>
        /// <param name="idLuchador2">int con id del luchador 2</param>
        /// <param name="fechaCombate">DateTime con la fecha del combate</param>
        /// <returns></returns>
        public int getIdCombate(int idLuchador1, int idLuchador2, DateTime fechaCombate)
        {
            return new clsListadosCombatesDAL().getIdCombate(idLuchador1, idLuchador2, fechaCombate);
        }
    }
}
