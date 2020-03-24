using Examen2EvalUWP_BL.Lists;
using Examen2EvalUWP_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2EvalUWP_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsCiudad> listadoCiudades;
        private ObservableCollection<clsPrediccion> listadoPredicciones;
        private clsCiudad ciudadSeleccionada;
        #endregion

        #region Propiedades Públicas
        public ObservableCollection<clsCiudad> ListadoCiudades
        {
            get
            {
                return listadoCiudades;
            }
        }

        public ObservableCollection<clsPrediccion> ListadoPredicciones
        {
            get
            {
                return listadoPredicciones;
            }
        }

        public clsCiudad CiudadSeleccionada
        {
            get
            {
                return ciudadSeleccionada;
            }
            set
            {
                ciudadSeleccionada = value;
                this.listadoPredicciones = listaPrediccionesPrueba(ciudadSeleccionada.IdCiudad);
                NotifyPropertyChanged("CiudadSeleccionada");
                NotifyPropertyChanged("ListadoPredicciones");
            }
        }
        #endregion

        #region Contructor
        public MainPageVM()
        {
            //Rellenar lista ciudades
            //ObtenerListadoCiudades();

            this.listadoCiudades = listaCiudadesPrueba();
            //this.listadoPredicciones = listaPrediccionesPrueba();
            
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que obtiene el listado de ciudades llamando a la api de forma asíncrona
        /// </summary>
        //private async void ObtenerListadoCiudades()
        //{
        //    ObservableCollection<clsPersona> listaAuxCiudades = new ObservableCollection<clsPersona>();
        //    clsListadoCiudadesBL listCity = new clsListadoCiudadesBL();

        //    listaAuxCiudades = await new clsListadoCiudadesBL().ListadoCiudades();

        //    this.listadoCiudades = listaAuxCiudades;
        //    NotifyPropertyChanged("ListadoCiudades");
        //}

        //private async void ObtenerPrediccionCiudad(int idCiudad)
        //{
        //    ObservableCollection<clsPersona> listaAuxPredicciones = new ObservableCollection<clsPersona>();
        //    clsListadoCiudadesBL listCity = new clsListadoCiudadesBL();

        //    listaAuxPredicciones = await new clsListadoPrediccionesBL().ObtenerPrediccionCiudad(idCiudad);

        //    this.listadoCiudades = listaAuxPredicciones;
        //    NotifyPropertyChanged("ListadoPredicciones");
        //}


        /// <summary>
        /// Método de prueba para devolver lista falsa de ciudades y comprobar binding
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsCiudad> listaCiudadesPrueba()
        {
            ObservableCollection<clsCiudad> listaCities = new ObservableCollection<clsCiudad>();
            listaCities.Add(new clsCiudad());
            listaCities.Add(new clsCiudad(2, "Sevilla"));
            listaCities.Add(new clsCiudad(3, "Córdoba"));
            listaCities.Add(new clsCiudad(4, "Cádiz"));

            return listaCities;
        }

        /// <summary>
        /// Método de prueba para devolver lista falsa de predicciones y comprobar binding
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsPrediccion> listaPrediccionesPrueba(int idCiudad)
        {
            ObservableCollection<clsPrediccion> listaPredicciones = new ObservableCollection<clsPrediccion>();
            listaPredicciones.Add(new clsPrediccion());
            listaPredicciones.Add(new clsPrediccion(2, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));
            listaPredicciones.Add(new clsPrediccion(2, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));
            listaPredicciones.Add(new clsPrediccion(2, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));

            listaPredicciones.Add(new clsPrediccion(3, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));
            listaPredicciones.Add(new clsPrediccion(3, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));
            listaPredicciones.Add(new clsPrediccion(3, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));


            listaPredicciones.Add(new clsPrediccion(4, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));
            listaPredicciones.Add(new clsPrediccion(4, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));
            listaPredicciones.Add(new clsPrediccion(4, new DateTime(2020, 5, 14), 20, 12, 40.0, "soleado"));

            return listaPredicciones;
        }
        #endregion
    }
}
