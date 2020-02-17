
using System;
using System.Collections.Generic;
using System.Text;
using Examen_CRUD_Entities;
using Examen_CRUD_DAL.Lists;

namespace Examen_CRUD_BL.Lists
{
    class clsPersonaPorIdBL
    {
        public List<clsPersona> ListadoPersonaPorId(clsPersona persona)
        {
            clsPersonaPorId listadoPersona = new clsPersonaPorId();

            return listadoPersona.ObtenerPersonaPorId(persona.Id);
        }
    }
}
