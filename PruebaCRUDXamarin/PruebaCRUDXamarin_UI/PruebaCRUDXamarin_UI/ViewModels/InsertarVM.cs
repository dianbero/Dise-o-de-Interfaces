using PruebaCRUDXamarin_BL.Handlers;
using PruebaCRUDXamarin_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PruebaCRUDXamarin_UI.ViewModels
{
    public class InsertarVM : clsVMBase
    {
        #region Atributos Privados
        private DelegateCommand comandoInsertar;
        #endregion

        #region Propiedades Públicas
        public DelegateCommand ComandoInsertar { get; set; }
        #endregion

        #region Contructor
        public InsertarVM()
        {
            comandoInsertar = new DelegateCommand(InsertarExecute);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que inserta una persona 
        /// </summary>
        public async void InsertarExecute()
        {
            Entry input = new Entry();
            clsPersona nuevaPersona = new clsPersona();
            nuevaPersona.Nombre = input.FindByName("txtNombre").ToString();
            nuevaPersona.Apellidos = input.FindByName("txtApellido").ToString();
            //nuevaPersona.FechaNacimiento = input.FindByName("txtFechaNacimiento").ToString();
            nuevaPersona.Telefono = input.FindByName("txtTelefono").ToString();

            await new clsOperacionesBL().InsertarPersona(nuevaPersona);
            
        }
        #endregion
    }
}
