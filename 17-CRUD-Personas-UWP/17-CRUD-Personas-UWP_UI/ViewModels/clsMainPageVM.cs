﻿using _17_CRUD_Personas_UWP_BL.Lists;
using _17_CRUD_Personas_UWP_BL.Operaciones;
using _17_CRUD_Personas_UWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _17_CRUD_Personas_UWP_UI.ViewModels
{
    public class clsMainPageVM : clsVMBase 
    {
        //Necesitamos un objeto personaSeleccionada(objPersona) y una lista de personas que me la ofrece una clase de utilidades
        //Necesito atributo privado de personaSeleccionada

        /*Cosas a añadir: 
         Preguntar si desea eliminar
         Seleccionar al hacer click con botón derecho en (codeBehind)
         Añadir menú con botón eliminar*/

        #region Atributos Privados
        //Atributos privados
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersona> listadoPersonaCompleto;
        private DelegateCommand eliminar; //Comando
        private DelegateCommand buscar; //Comando
        private string textoPersonaABuscar;
        ObservableCollection<clsPersona> listaPersonasAMostrar; //Filtrada
        private DelegateCommand guardar; //Comando
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsDepartamento departamentoSeleccionado;
        #endregion


        #region Propiedades públicas
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
                    NotifyPropertyChanged("PersonaSeleccionada"); //Notifica que la persona seleccionada ha cambiado

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

        public ObservableCollection<clsPersona> ListadoPersonaCompleto
        {
            get{ return listadoPersonaCompleto; } 
            set{ listadoPersonaCompleto = value; }
        }

        public DelegateCommand Eliminar 
        {
            get { return eliminar; } 
            set { eliminar = value; }
        }
        public DelegateCommand Buscar
        {
            get { return buscar; }
            set { buscar = value; }
        }
        
        public string TextoPersonaABuscar 
        {
            get { return textoPersonaABuscar; }
            set
            {
                if (this.textoPersonaABuscar != value)
                {
                    textoPersonaABuscar = value;
                    Buscar.RaiseCanExecuteChanged();  //Lanza la ejecución del Execute al haber comprobado que hay personas para buscar
                    NotifyPropertyChanged("ListaPersonasAMostrar"); 
                }                
            } 
        }
        public ObservableCollection<clsPersona> ListaPersonasAMostrar
        {
            get { return listaPersonasAMostrar; }
            set { listaPersonasAMostrar = value; }
        }

        public DelegateCommand Guardar
        {
            get { return guardar; }
            set { guardar = value; }
        }

        public ObservableCollection<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                if(this.departamentoSeleccionado != null)
                {
                    departamentoSeleccionado = value;
                    NotifyPropertyChanged("DepartamentoSeleccionado");
                }
            }
        }

   
    #endregion


        #region Constructores
        //Constructor por defecto
        public clsMainPageVM()
        {
            //Rellenamos la lista de persona 
            clsListadoPersonaBL listadoPersonas = new clsListadoPersonaBL();
            this.listadoPersonaCompleto = listadoPersonas.ListadoPersonas();

            //TODO: hacer copia de listadoCompleto a listado a mostrar, para no llamar dos veces a la base de datos
            //Buscar cómo hacerlo
            this.ListaPersonasAMostrar = listadoPersonas.ListadoPersonas(); //Listado personas por nombre (que será el texto a buscar)

            clsListadoDepartamentoBL listaDepartamentos = new clsListadoDepartamentoBL();
            this.listaDepartamentos = listaDepartamentos.ListadoDepartamentos(); //Relleno listado departamentos

            //Defino el comportamiento de los botones
            this.Eliminar = new DelegateCommand(EliminarExecute, EliminarCanExecute); //Uso segundo constructor porque no siempre va a estar habilitado
            this.Buscar = new DelegateCommand(BuscarExecute, BuscarCanExecute);
            //TODO: completar resto de comandos
            
        }
        #endregion


        #region "Comandos"

        //TODO: añadir comandos
        /// <summary>
        /// Método para eliminar elemento de la lista de personas
        /// Código asociado al execute del comando eliminar
        /// </summary>

        private async void EliminarExecute()
        {
            //Antes de eliminar la persona, se pregunta al usuario si de verdad lo quiere eliminar
            //ContentDialogResult result = await mensajeEliminarAsync();
            ContentDialog mensaje = new ContentDialog()
            {
                Title = "¿Seguro que desea eliminar la persona?",
                PrimaryButtonText = "Aceptar",
                SecondaryButtonText = "Cancelar",
                DefaultButton = ContentDialogButton.Secondary //Botón default en el segundo (Cancelar)
            };
            ContentDialogResult result = await mensaje.ShowAsync(); //Obteiene resultado del cuadro de texto

            if (result == ContentDialogResult.Primary) //Si el resultado de la acción del cuadro de texto se ejecuta con el primer botón, borra la persona
            {
                //Elimina persona seleccionada
                clsOperacionesBL operacionBorrar = new clsOperacionesBL(personaSeleccionada);
                int resultadoBorrar = operacionBorrar.Borrar;
                NotifyPropertyChanged("ListadoPersona"); //Notifica el cambio a la vista para que se elimina la persona seleccionada
            }
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
            //ListaPersonasAMostrar = new ObservableCollection<clsPersona>(listadoPersona.ToList().FindAll(persona =>String.Concat(personaSeleccionada.Nombre).Contains(textoPersonaABuscar)));
            clsOperacionesBL mostrarListadoPersonas = new clsOperacionesBL(personaSeleccionada);
            NotifyPropertyChanged("ListaPersonasAMostrar"); //Notifica al cambio a la lista de filtrado de personas
        }

        /// <summary>
        /// Método que indica si se habilitarán los elementos asociados al comando buscar  //Porque el usuario tendrá varias opciones para realizar la acción buscar
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

        private void GuardarExecute()
        {
            //TODO: llamar a método insertar persona

        }

        /*private bool GuardarCanExecute()
        {
            bool hayPersonaAGuardar = false;
            if ()
            {

            }
            return hayPersonaAGuardar;
        }*/

        #endregion

    }

}
