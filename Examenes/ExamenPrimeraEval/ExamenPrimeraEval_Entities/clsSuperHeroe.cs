using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEval_Entities
{
    public class clsSuperHeroe
    {
        //Atributos privados
        private int idSuperheroe;
        private string nombreSuperHeroe;

        public clsSuperHeroe()
        {
            this.idSuperheroe = 0;
            this.nombreSuperHeroe = "BatmanTroller";
        }

        public clsSuperHeroe(int idSuperheroe, string nombreSuperHeroe)
        {
            this.idSuperheroe = idSuperheroe;
            this.nombreSuperHeroe = nombreSuperHeroe;
        }

        //Propiedades públicas
        public int IdSuperheroe
        {
            get { return idSuperheroe; }
            set { idSuperheroe = value; }
        }

        public string NombreSuperHeroe
        {
            get { return nombreSuperHeroe; }
            set { nombreSuperHeroe = value; }
        }
    }
}
