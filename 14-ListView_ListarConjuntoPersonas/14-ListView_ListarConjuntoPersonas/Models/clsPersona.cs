using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_ListView_ListarConjuntoPersonas.Models
{
    public class clsPersona
    {
        //Atributos privados
        private string nombre;
        //private int edad;
        private string txtEdad;

        //Constructor por defecto
        public clsPersona()
        {
            this.Nombre = "Diana";
            this.Apellido = "Bejarano";
            this.Edad = 26;
            this.FechaNacimiento = "16/08/1993";
            this.Telefono = "666 666 666";
            this.Direccion = "IES Nervión";
        }

        //Constructor por parámetros
        public clsPersona(string nombre, string apellido, int edad, string fechaNacimiento, string telefono, string direccion)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.Telefono = telefono;
            this.Direccion = direccion;
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
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
                
            }
        }
