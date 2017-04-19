using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace TestApplication
{

    public delegate void ClientConnectedDelegatation();

    public class DataReceiver
    {


        #region Delegation
        
        public event ClientConnectedDelegatation ClientConnected;

        #endregion


        #region LocalVarible
        private string ServerAddress = "";
        private int ServerPort = 0;
        private TcpClient Client;
        #endregion


        #region Construction
        public DataReceiver(string mServer, int mPort)
        {
            this.ServerAddress = mServer;
            this.ServerPort = mPort;
            InitClient();
            
        }

        public DataReceiver()
        {
            this.ServerAddress = "127.0.0.1";
            this.ServerPort = 3000;
            InitClient();
        }

        private void InitClient()
        {
            this.Client = new TcpClient(ServerAddress, ServerPort);
            
        }


        public void Connect()
        {
            Thread.Sleep(1000);
            ClientConnected();
        }

        #endregion



        #region Delegation

        #endregion

    }
}
