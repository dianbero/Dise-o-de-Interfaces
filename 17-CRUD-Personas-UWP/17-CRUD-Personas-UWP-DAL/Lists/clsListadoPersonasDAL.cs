using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _17_CRUD_Personas_UWP_Entities;
using _17_CRUD_Personas_UWP_DAL.Connections;
using System.Collections.ObjectModel;

namespace _17_CRUD_Personas_UWP_DAL.Lists
{
    public class clsListadoPersonasDAL
    {
        //Atributos
        clsMyConnection objConexion = new clsMyConnection();
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector = null;
        clsPersona objPersona;
        


        //TODO: función que devuelve listado de personas
        public ObservableCollection<clsPersona> ListadoCompletoPersonas() //Consulta para obtener el listado de personas
        {
            ObservableCollection<clsPersona> listadoPersonas;

            try {
                //Abro conexión
                //conexion = new clsMyConnection();*/
                conexion = objConexion.getConnection();

                //Guardo sentencia en comando
                comando.CommandText = "SELECT * FROM PD_Personas";
                //Paso conexión al comando
                comando.Connection = conexion;
                //Ejecuta el comando
                //TODO: poner try
                lector = comando.ExecuteReader();

                listadoPersonas = new ObservableCollection<clsPersona>();

                if (lector.HasRows) //si hay lineas por leer
                {
                    while (lector.Read())
                    {
                        objPersona = new clsPersona(); //Creo una persona para cada registro

                        objPersona.Id = (int)lector["IdPersona"];
                        objPersona.Nombre = (string)lector["NombrePersona"];
                        objPersona.Apellido = (string)lector["ApellidosPersona"];
                        objPersona.IdDepartamento = (int)lector["IDDepartamento"];
                        objPersona.FechaNacimiento = (DateTime)lector["FechaNacimientoPersona"];
                        objPersona.Telefono = (string)lector["TelefonoPersona"];

                        listadoPersonas.Add(objPersona);  //Añade el objeto persona del registro al listado Personas
                    }
                }
                return listadoPersonas;  //Devuelve la lista de personas creada para la consulta

            }
            catch(SqlException e)
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
