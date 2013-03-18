using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Net.Sockets;
using System.Net;

using SA_Monopoly.EL.Game;

namespace SA_Monopoly.BLL.Server
{
    class Server
    {
        static public clsGame GAME = new clsGame();

        #region Listen Server
        static public int playerCount = -1;
        static public bool Done = false;
        static public bool isBegin = false;
        public static Hashtable clientsList = new Hashtable();
        TcpListener ser = new TcpListener(IPAddress.Any, 1080);
        
        public void StartServer()
        {
            TcpClient clientSocket = default(TcpClient);
            ser.Start();
            while (true)
            {
                string dataFromClient = null;
                clientSocket = ser.AcceptTcpClient();    
                dataFromClient = Support.receiveData(clientSocket);
                string[] dataTemp = dataFromClient.Split('#'); 
                if (dataTemp[0] == "join" && playerCount < 3)
                {
                    
                    IPEndPoint ip = (IPEndPoint)clientSocket.Client.RemoteEndPoint;
                    clientsList.Add(ip.Port.ToString(), clientSocket);
                    playerCount = clientsList.Count - 1;
                    string a = playerCount.ToString();
                    if (playerCount == 0)
                    {
                        GAME.GameID = 0;
                        GAME.HostIP = ip.Address.ToString();
                        GAME.PlayerList.Add(new clsPlayer(playerCount, "Player1", GAME.HostIP));
                    }
                    else if (playerCount != 0)
                    {
                        GAME.PlayerList.Add(new clsPlayer(playerCount, "Player" + clientsList.Count, ip.Address.ToString()));
                    }
                    
                    broadcast(dataTemp[1] + "#" + a);
                    ClientHandler client = new ClientHandler();
                    client.startClient(clientSocket, a, clientsList);
                }
                else
                {
                    Support.sendData(clientSocket, "full");
                }
            }
        }

        public void StopServer()
        {
            ser.Stop();
            Done = true;
        }

        public static void broadcast(string msg)
        {
            if (Done == false)
            {
                foreach (DictionaryEntry Item in clientsList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    Support.sendData(broadcastSocket, msg);
                }
            }
        }  //end broadcast function
        #endregion
    }
}
