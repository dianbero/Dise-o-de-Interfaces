using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_19_ChatServer.Startup))]

namespace _19_ChatServer
{
    public class Startup
    {
        //esto es para que toda la aplicación mapee en signalR
        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR(); //La app mapea mis asignaciones de signalR
        }
    }
}
