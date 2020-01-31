using Proyecto_Juego_Parejas_DAL.Utiles;
using Proyecto_Juego_Parejas_Entities;
using Proyecto_Juego_Parejas_UI.Utiles;
using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Proyecto_Juego_Parejas_UI.ViewModels
{
    public class clsJuegoVM : clsVMBase
    {
        #region Atributos Privados
        private clsCarta cartaSeleccionada;// sustituir en carta1 y carta2
        /*Al seleccionar carta2 se comprueba si son iguales*/
        private clsCarta carta1;
        private clsCarta carta2;
        private ObservableCollection<clsCarta> listadoCompletoCartas;
        private DispatcherTimer tiempoPuntuacion;
        private int repeticiones;

        #endregion

        #region Propieades Públicas
        //public clsCarta CartaSeleccionada
        //{
        //    get
        //    {
        //        return cartaSeleccionada;
        //    }
        //    set
        //    {
        //       // if (cartaSeleccionada != value)
        //        //{
        //            cartaSeleccionada = value;
        //            if (cartaSeleccionada.IsVolteada)
        //            {
        //                cartaSeleccionada.IsVolteada = false;
        //            }
        //            else
        //            {
        //                cartaSeleccionada.IsVolteada = true;
        //            }
        //            NotifyPropertyChanged("CartaSeleccionada");
        //        }
        //   // }
        //}

        public clsCarta CartaSeleccionada
        {
            get
            {
                return cartaSeleccionada;
            }
            set
            {
                cartaSeleccionada = value;
                ComprobarJugada();
                //if (cartaSeleccionada.IsVolteada)
                //{                    
                //    cartaSeleccionada.IsVolteada = false;

                //}
                //else
                //{
                //    cartaSeleccionada.IsVolteada = true;
                //}
                //NotifyPropertyChanged("CartaSeleccionada");
            }
        }

        /// <summary>
        /// cambiar isVolteada a true
        /// dar valor a imgMostrar de cartaSeleccionada
        /// </summary>
        private void ComprobarJugada()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<clsCarta> ListadoCompletoCartas
        {
            get { return listadoCompletoCartas; }
            set { listadoCompletoCartas = value; }
        }

        public DispatcherTimer TiempoPuntuacion
        {
            get
            {
                return tiempoPuntuacion;
            }
        }
        public clsCarta Carta1
        {
            get
            {
                return carta1;
            }
            set
            {
                carta1 = value;
            }
        }
        
        public clsCarta Carta2
        {
            get
            {
                return carta2;
            }
            set
            {
                carta2 = value;
            }
        }
        #endregion

        #region Constructores
        public clsJuegoVM()
        {
            clsListadoCompletoCartas listadoCartas = new clsListadoCompletoCartas();
            //listadoCompletoCartas = listadoCartas.ListadoCompletoCartasEnCasilla();
            listadoCompletoCartas = listadoCartas.listadoCartas();

            //Cosas del DispatcherTimer
            tiempoPuntuacion = new DispatcherTimer();
            //tiempoPuntuacion.Tick += MostrarElementosTiempo();
            tiempoPuntuacion.Interval = new TimeSpan(0, 0, 1);
            //TODO: decidir cuándo empieza el timer, en principio, justo al mostrar la pantalla del juego
            tiempoPuntuacion.Start();
        }
        #endregion

        #region Métodos
        public void MostrarElementosTiempo(object sender, object e)
        {
            DateTime tiempo;
            repeticiones++;

        }
        #endregion


    }
}
