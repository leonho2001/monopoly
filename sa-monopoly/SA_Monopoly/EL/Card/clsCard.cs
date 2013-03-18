using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SA_Monopoly.EL.Game;

namespace SA_Monopoly.EL.Card
{
     class clsCard
    {
        private string cardID;

        public string CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public clsCard()
        { }

        public clsCard(string ID)
        {
            this.CardID = ID;
        }

        virtual public List<clsPlayer> Activate(List<clsPlayer> pll, int inTurnPl)
        {
            return null;
        }
    }
}
