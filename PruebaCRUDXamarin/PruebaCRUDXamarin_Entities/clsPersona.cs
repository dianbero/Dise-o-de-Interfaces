using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCRUDXamarin_Entities
{
    public class clsPersona
    {
        //Atributos privados
        private int id;
        private string nombre;
        private string apellidos;
        private int idDepartamento;
        private DateTime fechaNacimiento;
        private string telefono;
        private byte[] foto;
        
        //Constructor por defecto
        public clsPersona()
        {
            this.Id = 1;
            this.Nombre = "Diana";
            this.Apellidos = "Bejarano";
            //this.Edad = 26;
            this.IdDepartamento = 1;
            this.FechaNacimiento = new DateTime(1993, 8, 16);
            this.Telefono = "625456965";
            this.Foto = null;
        }

        //Constructor por parámetros
        public clsPersona(int id, string nombre, string apellidos, int idDepartamento, DateTime fechaNacimiento, string telefono, byte[] foto)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.IdDepartamento = idDepartamento;
            this.FechaNacimiento = fechaNacimiento;
            this.Telefono = telefono;
            this.Foto = foto;
        }


        //Propiedades públicas
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos { get; set; }   
        
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

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
