using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace _19_ChatServer
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        //public void Send(/*clsMensaje mensaje*/)
        //{
        //    // Call the broadcastMessage method to update clients.
        //    Clients.All.broadcastMessage(mensaje);
        //}

        /// <summary>
        /// Los clientes llamarán a este método (desde universal) cuando quieran 
        /// que su mensaje aparezca en el listado de mensaje de los demás clientes.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message); //Esto es código del cliente que recibe name y message
        }
    }
}