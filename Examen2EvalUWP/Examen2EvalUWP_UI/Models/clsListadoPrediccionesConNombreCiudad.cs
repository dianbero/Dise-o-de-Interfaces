using Examen2EvalUWP_BL.Lists;
using Examen2EvalUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_UI.Models
{
    public class clsPrediccionesConNombreCiudad : clsCiudad
    {
        private string nombreCiudad;
        private int idCiudad;
        private ObservableCollection<clsPrediccion> listadoPrediccion;

        //public clsPrediccionesConNombreCiudad(int idCiudad, string nombreCiudad)
        //{
        //    this.listadoPrediccion = await new clsListadoPrediccionesBL().ObtenerPrediccionCiudad(idCiudad);
        //    this.nombreCiudad = nombreCiudad;
        //}
    }
}
