using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_Entities
{
    public class clsModeloCoche 
    {
        public int IdModelo { get; set; }
        public string NombreModelo { get; set; }
        public int IdFabricante { get; set; }
       

        public clsModeloCoche(int idModelo, string nombreModelo, int idFabricante)
        {
            this.NombreModelo = nombreModelo;
            this.IdFabricante = idFabricante;
            this.IdModelo = idModelo;
        }
    }
}
