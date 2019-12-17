using BuscaMinas_Entities;
using BuscaMinas_UI.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas_UI.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private List<clsCasilla> listadoCasillas;
        private string casillaSeleccionada;
        private int contador = 0; //Al llegar a 5 la partida de termina

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageVM()
        {
            clsListadoCasillas listado = new clsListadoCasillas();
           // ListadoCasillas = listado.ListadoCompletoCasillas();
        }
                
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<clsCasilla> ListadoCasillas { get; }

        public string CasillaSeleccionada
        {
            get
            {
                return casillaSeleccionada;                
            }
            set
            {
                casillaSeleccionada = value;
                NotifyPropertyChanged("CasillaSeleccionada"); //CasillaSeleccionada notifica el cammbio
            }
        }        
    }
}
