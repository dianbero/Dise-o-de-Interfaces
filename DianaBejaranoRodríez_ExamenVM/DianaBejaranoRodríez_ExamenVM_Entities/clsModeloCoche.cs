﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianaBejaranoRodríez_ExamenVM_Entities
{
    class clsModeloCoche 
    {
        public string NombreModelo { get; set; }
        public int IdFabricante { get; set; }
        public int IdModelo { get; set; }

        public clsModeloCoche(string nombreModelo, int idFabricante)
        {
            this.NombreModelo = nombreModelo;
            this.IdFabricante = idFabricante;
        }
    }
}
