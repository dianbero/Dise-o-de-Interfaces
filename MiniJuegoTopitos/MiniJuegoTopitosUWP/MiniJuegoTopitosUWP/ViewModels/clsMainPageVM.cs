using Microsoft.AspNet.SignalR.Client;
using MiniJuegoTopitosUWP.Models;
using MiniJuegoTopitosUWP.Models.Entities;
using MiniJuegoTopitosUWP.Models.Utiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJuegoTopitosUWP.ViewModels
{
    public class clsMainPageVM : clsVMBase
    {
        #region Atributos Privados
        //Atributos de signalR
        private HubConnection conn; //Conexión del hub
        private IHubProxy proxy; //Hub

        //---//
        private Uri uriFoto;
        private DelegateCommand comandoMostrarTopo;
        private clsJugador jugador;

        private ObservableCollection<clsTopito> listaTopos;
        private clsTopito topoGolpeado;
        #endregion

        #region Propiedades Públicas
        //public Uri UriFoto
        //{
        //    get { return uriFoto; }
        //    set
        //    {
        //        uriFoto = value;
        //    }
        //}

        public ObservableCollection<clsTopito> ListaTopos
        {
            get
            {
                return listaTopos;
            }
            set
            {
                listaTopos = value;
            }
        }

        
        public clsTopito TopoGolpeado
        {
            get
            {
                return topoGolpeado;
            }
            set
            {                
                if (topoGolpeado != value)
                {
                    topoGolpeado = value;
                    topoGolpeado.IsGolpeado = true;
                    Jugador.EsGanadorTurno = true;

                    Jugador.PuntosJugador = clsPartida.sumarPuntos(Jugador.PuntosJugador, Jugador.EsGanadorTurno);
                    NotifyPropertyChanged("Jugador");
                    //topoGolpeado.FotoTopito = AsignarFotoCasilla();
                    NotifyPropertyChanged("TopoGolpeado");
                }
            }
        }

        public clsJugador Jugador
        {
            get
            {
                return jugador;
            }
            set
            {
                jugador = value;
            }
        }

        #endregion

        #region Constructores
        //Constructor por defecto
        public clsMainPageVM()
        {
            //SignalR();
            //Relleno la lista de las casillas 
            clsUtil listaCasillasConTopo = new clsUtil();
            //this.ListaTopos = listaCasillasConTopo.listaConPosicionTopoAsignada();
            this.ListaTopos = listaCasillasConTopo.listaCasillasTopoInicial();
        }

        #endregion
        private void SignalR()
        {
            //conn = new HubConnection("http://localhost:53376/"); 
            conn = new HubConnection("/*poner dirección topos subido*/"); //instancia conexión
            proxy = conn.CreateHubProxy("TopitosHub"); //ChatHub en proyecto ChatServer
            conn.Start(); //Inicia la conexión

            //Lo que va a hacer cuando reciba el mensaje
            //proxy.On<string, string>("broadcastMessage", OnMessage);

        }
        #region Métodos
        public Uri AsignarFotoCasilla()
        {
            Uri foto;
            if (topoGolpeado.IsGolpeado)
            {
                foto = new Uri("ms-appx:///Assets/Imagen_Topo/PokeTopo.jpg");
            }
            else
            {
                foto = new Uri("ms-appx:///Assets/Imagen_Topo/Topo2.jpg");
            }
            return foto;
        }
        #endregion

        #region Commands
        
        #endregion


    }
}
