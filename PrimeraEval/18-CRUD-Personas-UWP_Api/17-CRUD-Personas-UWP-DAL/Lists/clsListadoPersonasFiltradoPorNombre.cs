using _17_CRUD_Personas_UWP_DAL.Connections;
using _17_CRUD_Personas_UWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CRUD_Personas_UWP_DAL.Lists
{
    public class clsListadoPersonasFiltradoPorNombre
    {
        //Atributos
        ObservableCollection<clsPersona> listadoPersonas;
        clsMyConnection objConexion = new clsMyConnection();
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        clsPersona objPersona;


        //TODO: función que devuelve listado de personas
        public ObservableCollection<clsPersona> ListadoPersonasFiltradoPorNombre(clsPersona persona) //Pasarle objeto persona, para buscar persona por el nombre
        {

            //Abro conexión
            //conexion = new clsMyConnection();*/
            try
            {
                conexion = objConexion.getConnection();

                //Guardo sentencia en comando
                comando.Parameters.Add("@nombrePersona", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                comando.CommandText = "SELECT * FROM PD_Personas WHERE NombrePersona = @nombrePersona ";
                //Paso conexión al comando
                comando.Connection = conexion;
                //Ejecuta el comando
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
                lector.Close();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                objConexion.closeConnection(ref conexion);
            }

            return listadoPersonas;  //Devuelve la lista de personas creada para la consulta
        }
    }
}
