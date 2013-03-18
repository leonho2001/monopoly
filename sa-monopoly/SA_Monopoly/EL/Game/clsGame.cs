using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Game
{
    class clsGame
    {
        // fields
        private int gameID;
        private string hostIP;
        private List<clsPlayer> playerList;
        private int turnOfPlayer;

        // properties
        public int GameID
        {
            get { return gameID; }
            set { gameID = value; }
        }

        public string HostIP
        {
            get { return hostIP; }
            set { hostIP = value; }
        }

        public List<clsPlayer> PlayerList
        {
            get { return playerList; }
            set { playerList = value; }
        }

        public int TurnOfPlayer
        {
            get { return turnOfPlayer; }
            set { turnOfPlayer = value; }
        }

        public clsGame(int ID, string HostIP)
        {
            gameID = ID;
            hostIP = HostIP;
        }

        // constructor
        public clsGame()
        {
            playerList = new List<clsPlayer>();
            // init
            clsPlayer player1 = new clsPlayer(1, "player1", "10.0.0.1");
            clsPlayer player2 = new clsPlayer(2, "player2", "10.0.0.2");

            playerList.Add(player1);
            playerList.Add(player2);
        }
    }
}
