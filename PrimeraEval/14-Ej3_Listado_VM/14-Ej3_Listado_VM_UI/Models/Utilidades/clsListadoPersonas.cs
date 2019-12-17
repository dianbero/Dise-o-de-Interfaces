using _14_Ej3_Listado_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace _14_Ej3_Listado_VM_UI.Models.Utilidades
{
    public class clsListadoPersonas
    {
        
        public static List<clsPersona> listadoCompletoPersonas()
        {
            List<clsPersona> listado = new List<clsPersona>();

            listado.Add(new clsPersona("Diana", "Bejarano", 26));
            listado.Add(new clsPersona("Alberto", "Rodríguez", 30));
            listado.Add(new clsPersona("Juan", "Salguero", 23));
            listado.Add(new clsPersona("Sara", "López", 28));
            listado.Add(new clsPersona("Laura", "Pérez", 20));

            return listado;
        }
    }
}