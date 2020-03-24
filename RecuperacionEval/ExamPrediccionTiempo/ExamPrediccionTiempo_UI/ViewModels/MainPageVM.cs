using ExamPrediccionTiempo_BL.Lists;
using ExamPrediccionTiempo_Entities;
using ExamPrediccionTiempo_UI.ViewModels.ToolsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace ExamPrediccionTiempo_UI.ViewModels
{
    public class MainPageVM : clsVMBase
    {
        #region Atributos Privados
        private ObservableCollection<clsCiudad> listadoCiudades;
        private ObservableCollection<clsPrediccion> listadoPredicciones;
        private clsCiudad ciudadSeleccionada;
        private ObservableCollection<clsCiudad> listadoAuxFiltradoCiudades;
        string textoCiudadABuscar;
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
                if (ciudadSeleccionada != null)
                {
                    ObtenerPrediccionCiudad(ciudadSeleccionada.IdCiudad);
                }
            }
        }

        public string TextoCiudadABuscar
        {
            set
            {
                textoCiudadABuscar = value;
                ObtenerListadoCiudadesPorTextoABuscar(textoCiudadABuscar);
            }
        }
        #endregion

        #region Contructor
        public MainPageVM()
        {
            //Rellenar lista ciudades
            ObtenerListadoCiudades();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que obtiene el listado de todas las ciudades, mediante llamada a la API
        /// </summary>
        private async void ObtenerListadoCiudades()
        {
            ObservableCollection<clsCiudad> listaAuxCiudades = new ObservableCollection<clsCiudad>();

            listaAuxCiudades = await new clsListadoCiudadesBL().ListadoCiudades();

            this.listadoCiudades = listaAuxCiudades;
            NotifyPropertyChanged("ListadoCiudades");
        }

        /// <summary>
        /// Método que filtra la lista de ciudades según el texto introducido en la barra de búsqueda
        /// </summary>
        /// <param name="textoABuscar">Texto introducido para filtrar la lista de ciudades</param>
        private async void ObtenerListadoCiudadesPorTextoABuscar(string textoABuscar)
        {

            ObservableCollection<clsCiudad> listaAuxCiudades = new ObservableCollection<clsCiudad>();

            listaAuxCiudades = await new clsListadoCiudadesBL().ListadoCiudades();


            
            if (textoABuscar.Equals(""))
            {
                listadoCiudades = listaAuxCiudades;
            }
            //Si se escribe algo, entonces filtra la lista
            //Quito los elementos en la lista de la vista que no coinciden con la palabra a filtrar
            else
            {
                //Recorre la lista y si el nombre de las ciudades no coinciden con lo escrito, entonces se eliminan
                for (int i = 0; i < listadoCiudades.Count; i++)
                {
                    if (!listadoCiudades[i].NombreCiudad.Contains(textoABuscar))
                    {
                        //this.listadoCiudades.RemoveAt(i);
                        this.listadoCiudades.Remove(listadoCiudades[i]);
                    }
                }

                //Intento de que se actualice la lista al borrar (sin éxito)
                //for (int i = 0; i < listadoCiudades.Count; i++)
                //{
                //    if (!listadoCiudades[i].NombreCiudad.Contains(textoABuscar))
                //    {
                //        for (int j = 0; j < listaAuxCiudades.Count; j++)
                //        {
                //            if (listaAuxCiudades[i].NombreCiudad.Contains(textoABuscar))
                //            {
                //                this.listadoCiudades.Add(listadoCiudades[i]);
                //            }
                //        }
                //    }
                //}

            }

            NotifyPropertyChanged("ListadoCiudades");
        }


        /// <summary>
        /// Método que obtiene el listado de predicciones de una ciudad en tres días según el idCiudad
        /// </summary>
        /// <param name="idCiudad">Id de la ciudad de la que se desea saber la predicción</param>
        private async void ObtenerPrediccionCiudad(int idCiudad)
        {
            ObservableCollection<clsPrediccion> listaAuxPredicciones = new ObservableCollection<clsPrediccion>();

            listaAuxPredicciones = await new clsListadoPrediccionesBL().ObtenerPrediccionCiudad(idCiudad);

            this.listadoPredicciones = listaAuxPredicciones;
            NotifyPropertyChanged("ListadoPredicciones");

        }
        #endregion
    }
}
