using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Game;
using SA_Monopoly.EL.Property;
using SA_Monopoly.BLL.Client;

namespace SA_Monopoly.EL.Card
{
    class clsSCard : clsCard
    {
        public clsSCard(string ID)
        {
            this.CardID = ID;
        }

        public clsSCard()
        { }

        private int checkIfOwn(clsPlayer pl, List<clsPlayer> pll)
        {
            foreach (clsPlayer item in pll)
            {
                if (item != pl)
                {
                    foreach (clsProperty item1 in item.PropertiesList)
                    {
                        if (pl.Position == int.Parse(item1.PropertyID))
                        {
                            return item.PlayerID;
                        }
                    }
                }
            }
            return -1;
        }

        private int checkIsNearest(List<int> list, int pos)
        {
            int result;
            result = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if(Math.Abs(pos - list[i]) < result)
                {
                    result = list[i];
                }
            }

            return result;
        }

        private int countStation(clsPlayer pl)
        {
            int count = 0;
            foreach (clsProperty item in pl.PropertiesList)
            {
                if (item.PropertyID == "5" || item.PropertyID == "15"
                    || item.PropertyID == "25" || item.PropertyID == "35")
                {
                    count++;
                }
            }
            return count;
        }

        public override List<clsPlayer> Activate(List<clsPlayer> PLL, int inturn)
        {
            if (this.CardID == "S0")
            {
                int pp = PLL[inturn].Position;
                if(Math.Abs(12 - pp) < Math.Abs(28 - pp))
                    PLL[inturn].Position = 12; 
                else PLL[inturn].Position = 28;
                int isOwned = checkIfOwn(PLL[inturn], PLL);
                if(isOwned == -1 && ctrlCard.stt == "Buy")
                {
                    clsProperty prop = new clsUltility(PLL[inturn].Position.ToString());
                    PLL[inturn].PropertiesList.Add(prop);
                }
                else if (isOwned != -1)
                {
                    PLL[isOwned].PlayerMoney += Math.Abs(PLL[0].Position - pp) * 20000;
                    PLL[inturn].PlayerMoney -= Math.Abs(PLL[0].Position - pp) * 20000;
                }
            }
            else if (this.CardID == "S1")
            {
                int pp = PLL[inturn].Position;
                List<int> distance = new List<int>();
                distance.Add(5);
                distance.Add(15);
                distance.Add(25);
                distance.Add(35);
                PLL[inturn].Position = checkIsNearest(distance, pp);
                int isOwned = checkIfOwn(PLL[inturn], PLL);
                if (isOwned == -1 && ctrlCard.stt == "Buy")
                {
                    clsProperty prop = new clsTrainStation(PLL[inturn].Position.ToString());
                    PLL[inturn].PropertiesList.Add(prop);
                }
                else if(isOwned != -1)
                {
                    PLL[isOwned].PlayerMoney += countStation(PLL[isOwned]) * 50000;
                    PLL[inturn].PlayerMoney -= countStation(PLL[isOwned]) * 50000;
                }
            }
            else if (this.CardID == "S4" || this.CardID == "S5")
            {
                PLL[inturn].FreeJailCard.Add(this);
            }
            return PLL;
        }
    }
}
