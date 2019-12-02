using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using ExamenPrimeraEval_DAL.Connections;
using System.Data.SqlClient;
using ExamenPrimeraEval_Entities;

namespace _17_CRUD_Personas_UWP_DAL.Lists
{
    public class clsListadoMisionesDAL
    {
        //Atributos
        clsMyConnection objConexion = new clsMyConnection();
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector = null;
        clsMision objMision;



        /// <summary>
        /// Método que obtiene un listado de misiones de la BBDD
        /// </summary>
        /// <returns>ObservableCollection<clsMision> listadoMisiones</returns>
        public ObservableCollection<clsMision> ListadoMisionesNoReservadas() //Consulta para obtener el listado de personas
        {
            ObservableCollection<clsMision> listadoMisiones;

            try
            {
                //Abro conexión
                //conexion = new clsMyConnection();*/
                conexion = objConexion.getConnection();

                //Guardo sentencia en comando
                comando.CommandText = "SELECT * FROM misiones WHERE reservada = 0;";
                //Paso conexión al comando
                comando.Connection = conexion;
                //Ejecuta el comando               
                lector = comando.ExecuteReader();

                listadoMisiones = new ObservableCollection<clsMision>();

                if (lector.HasRows) //si hay lineas por leer
                {
                    while (lector.Read())
                    {
                        objMision = new clsMision(); 

                        objMision.IdMision = (int)lector["idMision"];
                        objMision.TituloMision = (string)lector["tituloMision"];
                        objMision.DescripcionMision = (string)lector["descripcionMision"];
                        objMision.Reservada = (bool)lector["reservada"];
                        objMision.IdSuperheroe = (int)lector["idSuperheroe"];
                        objMision.Observaciones = (string)lector["observaciones"];

                        listadoMisiones.Add(objMision);  
                    }
                }
                return listadoMisiones;  

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (lector != null)
                {

                    lector.Close();
                }
                objConexion.closeConnection(ref conexion);
            }

        }
    }
}
