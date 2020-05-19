using Hospital_DAL.Handlers;
using Hospital_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_BL.Handlers
{
    public class clsHandlerHospitalBL
    {
        /// <summary>
        /// Método que obitene un objeto clsMedico de la BD a partir del código del médico que se desea obtener
        /// </summary>
        /// <param name="codigoMedico">string con el código del médico deseado</param>
        /// <returns>clsMedico objMedico, con los datos del médico deseado</returns>
        public clsMedico getMedico(string codigoMedico)
        {
            return new clsHandlerHospitalDAL().getMedico(codigoMedico);
        }

        /// <summary>
        /// Método que comprueba que el médico devolviendo un entero con la cantidad de filas afectadas por la sentencia
        /// Que deberá ser una sola
        /// </summary>
        /// <param name="codigoMedico">string con el código del médico deseado</param>
        /// <returns>int filasAfectadas, con los registros obtenidos</returns>
        public int checkExisteMedico(string codigoMedico)
        {
            return new clsHandlerHospitalDAL().checkExisteMedico(codigoMedico);
        }

        /// <summary>
        /// Método que obitene un objeto clsControlDiario de la BD a partir del código del médico del que se desea obtener
        /// </summary>
        /// <param name="codigoMedico">string con el código del médico</param>
        /// <returns>clsControlDiario objControlMedico con los datos del control diario</returns>
        public clsControlDiario getControlDiarioPorIdMedico(string codigoMedico)
        {
            return new clsHandlerHospitalDAL().getControlDiarioPorIdMedico(codigoMedico);
        }

    }
}
