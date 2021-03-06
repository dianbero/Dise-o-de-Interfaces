﻿using Hospital_BL.Handlers;
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
            //this.controlDiarioMedico = new clsControlDiario();
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
                /*Esto se ha corregido de forma que se compruebe si es nulo el controlDiarioMedico obtenido, y se de el mensaje correspondiente 
                 en caso de serlo. Y así no salte una excepción debido a que sea nulo. Porque esta posibilidad la puedo controlar yo. 
                 No es por un fallo de conexión con la Base de Datos, por tanto debo controlarlo yo, por ello no debo ponerlo como mensaje
                 cuando salte la excepción.*/
                medico = new clsHandlerHospitalBL().getMedico(codigoMedico);
                controlDiarioMedico = new clsHandlerHospitalBL().getControlDiarioPorIdMedico(codigoMedico);

                /*Para comprobar si es null, se hace con el operador, no con el método Equals, porque el método compara objetos, 
                 * sin embargo null no es un objeto, porque si lo hago así salta una excepción*/
                if (controlDiarioMedico == null)  
                {
                    mensajeNoTareas("No hay registros con la fecha actual");
                }
                else
                {
                    //Si no tiene ninguna tarea, muestra mensaje indicándolo
                    if (controlDiarioMedico.PrimeraSesion.Equals("No tiene tareas") &&
                        controlDiarioMedico.SegundaSesion.Equals("No tiene tareas") &&
                        controlDiarioMedico.TerceraSesion.Equals("No tiene tareas") &&
                        controlDiarioMedico.CuartaSesion.Equals("No tiene tareas"))
                    {
                        mensajeNoTareas("No tiene tareas");
                    }
                }   
            }
            //Salta excepción cuando no hay registros para el día actual en la BD
            catch (Exception ex)
            {
                //throw ex;
                //mensajeNoTareas("No hay registros con la fecha actual");
                mensajeNoTareas("Error al conectar con la Base de Datos");
            }
        }

        /// <summary>
        /// Método que muestra mensaje indicando que no tiene ninguna tarea para ese día
        /// </summary>
        private async void mensajeNoTareas(string mensaje)
        {
            ContentDialog mensajeErroneo = new ContentDialog
            {
                Title = mensaje,
                //Content = mensaje,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await mensajeErroneo.ShowAsync();
        }
        

        #endregion

    }
}
