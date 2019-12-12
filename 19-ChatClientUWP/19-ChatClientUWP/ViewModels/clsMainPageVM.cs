using _19_ChatClientUWP.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace _19_ChatClientUWP.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        
        #region Propiedades Públicas
        public ObservableCollection<clsMensaje> ListaMensajes { get; set; } = new ObservableCollection<clsMensaje>();

        public clsMensaje MensajeChat
        {
            get { return mensajeChat; }
            set { mensajeChat = value; }
        }

        public DelegateCommand ComandoEnviar
        {
            get { return comandoEnviar; }
            set { comandoEnviar = value; }
        }
        #endregion

        #region Atributos Privados
        private HubConnection conn; //Conexión del hub
        private IHubProxy proxy; //Hub


        private clsMensaje mensajeChat; //Mensaje que envío yo al servidor
        private DelegateCommand comandoEnviar;
        #endregion

        #region Constructores por defecto
        public clsMainPageVM()
        {
            SignalR();
            mensajeChat = new clsMensaje();
            comandoEnviar = new DelegateCommand(Enviar);
        }
        #endregion

        private void SignalR()
        {
            //TODO terminar
            //conn = new HubConnection("http://localhost:53376/"); //instancia conexión

            conn = new HubConnection("https://19-chatserver20191205020104.azurewebsites.net/");
            proxy = conn.CreateHubProxy("ChatHub"); //ChatHub en proyecto ChatServer
            conn.Start(); //empieza conexión

            //Lo que va a hacer cuando reciba el mensaje
            proxy.On<string, string>("broadcastMessage", OnMessage);
            //OnMessage: pinta el mensaje
                       
        }

        
       
        /// <summary>
        /// Muestra mensaje
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="mensaje"></param>
        private async void OnMessage(string nombre, string mensaje)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                clsMensaje objMensaje = new clsMensaje(); //mensaje que te envían otros usuarios
                objMensaje.name = nombre;
                objMensaje.message = mensaje;

                //Hago el listado con el mesaje obtenido
                //listView
                ListaMensajes.Add(objMensaje);
            });
        }


       

        #region Commands
        

        private void Enviar()
        {
            proxy.Invoke("Send", mensajeChat.name, mensajeChat.message); 
        }
        #endregion


    }
}
