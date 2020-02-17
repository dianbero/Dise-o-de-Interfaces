//using _10_CRUD_Personas_Again_Entities;
//using _10_CRUD_Personas_DAL.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Examen_CRUD_DAL.Connections;
using Examen_CRUD_Entities;

namespace Examen_CRUD_DAL.Lists
{
    public class clsListadoDepartamentosDAL
    {
        //Atributos
        clsMyConnection objConexion = new clsMyConnection();
        SqlConnection conexion;
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;
        clsDepartamento objDepartamento;


        //TODO: función que devuelve listado de departamentos
        public List<clsDepartamento> ListadoCompletoDepartamentos() //Consulta para obtener el listado de departamentos
        {

            //Abro conexión
            //conexion = new clsMyConnection();*/
            conexion = objConexion.getConnection();

            //Guardo sentencia en comando
            comando.CommandText = "SELECT * FROM PD_Departamentos";
            //Paso conexión al comando
            comando.Connection = conexion;
            //Ejecuta el comando
            lector = comando.ExecuteReader();

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

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
