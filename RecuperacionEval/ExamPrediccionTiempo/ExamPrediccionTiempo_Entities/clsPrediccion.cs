using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrediccionTiempo_Entities
{
    public class clsPrediccion
    {
        #region Atributos Privados
        private int idCiudad;
        private DateTime fecha;
        private double temperaturaMaxima;
        private double temperaturaMinima;
        private double humedad;
        private string pronostico;
        private Uri imagenPronostico;
        #endregion

        #region Propiedades Públicas
        public int IdCiudad
        {
            get
            {
                return idCiudad;
            }
            set
            {
                idCiudad = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

        public double TemperaturaMaxima
        {
            get
            {
                return temperaturaMaxima;
            }
            set
            {
                temperaturaMaxima = value;
            }
        }
        public double TemperaturaMinima
        {
            get
            {
                return temperaturaMinima;
            }
            set
            {
                temperaturaMinima = value;
            }
        }
        public double Humedad
        {
            get
            {
                return humedad;
            }
            set
            {
                humedad = value;
            }
        }

        public string Pronostico
        {
            get
            {
                return pronostico;
            }
            set
            {
                pronostico = value;
            }
        }

        public Uri ImagenPronostico
        {
            get
            {
                asignarUriSegunPronostico(pronostico);
                return imagenPronostico;
            }
        }
        #endregion

        #region Contructor
        public clsPrediccion()
        {
            this.idCiudad = 1;
            this.fecha = new DateTime(2020, 8, 16);
            this.temperaturaMaxima = 12.5;
            this.temperaturaMinima = 10.0;
            this.humedad = 12.2;
            this.pronostico = "Nieve";
        }

        public clsPrediccion(int idCiudad, DateTime fecha, double temperaturaMaxima, double temperaturaMinima, double humedad, string pronostico)
        {
            this.idCiudad = idCiudad;
            this.fecha = fecha;
            this.temperaturaMaxima = temperaturaMaxima;
            this.temperaturaMinima = temperaturaMinima;
            this.humedad = humedad;
            this.pronostico = pronostico;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que asigna la uri de la imagen según el pronóstico correspondiente 
        /// </summary>
        /// <param name="pronostico">Pronóstico correspondiente al día</param>
        public void asignarUriSegunPronostico(string pronostico)
        {
            switch (pronostico)
            {
                case "Soleado":
                    this.imagenPronostico = new Uri("ms-appx:///Assets/Images/Soleado.png");
                    break;

                case "Soledado": //Porque tras un rato de desconcierto, resulta que hay UNO en el que pone "Soledado" en lugar de "Soleado"... Cosas que pasan
                    this.imagenPronostico = new Uri("ms-appx:///Assets/Images/Soleado.png");
                    break;

                case "Lluvia":
                    this.imagenPronostico = new Uri("ms-appx:///Assets/Images/Lluvia.png");
                    break;

                case "Nieve":
                    this.imagenPronostico = new Uri("ms-appx:///Assets/Images/Nieve.png");
                    break;
            }
        }
        #endregion
    }
}
