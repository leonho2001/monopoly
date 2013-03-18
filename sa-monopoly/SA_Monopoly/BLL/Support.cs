using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows;
using SA_Monopoly.EL.Game;
using SA_Monopoly.EL.Property;
using SA_Monopoly.EL.Card;

namespace SA_Monopoly.BLL
{
    class Support
    {
        public static void sendData(TcpClient socket, String message)
        {
            try
            {
                NetworkStream stream = socket.GetStream();
                byte[] buffer = Encoding.Unicode.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static string receiveData(TcpClient socket)
        {
            string result = "";

            try
            {
                
                NetworkStream stream = socket.GetStream();
                byte[] buffer = new byte[1024];

                int numofBytes = 0;

                do
                {
                    numofBytes = stream.Read(buffer, 0, buffer.Length);
                    result += Encoding.Unicode.GetString(buffer, 0, numofBytes);
                } while (stream.DataAvailable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return result;
        }

        static public string GetLocalIP()
        {
            string result = "";
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                if(addr[i].IsIPv6LinkLocal == false && addr[i].IsIPv6Multicast == false && addr[i].IsIPv6SiteLocal == false && addr[i].IsIPv6Teredo == false)
                    result = addr[i].ToString();
            }
            return result;
        }

        static public string EncrytFromGame(clsGame game)
        {
            string result = "";
            result += game.TurnOfPlayer.ToString() + "&";
            foreach (clsPlayer item in game.PlayerList)
            {
                result += item.PlayerID + " " + item.PlayerName + " " + item.PlayerMoney + " " + item.DoubleTurn.ToString()
                    + " " + item.Income.ToString() + " " + item.InJailTurn.ToString() + " " + item.IsInJail.ToString() + " " 
                    + item.Position.ToString() + " "  + item.Token.TokenID.ToString() + "$";
                foreach (clsProperty item1 in item.PropertiesList)
                {
                    
                    if (item1 != item.PropertiesList.Last())
                    {
                        result += item1.PropertyID + " ";
                    }
                    else result += item1.PropertyID + "$";
                }
                if (item.PropertiesList.Count == 0)
                    {
                        result += "0" + "$";
                    }
                foreach (clsCard item2 in item.FreeJailCard)
                {
                   if (item2 != item.FreeJailCard.Last())
                        result += item2.CardID + " ";
                    else result += item2.CardID + "_";
                }
                if (item.FreeJailCard.Count == 0)
                {
                    result += "0" + "_";
                }
            }
            return result;
        }

        static public clsGame DecryptToGameObj(string data)
        {
            clsGame game = new clsGame();
            clsPlayer tempPlayer = new clsPlayer();
            string[] temp = data.Split('&');
            string[] gameNFO = temp[1].Split('_');
            game.TurnOfPlayer = int.Parse(temp[0]);

            foreach (string item in gameNFO)
            {
                
                if (item != "")
                {
                    string[] plyerNFO = item.Split('$');
                    string[] playerMain = plyerNFO[0].Split(' ');
                    string[] playerProps = plyerNFO[1].Split(' ');
                    string[] playerCard = plyerNFO[2].Split(' ');
                    tempPlayer.PlayerID = int.Parse(playerMain[0]);
                    tempPlayer.PlayerName = playerMain[1];
                    tempPlayer.PlayerMoney = long.Parse(playerMain[2]);
                    tempPlayer.DoubleTurn = int.Parse(playerMain[3]);
                    tempPlayer.Income = long.Parse(playerMain[4]);
                    tempPlayer.InJailTurn = int.Parse(playerMain[5]);
                    tempPlayer.IsInJail = bool.Parse(playerMain[6]);
                    tempPlayer.Position = int.Parse(playerMain[7]);
                    tempPlayer.Token.TokenID = int.Parse(playerMain[8]);
                    foreach (string item1 in playerProps)
                    {
                        tempPlayer.PropertiesList.Add(new clsProperty(item1));
                    }
                    foreach (string item2 in playerCard)
                    {
                        tempPlayer.FreeJailCard.Add(new clsSCard(item2));
                    }
                    game.PlayerList.Add(tempPlayer);
                    tempPlayer = new clsPlayer();
                }
            }
            return game;
        }
    }
}
