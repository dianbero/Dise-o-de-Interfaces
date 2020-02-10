using Examen2EvalUWP_DAL.Lists;
using Examen2EvalUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_BL.Lists
{
    public class clsListaPersonas_BL
    {
        public async Task<ObservableCollection<clsPersona>> ListadoPersonasBL()
        {
            return await new clsListaPersonas_DAL().ListadoCompletoPersonasDAL();
        }
    }
}
