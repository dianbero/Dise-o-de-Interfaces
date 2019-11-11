using _16_Commands._2_Entities;
using _16_Commands._2_UI.Utilidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace _16_Commands._2_UI.ViewModels
{
    public class clsMainPageVM : INotifyPropertyChanged
    {
        //Necesitamos un objeto personaSeleccionada(objPersona) y una lista de personas que me la ofrece una clase de utilidades
        //Necesito atributo privado de personaSeleccionada

        //Atributos privados
        private clsPersona personaSeleccionada;
        //private List<clsPersona> listadoPersona;
        private ObservableCollection<clsPersona> listadoPersona;
        private DelegateCommand eliminar; //Comando
        private DelegateCommand buscar; //Comando
        private string textoPersonaABuscar;
        ObservableCollection<clsPersona> listaPersonasAMostrar;
         

        //Instancio controlador de eventos
        public event PropertyChangedEventHandler PropertyChanged;

        //Constructor por defecto
        public clsMainPageVM()
        {
            //Rellenamos la lista de persona 
            this.ListadoPersona = clsListadoPersonas.ListadoCompletoPersonas();
            this.Eliminar = new DelegateCommand(BtnEliminar_Click);
            this.Buscar = new DelegateCommand(BtnBuscar_Click);
            this.TextoPersonaABuscar = personaSeleccionada.Nombre; 
        }

        private void BtnEliminar_Click()
        {
            //NotifyPropertyChanged("PersonaSeleccionada");
            ListadoPersona.Remove(this.personaSeleccionada); //Elimina persona seleccionada
            throw new NotImplementedException();
        }

        private void BtnBuscar_Click()
        {
            listaPersonasAMostrar = new ObservableCollection<clsPersona>();
            listaPersonasAMostrar.Add();
        }

        //public void BtnEliminar_Click(object sender, RoutedEventArgs e)
        //{            
        //    NotifyPropertyChanged("PersonaSeleccionada");
        //    ListadoPersona.Remove(this.personaSeleccionada); //Elimina persona seleccionada            
        //}

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
            set{ listadoPersona = value; }
        }

        public DelegateCommand Eliminar //Creo que eliminar debería notificar cambio 
        {
            get { return eliminar; }
            set { eliminar = value; }
        }
        private DelegateCommand Buscar
        {
            get { return buscar; }
            set { buscar = value; }
        }

        private string TextoPersonaABuscar
        {
            get { return textoPersonaABuscar; }
            set { textoPersonaABuscar = value; }
        }
        ObservableCollection<clsPersona> ListaPersonasAMostrar
        {
            get { return listaPersonasAMostrar; }
            set { listaPersonasAMostrar = value; }
        }
    }
}
