using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.Windows;

using SA_Monopoly.EL;
using SA_Monopoly.EL.Game;


namespace SA_Monopoly.BLL.Client
{
    class ctrlGame
    {
        static public clsGame clientGame = new clsGame();

        static public int thisPlayerID = -1;
        int HARDCODE;


        #region Server Interaction
        static TcpClient server;
        static public string readCommand = "";
        static public string readData = "";
        static public bool isConnect = false;
        static Thread ctThread;
        string[] temp;

        public void connectServer(string IP)
        {
            //Connect to server
            server = new TcpClient();
            server.Connect(IP, 1080);


            Random rd = new Random();
            HARDCODE = rd.Next(0, 10000);
            //send Join requset
            Support.sendData(server, "join#"+HARDCODE.ToString());

            //get server message thread
            ctThread = new Thread(getMessage);
            ctThread.Start();
        }

        public void sendMessToServer(string mesg)
        {
            Support.sendData(server, mesg);
        }

        private void getMessage()
        {
            try
            {
                while (true)
                {
                    temp = Support.receiveData(server).Split('#');
                    readCommand = temp[0];
                    readData = temp[1];
                    if (readCommand == HARDCODE.ToString())
                    {
                        thisPlayerID = int.Parse(readData);
                    }
                    else if (readCommand == "start")
                    {
                        clientGame = Support.DecryptToGameObj(readData);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Disconnect()
        {
            server.Close();
            isConnect = false;
        }
        #endregion
    }
}
