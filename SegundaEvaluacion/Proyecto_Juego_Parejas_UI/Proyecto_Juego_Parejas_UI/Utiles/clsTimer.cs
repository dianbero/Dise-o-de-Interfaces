using Proyecto_Juego_Parejas_UI.ViewModels.ViewModelTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Proyecto_Juego_Parejas_UI.Utiles
{
    public class clsTimer : clsVMBase
    {
        private static Timer objTimer;
        private DateTime tiempoPuntuacion;

        #region Constructor
        public clsTimer()
        {
            this.tiempoPuntuacion = DateTime.Now;,`+
            SetTimer();            
        }
        #endregion

        #region Métodos
        private void SetTimer()
        {
            // Create a timer with a one second interval.
            objTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            objTimer.Elapsed += OnTimedEvent;
            //Indica que Timer debe generar event Elapsed repetidamente (true)
            objTimer.AutoReset = true;
            //Indica si Timer debe generar event Elapsed 
            objTimer.Enabled = true;
        }

        /// <summary>
        /// Método que obtiene la fecha con el tiempo actual en cada intervalo de tiempo del timer
        /// </summary>
        /// <param name="source">Object source</param>
        /// <param name="e">ElapsedEventArgs e, datos del evento Elapsed</param>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Obtiene le fecha y hora en que se produce el evento
            this.tiempoPuntuacion = e.SignalTime;
            NotifyPropertyChanged("txtHMS");
        }
        #endregion

        #region Propiedades Públicas
        public DateTime TiempoPuntuacion
        {
            get
            {
                return tiempoPuntuacion;
            }            
        }
        #endregion


    }
}
