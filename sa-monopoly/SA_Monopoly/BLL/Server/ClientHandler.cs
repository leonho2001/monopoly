using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.Windows;

namespace SA_Monopoly.BLL.Server
{
    class ClientHandler
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(Run);
            ctThread.Start();
        }

        private void Run()
        {
            string dataFromClient = null;
            string[] temp;
            while (true)
            {
                if (Server.isBegin == true)
                {
                    try
                    {
                        //receive from client
                        dataFromClient = Support.receiveData(clientSocket);
                        temp = dataFromClient.Split('_');
                        if (temp[0] == "ALL")
                        {
                            Random rand = new Random();
                            int result = rand.Next(0, 1000) % (Server.playerCount + 1);

                            Server.GAME.TurnOfPlayer = result;
                            //broadcast for all client 
                            Server.broadcast(temp[1] + "#" + Support.EncrytFromGame(Server.GAME));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}

