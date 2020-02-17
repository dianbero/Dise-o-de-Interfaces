using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_CRUD_Entities
{
    public class clsPersona
    {
        private string nombre;
        //private string apellido; 
        private int idDepartamento;
        private DateTime fechaNacimiento;
        private string telefono;
        private byte[] foto;
        
        //Constructor por defecto
        public clsPersona()
        {
            this.Id = 1;
            this.Nombre = "Diana";
            this.Apellido = "Bejarano";
            //this.Edad = 26;
            this.IdDepartamento = 1;
            this.FechaNacimiento = new DateTime(1993, 8, 16);
            this.Telefono = "625456965";
            this.Foto = null;
        }

        //Constructor por parámetros
        public clsPersona(int id, string nombre, string apellido, int idDepartamento, DateTime fechaNacimiento, string telefono, byte[] foto)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IdDepartamento = idDepartamento;
            this.FechaNacimiento = fechaNacimiento;
            this.Telefono = telefono;
            this.Foto = foto;
        }


        //Propiedades públicas
        //[Required(ErrorMessage = "Debe introducir id")]
        //[Required]
        //[System.Web.Mvc.HiddenInput(DisplayValue = false)] //Me da error
        public int Id { get; set; }

        //[Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //[Required(ErrorMessage = "Debe introducir un apellido")]
        //[DataType(DataType.Text)]
        //[Required]        
        public string Apellido { get; set; } 
        //public int Edad { get; set; }
        //[Required(ErrorMessage = "IdDepartamente es obligatorio")]        
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }
        //[Required(ErrorMessage = "Fecha de nacimiento es obligatoria")]
        //[DataType(DataType.DateTime)]
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }


        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public byte[] Foto
        {
            get { return foto; }
            set { foto = value; }
        }
    }
}
