using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MiniJuegoTopitosUWP.Models.Entities;

namespace MiniJuegoTopitosServer
{
    public class TopitosHub : Hub
    {
        //TODO modificar para topitos
        public void Hello()
        {
            Clients.All.hello();
        }


        public void Result(int puntosJugador, bool topitoIsGolpeado)
        {
            Clients.All.broadcastMessage(puntosJugador, topitoIsGolpeado);
        } 
    }
}