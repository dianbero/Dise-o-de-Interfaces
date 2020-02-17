using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_CRUD_Entities
{
    public class clsDepartamento
    {
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        public clsDepartamento()
        {
            this.IdDepartamento = 1;
            this.NombreDepartamento = "Finanzas";
        }

        public clsDepartamento(int idDepartamento, string nombreDepartamento)
        {
            this.IdDepartamento = idDepartamento;
            this.NombreDepartamento = nombreDepartamento;
        }
    }
}
