using CrearPruebaCamellos_DAL.Connections;
using CrearPruebaCamellos_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearPruebaCamellos_DAL.Handlers
{
    public class clsHandlerPruebasDAL
    {
        /*
         TODO:
         - int insertarPrueba(clsPrueba nuevaPrueba)
         */
        
        /// <summary>
        /// Método que inserta una nueva prueba y obtiene su idPrueba generado, de la BBDD
        /// </summary>
        /// <param name="nuevaPrueba">clsPrueba con los datos de la nueva prueba a insertar</param>
        /// <returns>int idPrueba, con el idPrueba generado al insertar la nueva prueba</returns>
        public int insertarPrueba(clsPrueba nuevaPrueba)
        {
            clsMyConnection objConnection = new clsMyConnection();
            SqlConnection connection = null;
            SqlCommand command = new SqlCommand();

            //int filasAfectadas;
            Int32 idPrueba = 0;

            try
            {
                connection = objConnection.getConnection();
                command.Connection = connection;


                command.Parameters.Add("@numeroPalabras", System.Data.SqlDbType.Int).Value = nuevaPrueba.NumeroPalabras;
                command.Parameters.Add("@tiempoMaximo", System.Data.SqlDbType.Time).Value = nuevaPrueba.TiempoMax;


                /*Me llama la atención meter dos sentencias SQL a la vez en el CommandText, pero en la documentación de microsoft lo hacen así, con la sentencia de inserción primero y después
                 el select, y obtiene el idJugador únicamente que era mi intención, porque es lo único que quiero pasarle a la siguiente vista*/
                command.CommandText = "INSERT INTO CJ_Pruebas(numeroPalabras, tiempoMaximo) VALUES (@numerPalabras, @tiempoMaximo) " +
                    "SELECT TOP 1 * FROM CJ_Pruebas ORDER BY idPrueba DESC"; //Pilla sólo la primera columna y de la primera fila de la última prueba insertada, en mi caso el idPrueba

                //Ejecuta la instrucción SQL
                //filasAfectadas = command.ExecuteNonQuery();      
                idPrueba = (Int32)command.ExecuteScalar();


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


            return (int)idPrueba;
        }
    }
}
