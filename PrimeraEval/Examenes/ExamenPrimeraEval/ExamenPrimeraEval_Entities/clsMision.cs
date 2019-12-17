using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrimeraEval_Entities
{
    public class clsMision
    {
        //Atributos privados
        private int idMision;
        private string tituloMision;
        private string descripcionMision;
        private bool reservada;
        private string observaciones;
        private int idSuperheroe;

        public clsMision()
        {
            this.idMision = 0;
            this.tituloMision = "";
            this.descripcionMision = "";
            this.reservada = false;
            this.observaciones = "";
            this.idSuperheroe = 0;
        }

        public clsMision(int idMision, string tituloMision, string descripcionMision, bool reservada, string observaciones, int idSuperheroe)
        {
            this.idMision = idMision;
            this.tituloMision = tituloMision;
            this.descripcionMision = descripcionMision;
            this.reservada = reservada;
            this.observaciones = observaciones;
            this.idSuperheroe = idSuperheroe;
        }

        //Propiedades públicas

        public int IdMision
        {
            get { return idMision; }
            set { idMision = value; }
        }

        public string TituloMision
        {
            get { return tituloMision; }
            set { tituloMision = value; }
        }
        public string DescripcionMision
        {
            get { return descripcionMision; }
            set { descripcionMision = value; }
        }

        public bool Reservada
        {
            get { return reservada; }
            set { reservada = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public int IdSuperheroe
        {
            get { return idSuperheroe; }
            set { idSuperheroe = value; }
        }        
    }
}
