using Coronavirus_DAL.Handlers;
using Coronavirus_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_BL.Handlers
{
    public class clsInsertarPersonaBL
    {
        /// <summary>
        /// Método que inserta una nueva persona en la BD.
        /// Devuelve un entero que representa el número de filas afectadas por la sentencia ejecutada.
        /// Si ese entero es distinto de 1, no se habrá ejecutado correctamente, porque debe insertar un registro.
        /// </summary>
        /// <param name="nuevaPersona">Objeto clsPersona con los datos de la nueva persona a insertar</param>
        /// <returns>int con el número de filas afectadas al ejecutarse</returns>
        public int insertarPersona(clsPersona nuevaPersona)
        {
            return new clsInsertarPersonaDAL().insertarPersona(nuevaPersona);
        }
    }
}
