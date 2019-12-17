using _14_Ej3_Listado_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
//using System.Web;

namespace _14_Ej3_Listado_VM_UI.Models.Utilidades
{
    public class clsListadoPersonas
    {
        public static ObservableCollection<clsPersona> ListadoCompletoPersonas() //Teniendo un ObservableCollection no es necesario notificar el cambio
        {
            //Obser<clsPersona> listado = new List<clsPersona>();
            ObservableCollection<clsPersona> listado = new ObservableCollection<clsPersona>();            

            listado.Add(new clsPersona("Diana", "Bejarano", 26));
            listado.Add(new clsPersona("Alberto", "Rodríguez", 30));
            listado.Add(new clsPersona("Juan", "Salguero", 23));
            listado.Add(new clsPersona("Sara", "López", 28));
            listado.Add(new clsPersona("Laura", "Pérez", 20));

            return listado;
        }

        //public static List<clsPersona> listadoCompletoPersonas()
        //{
        //    List<clsPersona> listado = new List<clsPersona>();

        //    listado.Add(new clsPersona("Diana", "Bejarano", 26));
        //    listado.Add(new clsPersona("Alberto", "Rodríguez", 30));
        //    listado.Add(new clsPersona("Juan", "Salguero", 23));
        //    listado.Add(new clsPersona("Sara", "López", 28));
        //    listado.Add(new clsPersona("Laura", "Pérez", 20));

        //    return listado;
        //}
    }
}