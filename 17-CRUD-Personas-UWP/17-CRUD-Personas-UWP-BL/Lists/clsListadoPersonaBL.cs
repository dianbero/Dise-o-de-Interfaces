using _10_CRUD_Personas_DAL.Lists;
using _17_CRUD_Personas_UWP_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _17_CRUD_Personas_UWP_BL.Lists
{
    public class clsListadoPersonaBL
    {
       
        public List<clsPersona> ListadoPersonas()
        {
            
            clsListadoPersonasDAL listado = new clsListadoPersonasDAL();
            //Rellena listado con la personas de la consulta
            return listado.ListadoCompletoPersonas(); 
            
        }


    }
}
