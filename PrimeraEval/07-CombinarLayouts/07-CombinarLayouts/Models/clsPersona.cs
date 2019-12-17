using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_CombinarLayouts.Models
{
    public class clsPersona
    {
        //Atributos privados
        private string nombre;
        //private int edad; //Es propiedad autoimplementada por lo que no se declara como private
        private DateTime dateBirth;
        //private string dateOfBirth;


        //Constructor por defecto
        public clsPersona()
        {
            this.Nombre = "Diana";
            this.Apellido = "Bejarano";
            //this.Edad = 26;
        }
        //Constructor por parámetros
        public clsPersona(string name, string surname, int age)
        {
            this.Nombre = name;
            this.Apellido = surname;
            //this.Edad = age;
                        
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

        public string Apellido { get; set; } //Equivale a lo anterior pero de forma más compacta, y no se declara previamente como private
        //public int Edad { get; set; }

        
        public DateTime DateBirth
        {
            get
            {
                return dateBirth;
            }
            set
            {
                dateBirth = value;
            }
        }


        /*public DateTime DateBirth
        {
            get
            {
                return dateBirth;
            }
            set
            {
                if (DateTime.TryParse(dateOfBirth, out dateBirth))
                {
                    dateBirth = value;
                }
                else
                {
                    //dateOfBirth = null;
                    dateBirth = value;
                }          
            }
        }*/

    }

}
