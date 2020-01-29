//using _17_CRUD_Personas_UWP_DAL.Manejadoras;
//using _22_CRUD_Xamarin_DAL.Lists;
//using _22_CRUD_Xamarin_Entitites;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _22_CRUD_Xamarin_BL.Handlers
//{
//    public class clsOperacionesBL
//    {   
//        public int Borrar { get; set; }
//        public int Insertar { get; set; }
//        //public ObservableCollection<clsPersona> Insertar { get; set; }
//        public int Editar { get; set; }
//        //public ObservableCollection<clsPersona> ListaPersonas { get; set; }
//        public ObservableCollection<clsPersona> ListadoPersonasFiltrado { get; set; }

//        public clsOperacionesBL(clsPersona objPersona)
//        {
//            clsOperaciones operaciones = new clsOperaciones();
//            this.Borrar = operaciones.Borrar(objPersona.Id);
//            this.Insertar = operaciones.Create(objPersona);
//            this.Editar = operaciones.Edit(objPersona);

//            //clsListadoPersonasDAL listadoPersonas = new clsListadoPersonasDAL();
//            //this.ListaPersonas = listadoPersonas.ListadoCompletoPersonas();
//            clsListadoPersonasFiltradoPorNombre listadoFiltrado = new clsListadoPersonasFiltradoPorNombre();
//            this.ListadoPersonasFiltrado = listadoFiltrado.ListadoPersonasFiltradoPorNombre(objPersona);
//        }        
//    }
//}
