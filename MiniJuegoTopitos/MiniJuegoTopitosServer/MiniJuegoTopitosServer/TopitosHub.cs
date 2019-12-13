using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MiniJuegoTopitosServer
{
    public class TopitosHub : Hub
    {
        //TODO modificar para topitos
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}