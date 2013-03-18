using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SA_Monopoly.DAL;
using SA_Monopoly.EL.Card;
using SA_Monopoly.EL.Game;

namespace SA_Monopoly.BLL.Client
{
    class ctrlCard
    {
        static List<clsCard> cardList = new List<clsCard>();
        CardFactory cardCreator = new CardFactory();
        static public clsCard randomingCard = new clsCard();
        static public string stt = "";

        public ctrlCard()
        {
            getCardList();
        }

        private void getCardList()
        {
            cardList.AddRange(cardCreator.LoadCard("S").ToList());
            cardList.AddRange(cardCreator.LoadCard("G").ToList());
            cardList.AddRange(cardCreator.LoadCard("M").ToList());
        }

        public List<string> getChanceCardContent()
        {
            List<string> result = new List<string>();
            List<clsCard> cl = new List<clsCard>();
            var ccl = from item in cardList
                      where item.Type == "Chance"
                      select item;
            cl = ccl.ToList();
            foreach (clsCard item in cl)
            {
                result.Add(item.Content);
            }
            return result;
        }

        public List<string> getCChestCardContent()
        {
            List<string> result = new List<string>();
            List<clsCard> cl = new List<clsCard>();
            var ccl = from item in cardList
                      where item.Type == "CChest"
                      select item;
            cl = ccl.ToList();
            foreach (clsCard item in cl)
            {
                result.Add(item.Content);
            }
            return result;
        }

        public clsCard getCardByContent(string content)
        {
            foreach (clsCard item in cardList)
            {
                if (item.Content == content)
                {
                    return item;
                }
            }
            return null;
        }

        public clsCard getCardByID(string id)
        {
            foreach (clsCard item in cardList)
            {
                if (item.CardID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void getRandomCard()
        {
            Random rd = new Random();
            int ra = rd.Next(cardList.Count);
            randomingCard = cardList[ra];
        }

        public List<clsPlayer> ActivateCard(List<clsPlayer> pl, clsCard c, int inTurnPl)
        {
            List<clsPlayer> pls = new List<clsPlayer>();
            pls = c.Activate(pl, inTurnPl);
            return pls;
        }
    }
}
