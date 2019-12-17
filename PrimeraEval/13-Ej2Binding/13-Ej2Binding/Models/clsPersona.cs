using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Ej2Binding.Models
{
    public class clsPersona : INotifyPropertyChanged
    {
        //Atributos privados
        private string nombre;
        private int numDepartamento;
        //Declaración del evento para el Binding
        public event PropertyChangedEventHandler PropertyChanged;
        //Constructor por defecto
        public clsPersona()
        {
            this.Nombre = "Diana";
            this.Apellido = "Bejarano";
            this.Edad = 26;
            this.numDepartamento = 1;
        }
        //Constructor por parámetros
        public clsPersona(string nombre, string apellido, int edad, int numDepartamento)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.numDepartamento = numDepartamento;
                        
        }

        /// <summary>
        /// Método para lanzar el evento
        /// </summary>
        /// <param name="nombre"></param>
        private void OnPropertyChanged(string nombre)
        {
            //Representa el método que controlará al evento PropertyChanged, que tiene lugar cuando cambia el valor de la propiedad.
            PropertyChangedEventHandler eventHandler = PropertyChanged;

            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(nombre));
            }
            //Forma más corta: PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
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
                //Llama al método OnPropertyChanged cuando la propiedad cambia
                OnPropertyChanged("Nombre");
            }
        }

        public string Apellido { get; set; } //Equivale a lo anterior pero de forma más compacta
        public int Edad { get; set; }
        public int NumDepartamento
        {
            get { return numDepartamento; }
            set { numDepartamento = value; }
        }

        


    }

}
