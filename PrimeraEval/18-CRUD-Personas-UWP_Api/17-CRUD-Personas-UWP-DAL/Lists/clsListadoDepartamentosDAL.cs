using _17_CRUD_Personas_UWP_DAL.Connections;
using _17_CRUD_Personas_UWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace _17_CRUD_Personas_UWP_DAL.Lists
{
    public class clsListadoDepartamentosDAL
    {
        //Atributos
        clsMyConnection objConexion;
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        clsDepartamento objDepartamento;


        /// <summary>
        /// Método que devuelve el listado de departamentos de la base de datos
        /// </summary>
        /// <returns>ObservableCollection<clsDepartamento> listadoDepartamentos</returns>
        public ObservableCollection<clsDepartamento> ListadoCompletoDepartamentos() //Consulta para obtener el listado de departamentos
        {

            //Abro conexión
            objConexion = new clsMyConnection();
            //conexion = objConexion.getConnection();

            //Guardo sentencia en comando
            comando.CommandText = "SELECT * FROM PD_Departamentos";
            //Paso conexión al comando
            comando.Connection = conexion;
            //Ejecuta el comando
            lector = comando.ExecuteReader();

            ObservableCollection<clsDepartamento> listadoDepartamentos = new ObservableCollection<clsDepartamento>();

            if (lector.HasRows) //si hay lineas por leer
            {
                while (lector.Read())
                {
                    objDepartamento = new clsDepartamento(); //Creo un departamento para cada registro

                    objDepartamento.IdDepartamento = (int)lector["IdDepartamento"];
                    objDepartamento.NombreDepartamento = (string)lector["NombreDepartamento"];
                    
                    listadoDepartamentos.Add(objDepartamento);  //Añade el objeto persona del registro al listado Personas
                }
            }

            return listadoDepartamentos;  //Devuelve la lista de personas creada para la consulta
        }
    }
}
