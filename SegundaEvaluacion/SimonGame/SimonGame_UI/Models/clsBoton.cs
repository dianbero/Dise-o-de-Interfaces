﻿using SimonGame_UI.ViewModels.ViewmodelTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonGame_UI.Models
{
    public class clsBoton : clsVMBase
    {
        #region Atributos Privados
        private int id;
        private string color;
        private string sonido;
        private string opacidad; //se le cambiará mientras suena sonido
        #endregion

        #region Propiedades Públicas
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public string Sonido
        {
            get
            {
                return sonido;
            }
            set
            {
                sonido = value;
            }
        }

        public string Opacidad
        {
            get
            {
                return opacidad;
            }
            set
            {
                opacidad = value;
                NotifyPropertyChanged("Opacidad");
            }
        }
        #endregion

        #region Constructor
        //Por defecto
        public clsBoton()
        {
            this.id = 0;
            this.color = "Red";
            this.sonido = "";
            this.opacidad = "1";
        }

        public clsBoton(int id, string color, string sonido)
        {
            this.id = id;
            this.color = color;
            this.sonido = sonido;
            this.opacidad = "1";
        }
        #endregion
    }
}
