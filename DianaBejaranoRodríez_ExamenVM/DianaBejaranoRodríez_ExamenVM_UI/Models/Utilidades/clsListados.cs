using DianaBejaranoRodríez_ExamenVM_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_UI.Models.Utilidades
{
    class clsListados
    {
        public static List<clsFabricante> ListadoFabricantes()
        {
            List<clsFabricante> listadoFabricantes = new List<clsFabricante>();
            listadoFabricantes.Add(new clsFabricante("Ford", 1));
            listadoFabricantes.Add(new clsFabricante("Renault", 2));
            listadoFabricantes.Add(new clsFabricante("Seat", 3));
            return listadoFabricantes;
        }

        public static List<clsModeloCoche> listadoModelos()
        {
            List<clsModeloCoche> listadoModelos = new List<clsModeloCoche>();
            listadoModelos.Add(new clsModeloCoche("Fiesta", 1));
            listadoModelos.Add(new clsModeloCoche("Focus", 1));
            listadoModelos.Add(new clsModeloCoche("Seat", 1));

            listadoModelos.Add(new clsModeloCoche("Clio", 2));
            listadoModelos.Add(new clsModeloCoche("Megane", 2));
            listadoModelos.Add(new clsModeloCoche("Scenic", 2));

            listadoModelos.Add(new clsModeloCoche("Ibiza", 3));
            listadoModelos.Add(new clsModeloCoche("León", 3));
            listadoModelos.Add(new clsModeloCoche("Tarraco", 3));

            return listadoModelos;
        }
    }
}
