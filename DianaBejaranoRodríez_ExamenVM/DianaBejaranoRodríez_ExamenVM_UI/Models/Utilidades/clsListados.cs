using DianaBejaranoRodríez_ExamenVM_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_UI.Models.Utilidades
{
    public class clsListados
    {
        public static List<clsFabricante> ListadoFabricantes()
        {
            List<clsFabricante> listadoFabricantes = new List<clsFabricante>();
            listadoFabricantes.Add(new clsFabricante("Ford", 1));
            listadoFabricantes.Add(new clsFabricante("Renault", 2));
            listadoFabricantes.Add(new clsFabricante("Seat", 3));
            return listadoFabricantes;
        }

        public static List<clsModeloCoche> ListadoModelos()
        {
            List<clsModeloCoche> listadoModelos = new List<clsModeloCoche>();
            listadoModelos.Add(new clsModeloCoche(1, "Fiesta", 1));
            listadoModelos.Add(new clsModeloCoche(2, "Focus", 1));
            listadoModelos.Add(new clsModeloCoche(3, "Orion", 1));

            listadoModelos.Add(new clsModeloCoche(4, "Clio", 2));
            listadoModelos.Add(new clsModeloCoche(5, "Megane", 2));
            listadoModelos.Add(new clsModeloCoche(6, "Scenic", 2));

            listadoModelos.Add(new clsModeloCoche(7, "Ibiza", 3));
            listadoModelos.Add(new clsModeloCoche(8, "León", 3));
            listadoModelos.Add(new clsModeloCoche(9, "Tarraco", 3));

            return listadoModelos;
        }
    }
}
