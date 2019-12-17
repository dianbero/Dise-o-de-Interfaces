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
    public class clsListadoSuperHeroesDAL
    {
        //Atributos
        clsMyConnection objConexion = new clsMyConnection();
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector = null;
        clsSuperHeroe objSuperHeroe;


        /// <summary>
        /// Método que obtiene un listado de superhéroess de la BBDD
        /// </summary>
        /// <returns>ObservableCollection<clsSuperHeroe> listadoSuperHeroes </returns>
        //TODO: función que devuelve listado de personas
        public ObservableCollection<clsSuperHeroe> ListadoSuperHeroes() //Consulta para obtener el listado de personas
        {
            ObservableCollection<clsSuperHeroe> listadoSuperHeroes;

            try
            {
                //Abro conexión
                //conexion = new clsMyConnection();*/
                conexion = objConexion.getConnection();

                //Guardo sentencia en comando
                comando.CommandText = "SELECT * FROM superheroes";
                //Paso conexión al comando
                comando.Connection = conexion;
                //Ejecuta el comando               
                lector = comando.ExecuteReader();

                listadoSuperHeroes = new ObservableCollection<clsSuperHeroe>();

                if (lector.HasRows) //si hay lineas por leer
                {
                    while (lector.Read())
                    {
                        objSuperHeroe = new clsSuperHeroe(); 

                        objSuperHeroe.IdSuperheroe = (int)lector["idSuperheroe"];
                        objSuperHeroe.NombreSuperHeroe = (string)lector["nombreSuperheroe"];

                        listadoSuperHeroes.Add(objSuperHeroe);  //Añade el objeto persona del registro al listado Personas
                    }
                }
                return listadoSuperHeroes;  

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
