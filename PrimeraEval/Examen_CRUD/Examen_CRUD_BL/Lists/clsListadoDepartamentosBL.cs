
using Examen_CRUD_Entities;
using Examen_CRUD_DAL.Lists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen_CRUD_BL.Lists
{
    public class clsListadoDepartamentosBL
    {
        public List<clsDepartamento> ListadoCompletoDepartamentos()
        {
            clsListadoDepartamentosDAL listadoDepartamentos = new clsListadoDepartamentosDAL();

            return listadoDepartamentos.ListadoCompletoDepartamentos();
        }
    }
}
