using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas_UI.Utilidades
{
    class clsListadoCasillas
    {
        public List<clsListadoCasillas> ListadoCompletoCasillas()
        {
            List<clsListadoCasillas> listadoCasillas = new List<clsListadoCasillas>();
            listadoCasillas.Add(new clsListadoCasillas());

            return listadoCasillas;
        }
    }
}
