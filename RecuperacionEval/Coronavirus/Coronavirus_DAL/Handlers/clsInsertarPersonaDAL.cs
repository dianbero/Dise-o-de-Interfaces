using Coronavirus_DAL.Connections;
using Coronavirus_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coronavirus_DAL.Handlers
{
    public class clsInsertarPersonaDAL
    {
        /// <summary>
        /// Método que inserta una nueva persona en la BD.
        /// Devuelve un entero que representa el número de filas afectadas por la sentencia ejecutada.
        /// Si ese entero es distinto de 1, no se habrá ejecutado correctamente, porque debe insertar un registro.
        /// </summary>
        /// <param name="nuevaPersona">Objeto clsPersona con los datos de la nueva persona a insertar</param>
        /// <returns>int filasAfectadas, con el número de filas afectadas al ejecutarse</returns>
        public int insertarPersona(clsPersona nuevaPersona)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            int filasAfectadas = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@dni", System.Data.SqlDbType.VarChar).Value = nuevaPersona.DniPersona;
                command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nuevaPersona.NombrePersona;
                command.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = nuevaPersona.ApellidosPersona;
                command.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = nuevaPersona.Telefono;
                command.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = nuevaPersona.Direccion;
                command.Parameters.Add("@diagnostico", System.Data.SqlDbType.Bit).Value = nuevaPersona.Diagnostico;

                command.CommandText = "INSERT INTO Personas (dniPersona, nombrePersona, apellidosPersona, telefono, direccion, diagnostico) " +
                                        "VALUES(@dni, @nombre, @apellidos, @telefono, @direccion, @diagnostico)";

                filasAfectadas = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    objConnection.closeConnection(ref connection);
                }
            }

            return filasAfectadas;
        }
    }
}
