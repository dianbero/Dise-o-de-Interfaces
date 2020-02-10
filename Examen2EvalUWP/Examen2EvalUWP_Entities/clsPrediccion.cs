using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_Entities
{
    public class clsPrediccion
    {
        #region Atributos Privados
        private int idCiudad;
        private DateTime fecha;
        private double tempMax;
        private double tempMin;
        private double humedad;
        private string pronostico;        
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

        public double TempMax
        {
            get
            {
                return tempMax;
            }
            set
            {
                tempMax = value;
            }
        }
        public double TempMin
        {
            get
            {
                return tempMin;
            }
            set
            {
                tempMin = value;
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
        #endregion

        #region Contructor
        public clsPrediccion()
        {
            this.idCiudad = 1;
            this.fecha = new DateTime(2020, 8, 16);
            this.tempMax = 12.5;
            this.tempMin = 10.0;
            this.humedad = 12.2;
            this.pronostico = "Nublado";
        }

        public clsPrediccion(int idCiudad, DateTime fecha, double tempMax, double tempMin, double humedad, string pronostico)
        {
            this.idCiudad = idCiudad;
            this.fecha = fecha;
            this.tempMax = tempMax;
            this.tempMin = tempMin;
            this.humedad = humedad;
            this.pronostico = pronostico;
        }
        #endregion
    }
}
