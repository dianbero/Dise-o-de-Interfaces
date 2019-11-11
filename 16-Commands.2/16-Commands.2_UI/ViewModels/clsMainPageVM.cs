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

        /*Cosas a añadir: 
         Preguntar si desea eliminar
         Seleccionar al hacer click con botón derecho en (codeBehind)
         Añadir menú con botón eliminar*/

        //Atributos privados
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersona> listadoPersona;
        private DelegateCommand eliminar; //Comando
        private DelegateCommand buscar; //Comando
        private string textoPersonaABuscar;
        ObservableCollection<clsPersona> listaPersonasAMostrar; //Filtrada
         

        //Instancio controlador de eventos
        public event PropertyChangedEventHandler PropertyChanged;

        //Constructor por defecto
        public clsMainPageVM()
        {            
            //Rellenamos la lista de persona 
            this.ListadoPersona = clsListadoPersonas.ListadoCompletoPersonas();
            this.ListaPersonasAMostrar = clsListadoPersonas.ListadoCompletoPersonas();

            //Defino el comportamiento de los botones
            this.Eliminar = new DelegateCommand(EliminarExecute, EliminarCanExecute); //Uso segundo constructor porque no siempre va a estar habilitado
            this.Buscar = new DelegateCommand(BuscarExecute, BuscarCanExecute);
            //this.TextoPersonaABuscar = personaSeleccionada.Nombre; 
        }

        #region "Comandos"

        //TODO: añadir comandos
        /// <summary>
        /// Método para eliminar elemento de la lista de personas
        /// Código asociado al execute del comando eliminar
        /// </summary>
        private void EliminarExecute()
        {
            //si la lista es un observable collection no hace falta notificar el cambio
            ListadoPersona.Remove(this.personaSeleccionada); //Elimina persona seleccionada
            NotifyPropertyChanged("ListadoPersona"); //Notifica el cambio a la vista para que se actualice
        }

        /// <summary>
        /// Código asociado al CanExecute del comando eliminar
        /// Método que indica que se habilitarán o no lo elementos de comando eliminar
        /// </summary>
        /// <returns>
        /// Devuelve true si personaSeleccionada es distinto de null
        /// </returns>
        private bool EliminarCanExecute()
        {
            bool hayPersonaSeleccionada = false;
            if (this.personaSeleccionada != null)
            {
                hayPersonaSeleccionada = true;
            }
            return hayPersonaSeleccionada;
        }

        /// <summary>
        /// Método que busca los elementos de la lista, asociado al comando buscar
        /// </summary>
        private void BuscarExecute()
        {
            //Comprueba si lo que se escribe se corresponde a lo que hay en la lista de personas, entonces filtra la lista

            //if (textoPersonaABuscar.ToString().Equals(clsListadoPersonas.ListadoCompletoPersonas().ToString()))
            //{
            //    ListadoPersona.Remove(this.personaSeleccionada);  //Elimina de la lista de personas a filtrar la
            //}

            //for (int i = 0; i < ListadoPersona.Count; i++)
            //{
            //    if (listadoPersona.)
            //    {

            //    }
            //}

            ListaPersonasAMostrar = new ObservableCollection<clsPersona>(listadoPersona.ToList().FindAll(persona =>String.Concat(personaSeleccionada.Nombre).Contains(textoPersonaABuscar)));
            NotifyPropertyChanged("ListaPersonasAMostrar");

        }

        /// <summary>
        /// Método que indica si se habilitarán los elementos asociado al comando buscar  //Porque el usuario tendrá varias opciones para realizar la acción buscar
        /// </summary>
        /// <returns>Bolean que indica si hay personas a buscar</returns>
        private bool BuscarCanExecute()
        {
            bool hayPersonaABuscar = false;
            if (textoPersonaABuscar != null)
            {
                hayPersonaABuscar = true;
            }
            return hayPersonaABuscar;
        }
        #endregion

        //private DelegateCommand BtnEliminar_Click()
        //{
        //    //NotifyPropertyChanged("PersonaSeleccionada");
        //    ListadoPersona.Remove(this.personaSeleccionada); //Elimina persona seleccionada
        //    throw new NotImplementedException();
        //}

        //private void BtnBuscar_Click()
        //{
        //    listaPersonasAMostrar = new ObservableCollection<clsPersona>();
        //}

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
                    Eliminar.RaiseCanExecuteChanged(); 
                    //NotifyPropertyChanged("PersonaSeleccionada"); //Notifica que la persona seleccionada ha cambiado
                    /*Aquí no lo necesito porque no tengo los datos de las personas, sólo la lista*/
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
            get{ return listadoPersona; } //define eliminar comand
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
            set
            {
                textoPersonaABuscar = value;
                Buscar.RaiseCanExecuteChanged();  //Lanza la ejecución del Execute al haber comprobado que hay personas para buscar
            } 
        }
        ObservableCollection<clsPersona> ListaPersonasAMostrar
        {
            get { return listaPersonasAMostrar; }
            set { listaPersonasAMostrar = value; }
        }
    }
}
