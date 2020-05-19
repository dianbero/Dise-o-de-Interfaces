using Hospital_BL.Handlers;
using Hospital_Entities;
using Hospital_UI.ViewModels.ToolsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Hospital_UI.ViewModels
{
    public class clsTareasVM 
    {
        #region Atributos Privados 
        private clsMedico medico;
        private string codigoMedico;
        private clsControlDiario controlDiarioMedico;
        #endregion

        #region Propieades Públicas
        public clsMedico Medico { get => medico; set => medico = value; }
        public string CodigoMedico
        {
            set
            {
                codigoMedico = value;
                //Cargo el médico y controlDiario aquí y no en el Constructor porque el constructor se carga lo primero y no da tiempo a que pille el valor del código pasado de la otra vista
                getMedicoYControlDiario(); 
            }
        }
        public clsControlDiario ControlDiarioMedico { get => controlDiarioMedico; set => controlDiarioMedico = value; }
        #endregion

        #region Constructores 
        public clsTareasVM()
        {

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que obtiene de la BD el médico y el control diario según el código obtenido de la primera vista
        /// Y si no tiene ninguna tarea para ese día, muestra un mensaje indicándolo
        /// </summary>
        private void getMedicoYControlDiario()
        {
            try
            {
                medico = new clsHandlerHospitalBL().getMedico(codigoMedico);
                controlDiarioMedico = new clsHandlerHospitalBL().getControlDiarioPorIdMedico(codigoMedico);

                if(controlDiarioMedico.PrimeraSesion.Equals("No tiene tareas")&& 
                    controlDiarioMedico.SegundaSesion.Equals("No tiene tareas") && 
                    controlDiarioMedico.TerceraSesion.Equals("No tiene tareas") && 
                    controlDiarioMedico.CuartaSesion.Equals("No tiene tareas"))
                {
                    mensajeNoTareas();
                }

            }
            catch (Exception ex)
            {
                //Este error saltaría porque no se han insertado registros con fecha actual
                throw ex;
            }
        }

        /// <summary>
        /// Método que muestra mensaje indicando que no tiene ninguna tarea para ese día
        /// </summary>
        private async void mensajeNoTareas()
        {
            ContentDialog mensajeErroneo = new ContentDialog
            {
                Title = "No tiene tareas",
                //Content = mensaje,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeErroneo.ShowAsync();
        }
        

        #endregion

    }
}
