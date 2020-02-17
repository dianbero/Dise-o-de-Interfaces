using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsPersona
    {
        //Atributos privados
        private string nombre, apellido;
        private int edad;

        //Constructor por defecto
        public clsPersona()
        {
            /*this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;*/
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
