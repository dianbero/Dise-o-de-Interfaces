
using Examen_CRUD_Entities;
using Examen_CRUD_DAL.Lists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen_CRUD_BL.Lists
{
    public class clsListadoDepartamentosPorId
    {
        List<clsDepartamento> ListadoDepartamentoPorId { get; }
        public clsListadoDepartamentosPorId()
        {
            clsPersona persona = new clsPersona();
            clsDepartamentoPorId departamentoPorId = new clsDepartamentoPorId();  
            this.ListadoDepartamentoPorId = departamentoPorId.ListadoDepartamentosPorId(persona.IdDepartamento); //Recibe idDepartamento de la persona
        }
    }
}
