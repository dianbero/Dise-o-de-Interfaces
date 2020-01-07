using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Ej3_Listado_VM_UI.Models
{
    public class clsPersona //: INotifyPropertyChanged
    {
        //Atributos privados
        private string nombre;
        public clsPersona()
        {
            this.Nombre = "Diana";
            this.Apellido = "Bejarano";
            this.Edad = 26;
        }
        //Constructor por parámetros
        public clsPersona(string nombre, string apellido, int edad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
                        
        }

        //Propiedades públicas
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido { get; set; } //Equivale a lo anterior pero de forma más compacta
        public int Edad { get; set; }
        
    }

}
