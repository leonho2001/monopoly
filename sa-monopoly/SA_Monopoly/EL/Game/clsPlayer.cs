using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Card;
using SA_Monopoly.EL.Property;

namespace SA_Monopoly.EL.Game
{
    class clsPlayer
    {
        // fields
        private int playerID;
        private string playerName;
        private string playerIP;
        private bool hostOrNot;
        private long playerMoney;
        private bool isInJail;
        private int inJailTurn;
        private int doubleTurn;
        private long income;
        private List<clsCard> freeJailCard;
        private List<clsProperty> propertiesList;
        private clsToken token;
        private int position;

        // properties
        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public string PlayerIP
        {
            get { return playerIP; }
            set { playerIP = value; }
        }

        public bool HostOrNot
        {
            get { return hostOrNot; }
            set { hostOrNot = value; }
        }

        public long PlayerMoney
        {
            get { return playerMoney; }
            set { playerMoney = value; }
        }

        public bool IsInJail
        {
            get { return isInJail; }
            set { isInJail = value; }
        }

        public int InJailTurn
        {
            get { return inJailTurn; }
            set { inJailTurn = value; }
        }

        public int DoubleTurn
        {
            get { return doubleTurn; }
            set { doubleTurn = value; }
        }

        public long Income
        {
            get { return income; }
            set { income = value; }
        }

        public List<clsCard> FreeJailCard
        {
            get { return freeJailCard; }
            set { freeJailCard = value; }
        }

        public List<clsProperty> PropertiesList
        {
            get { return propertiesList; }
            set { propertiesList = value; }
        }

        public clsToken Token
        {
            get { return token; }
            set { token = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        // constructor
        public clsPlayer()
        {
            playerMoney = 1500000;
            propertiesList = new List<clsProperty>();
            freeJailCard = new List<clsCard>();
            token = new clsToken();
        }

        public clsPlayer (int ID, string Name, string IP)
        {
            playerID = ID;
            playerName = Name;
            playerIP = IP;

            playerMoney = 1500000;
            propertiesList = new List<clsProperty>();
            freeJailCard = new List<clsCard>();
            token = new clsToken();
        }
    }
}
