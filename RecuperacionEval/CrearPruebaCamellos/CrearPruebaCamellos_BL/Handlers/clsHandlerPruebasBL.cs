using CrearPruebaCamellos_DAL.Handlers;
using CrearPruebaCamellos_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_BL.Handlers
{
    public class clsHandlerPruebasBL
    {
        /// <summary>
        /// Método que inserta una nueva prueba y obtiene su idPrueba generado, de la BBDD
        /// </summary>
        /// <param name="nuevaPrueba">clsPrueba con los datos de la nueva prueba a insertar</param>
        /// <returns>int idPrueba, con el idPrueba generado al insertar la nueva prueba</returns>
        public int insertarPrueba(clsPrueba nuevaPrueba)
        {
            return new clsHandlerPruebasDAL().insertarPrueba(nuevaPrueba);
        }
    }
}
