//using _14_Ej3_Listado_Entities;
using _14_Ej3_Listado_VM_UI.Models;
using _14_Ej3_Listado_VM_UI.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace _14_Ej3_Listado_VM_UI.ViewModels
{
    public class clsMainPageVM : INotifyPropertyChanged
    {
        //Necesitamos un objeto personaSeleccionada(objPersona) y una lista de personas que me la ofrece una clase de utilidades
        //Necesito atributo privado de personaSeleccionada

        //Atributos privados
        private clsPersona personaSeleccionada;
        //private List<clsPersona> listadoPersona;
        private ObservableCollection<clsPersona> listadoPersona;

        //Instancio controlador de eventos
        public event PropertyChangedEventHandler PropertyChanged;

        //Constructor por defecto
        public clsMainPageVM()
        {
            //Rellenamos la lista de persona 
            this.ListadoPersona = clsListadoPersonas.ListadoCompletoPersonas(); 
        }

        public void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            //NotifyPropertyChanged("PersonaSeleccionada");
            ListadoPersona.Remove(this.personaSeleccionada);
            
        }

        //Método para lanzar el evento
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs (propertyName));
        }

        //Propiedades públicas
        public clsPersona PersonaSeleccionada
        {
            get{ return personaSeleccionada; }
            set
            {
                if (PersonaSeleccionada != value) //Para evitar problema StackOverFlow
                {
                    personaSeleccionada = value;
                    NotifyPropertyChanged("PersonaSeleccionada");                    
                }
                //NotifyPropertyChanged("PersonaSeleccionada"); //Es lo que va cambiando //Se manda el nombre de la propiedad pública //TODO: falta implementar el método
            }
        }
        //public List<clsPersona> ListadoPersona
        //{
        //    get{ return listadoPersona; }
        //    set{ listadoPersona = value; }
        //}
        public ObservableCollection<clsPersona> ListadoPersona
        {
            get{ return listadoPersona; }
            set{
                listadoPersona = value;
            }
        }

    }
}
