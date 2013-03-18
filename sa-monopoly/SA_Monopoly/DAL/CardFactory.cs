using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SA_Monopoly.EL.Card;

namespace SA_Monopoly.DAL
{
    class CardFactory
    {
        static string path = @"C:\Users\Leon\Documents\Visual Studio 2010\Projects\ReadDBMonopoly\ReadDBMonopoly\Resources\ChanceCard_V2.xml";
        public clsCard[] LoadCard(string CardT)
        {
    
            XDocument CardFile = XDocument.Load(path);
            switch (CardT)
            {
                case "S":
                    var SCardList = from item in CardFile.Descendants("Card")
                                    where (item.Attribute("CardID").Value.ToString().Substring(0, 1)) == "S"
                                    select new clsSCard
                                    {
                                        CardID = item.Attribute("CardID").Value.ToString(),
                                        Content = item.Attribute("Content").Value.ToString(),
                                        Type = item.Attribute("Type").Value.ToString()
                                    };
                    clsCard[] SCardL = new clsSCard[6];
                    SCardL = SCardList.ToArray();
                    return SCardL;
                case "M":
                    var MCardList = (from item in CardFile.Descendants("Card")
                                     where (item.Attribute("CardID").Value.ToString().Substring(0, 1)) == "M"
                                     select new clsMCard
                                     {
                                         CardID = item.Attribute("CardID").Value.ToString(),
                                         Content = item.Attribute("Content").Value.ToString(),
                                         Type = item.Attribute("Type").Value.ToString(),
                                         Amount = long.Parse(item.Element("MonetaryCard").Attribute("Amount").Value),
                                         Receiver = item.Element("MonetaryCard").Attribute("Receiver").Value.ToString()
                                     }).ToArray();
                    clsCard[] MCardL = new clsMCard[15];
                    MCardL = MCardList;
                    return MCardL;
                case "G":
                    var GCardList = from item in CardFile.Descendants("Card")
                                    where (item.Attribute("CardID").Value.ToString().Substring(0, 1)) == "G"
                                    select new clsGCard
                                    {
                                        CardID = item.Attribute("CardID").Value.ToString(),
                                        Content = item.Attribute("Content").Value.ToString(),
                                        Type = item.Attribute("Type").Value.ToString(),
                                        DSquare = item.Element("GoToCard").Attribute("DestinedSquare").Value
                                    };
                    clsCard[] GCardL = new clsGCard[15];
                    GCardL = GCardList.ToArray();
                    return GCardL;
            }
            return null;
        }
    }
}
