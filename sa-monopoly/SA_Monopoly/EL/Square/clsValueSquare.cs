using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Property;
using SA_Monopoly.EL.Game;
using SA_Monopoly.BLL.Client;

namespace SA_Monopoly.EL.Square
{
    class clsValueSquare : clsSquare
    {
        private clsSpecialProperty prop;

        public clsSpecialProperty Prop
        {
            get { return prop; }
            set { prop = value; }
        }

        public clsValueSquare(int ID, clsSpecialProperty sp, string name)
        {
            this.SquareID = ID;
            this.Prop = sp;
            this.SquareName = name;
        }

        public int checkIfOwn(clsPlayer pl, List<clsPlayer> pll)
        {
            foreach (clsPlayer item in pll)
            {
                if (item != pl)
                {
                    if (item.PropertiesList.Count < 0)
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
            }
            return -1;
        }

        public override List<clsPlayer> SquareActivate(List<clsPlayer> pll, int it)
        {
            int isOwned = checkIfOwn(pll[it], pll);
            if (isOwned == -1 && ctrlSquare.stt == "buy")
            {
                pll[it].PropertiesList.Add(new clsProperty(this.SquareID.ToString()));
                pll[it].PlayerMoney -= ctrlSquare.gia;
            }
            else if(isOwned != -1)
            {
                pll[it].PlayerMoney -= 100000;
                pll[isOwned].PlayerMoney += 100000;
            }
            return pll;
        }
    }
}
