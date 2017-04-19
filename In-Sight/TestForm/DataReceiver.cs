using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace TestForm
{

    public delegate void ClientConnectedHandler();
    public delegate void ClientDisconnectedHandler(string ErrorMessage);
    public delegate void DataReceivedHandler(string Data);
    public delegate void MessageHandler(string msg);

    public class DataReceiver
    {

        private Thread MainThread;
        private bool isRunning;

        #region Delegation
        private static ClientConnectedHandler ClientConnectedEvent;
        private static ClientDisconnectedHandler ClientDisconnectedEvent;
        private static DataReceivedHandler DataReceivedEvent;
        private static MessageHandler MessageEvent;


        public event ClientConnectedHandler ClientConnected
        {
            add { ClientConnectedEvent += new ClientConnectedHandler(value);  }
            remove { ClientConnectedEvent -= new ClientConnectedHandler(value); }
        }
        public event ClientDisconnectedHandler ClientDisconnected
        {
            add { ClientDisconnectedEvent += new ClientDisconnectedHandler(value); }
            remove { ClientDisconnectedEvent -= new ClientDisconnectedHandler(value); }
        }
        public event DataReceivedHandler DataReceived
        {
            add { DataReceivedEvent += new DataReceivedHandler(value); }
            remove { DataReceivedEvent -= new DataReceivedHandler(value); }
        }
        public event MessageHandler MessageReceived
        {
            add { MessageEvent += new MessageHandler(value); }
            remove { MessageEvent -= new MessageHandler(value); }
        }
        

        #endregion


        #region LocalVarible
        private string ServerAddress = "";
        private int ServerPort = 0;
        private TcpClient Client = new TcpClient();
        int BUFFER_SIZE = 65535;
        int RECONNECT_COUNT = 5;
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
            
        }

        public bool Connect()
        {
            try
            {
                this.Client = new TcpClient(ServerAddress, ServerPort);
                ClientConnectedEvent();
                return true;

            }
            catch (Exception Error)
            {
                ClientDisconnectedEvent(Error.Message);
                return false;
            }
            
        }

        #endregion


        public void Run()
        {
            if (!isRunning)
            {
                this.Connect();
                MainThread = new Thread(RunProcess);
                MainThread.IsBackground = true;
                MainThread.Start();
            }

        }

        public void Stop()
        {
            isRunning = false;
            if (MainThread != null)
            {
                MainThread.Abort();
            }
            this.Client.Close();
            MessageEvent("Process Stop");
            
        }
        
        private void RunProcess()
        {
            isRunning = true;
            while (true)
            {
                if (Client.Client == null || Client.Connected == false)
                {
                    ClientDisconnectedEvent("Server Disconnected");
                    this.ReConnect();
                }
                else
                {

                    NetworkStream mStream = Client.GetStream();
                    byte[] buffer = new byte[BUFFER_SIZE];
                    try
                    {
                        lock (mStream)
                        {
                            int bytesRead = mStream.Read(buffer, 0, BUFFER_SIZE);
                            string mData = Encoding.ASCII.GetString(buffer).Trim();
                            if (mData[0] == '\0')
                            {
                                throw new Exception("Server No Response");
                            }
                            else
                            {
                                DataReceivedEvent(mData);
                            }
                            
                        }
                    }
                    catch(Exception Error)
                    {
                        Client.Close();
                        ClientDisconnectedEvent(Error.Message);
                    }
                    

                }
            }
        }

        /*
        private void RunProcess()
        {
            for (int i = 0; i < 100; i++)
            {
                MessageEvent(i.ToString());
            }

            MessageEvent("Finished");
        }
        */

        private void ReConnect()
        {
            bool isConnected = false;
            while(isConnected == false)
            {
                for (int i = RECONNECT_COUNT; i > 0; i--)
                {
                    MessageEvent("Server Disconnected, Retry in " + i + " Second...");
                    Thread.Sleep(1000);
                }
                MessageEvent("Reconnecting Server");
                isConnected = this.Connect();
            }

            
        }


    }
}
