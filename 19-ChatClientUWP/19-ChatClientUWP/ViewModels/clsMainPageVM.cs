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
    class clsMainPageVM 
    {
        //falta commands


        public ObservableCollection<clsMensaje> ListaMensajes { get; set; } = new ObservableCollection<clsMensaje>();

        private HubConnection conn;
        private IHubProxy proxy;


        private void SignalR()
        {
            //TODO terminar
            conn = new HubConnection("http://localhost:53376/");
            proxy = conn.CreateHubProxy("ChatHub"); //ChatHub en proyecto ChatServer
            conn.Start();

            //Lo que va a hacer cuando reciba el mensaje
            proxy.On<string, string>("broadcastMessage", OnMessage);
                       
        }

        public void Broadcast(string nombre, string mensaje)
        {
            proxy.Invoke("Send", nombre, mensaje);
        }
        private async void OnMessage(string nombre, string mensaje)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                clsMensaje objMensaje = new clsMensaje();
                objMensaje.name = nombre;
                objMensaje.message = mensaje;
                //listView
                ListaMensajes.Add(objMensaje);
            });
        }


        #region Propiedades Públicas
        public HubConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }
        public IHubProxy Proxy
        {
            get { return proxy; }
            set { proxy = value; }
        }
        #endregion


    }
}
