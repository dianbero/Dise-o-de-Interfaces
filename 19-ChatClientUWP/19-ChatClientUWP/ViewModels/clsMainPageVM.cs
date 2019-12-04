using _19_ChatClientUWP.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_ChatClientUWP.ViewModels
{
    class clsMainPageVM
    {
        //con command


        public ObservableCollection<clsMensaje> Messages { get; set; } = new ObservableCollection<clsMensaje>();

        private HubConnection conn;
        private IHubProxy proxy;


        private void SignalR()
        {
            //TODO terminar
        }


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


    }
}
