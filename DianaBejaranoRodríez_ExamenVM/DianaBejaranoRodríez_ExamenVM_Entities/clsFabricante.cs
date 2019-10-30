using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_Entities
{
    public class clsFabricante
    {
        public string NombreFabricante { get; set; }
        public int IdFabricante { get; set; }

        public clsFabricante(string nombrefabricante, int idFabricante)
        {
            this.NombreFabricante = nombrefabricante;
            this.IdFabricante = idFabricante;
        }
    }
}
