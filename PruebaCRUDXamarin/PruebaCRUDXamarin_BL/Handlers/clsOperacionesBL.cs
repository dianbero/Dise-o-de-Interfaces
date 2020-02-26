using PruebaCRUDXamarin_DAL.Handlers;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCRUDXamarin_BL.Handlers
{
    public class clsOperacionesBL
    {
        public async Task InsertarPersona(clsPersona persona)
        {
            await new clsOperacionesDAL().InsertarPersona(persona);
        }
    }
}
