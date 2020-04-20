using Hospital_DAL.Connections;
using Hospital_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_DAL.Handlers
{
    public class clsHandlerHospitalDAL
    {
        /// <summary>
        /// Método que obitene un objeto clsMedico de la BD a partir del código del médico que se desea obtener
        /// </summary>
        /// <param name="codigoMedico">string con el código del médico deseado</param>
        /// <returns>clsMedico objMedico, con los datos del médico deseado</returns>
        public clsMedico getMedico(string codigoMedico)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsMedico objMedico = null;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;
                
                command.Parameters.Add("@codigoMedico", System.Data.SqlDbType.VarChar).Value = codigoMedico; 
                command.CommandText = "SELECT * FROM Medicos WHERE codigoMedico = @codigoMedico";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        //Creo el objeto médico con los datos de la BD
                        objMedico = new clsMedico();

                        objMedico.CodigoMedico = (string)reader["codigoMedico"];
                        objMedico.NombreMedio = (string)reader["nombreMedico"];
                        objMedico.ApellidosMedico = (string)reader["apellidosMedico"];
                    }
                }
                
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    objConnection.closeConnection(ref connection);
                }
            }

            return objMedico;
        }

        /// <summary>
        /// Método que comprueba que el médico devolviendo un entero con la cantidad de filas afectadas por la sentencia
        /// Que deberá ser una sola
        /// </summary>
        /// <param name="codigoMedico">string con el código del médico deseado</param>
        /// <returns>int filasAfectadas, con los registros obtenidos</returns>
        public int checkExisteMedico(string codigoMedico)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            Int32 filasAfectadas = 0;
            //int filasAfectadas = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@codigoMedico", System.Data.SqlDbType.VarChar).Value = codigoMedico;
                command.CommandText = "SELECT COUNT(*) FROM Medicos WHERE codigoMedico = @codigoMedico";

                /*En la documentaticón de Microsoft he visto que lo hacen así, primero con tipo Int32 y luego hacen la conversión a int, no sé por qué pero lo he dejado así,
                 pero lo probé con un int normal y funcionaba igualmente, así que no veo realmente el motivo de ese doble casteo*/
                filasAfectadas = (Int32)command.ExecuteScalar(); 
                //filasAfectadas = (int)command.ExecuteScalar();
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

            return (int)filasAfectadas;
            //return filasAfectadas;
        }

        /// <summary>
        /// Método que obitene un objeto clsControlDiario de la BD a partir del código del médico del que se desea obtener
        /// </summary>
        /// <param name="codigoMedico">string con el código del médico</param>
        /// <returns>clsControlDiario objControlMedico con los datos del control diario</returns>
        public clsControlDiario getControlDiarioPorIdMedico(string codigoMedico)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();
            SqlDataReader reader = null;

            clsControlDiario objControlMedico = null;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;

                command.Parameters.Add("@codigoMedico", System.Data.SqlDbType.VarChar).Value = codigoMedico;
                command.CommandText = "SELECT * FROM ControlDiario WHERE codigoMedico = @codigoMedico AND fecha = CONVERT(varchar, GETDATE(), 3)";
                //command.CommandText = "SELECT * FROM ControlDiario WHERE codigoMedico = @codigoMedico";

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        //Creo el objeto control diario con los datos de la BD
                        objControlMedico = new clsControlDiario();                 

                        objControlMedico.CodigoMedico = (string)reader["codigoMedico"];
                        objControlMedico.Fecha = (DateTime)reader["fecha"];
                        objControlMedico.PrimeraSesion = reader.IsDBNull(reader.GetOrdinal("primeraSesion")) ? "No tiene tareas" : (string)reader["primeraSesion"];
                        objControlMedico.SegundaSesion = reader.IsDBNull(reader.GetOrdinal("segundaSesion")) ? "No tiene tareas" : (string)reader["segundaSesion"];
                        objControlMedico.TerceraSesion = reader.IsDBNull(reader.GetOrdinal("terceraSesion")) ? "No tiene tareas" : (string)reader["terceraSesion"];
                        objControlMedico.CuartaSesion = reader.IsDBNull(reader.GetOrdinal("cuartaSesion")) ? "No tiene tareas" : (string)reader["cuartaSesion"];

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    objConnection.closeConnection(ref connection);
                }
            }

            return objControlMedico;
        }


    }
}
