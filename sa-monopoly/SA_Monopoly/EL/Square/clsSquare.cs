using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Game;
using SA_Monopoly.BLL.Client;

namespace SA_Monopoly.EL.Square
{
    class clsSquare
    {
        private int squareID;

        public int SquareID
        {
            get { return squareID; }
            set { squareID = value; }
        }
        private string squareName;

        public string SquareName
        {
            get { return squareName; }
            set { squareName = value; }
        }

        public virtual List<clsPlayer> SquareActivate(List<clsPlayer> pll, int inTurnPl)
        {
           

            if (this.squareName == "GO TO JAIL")
            {
                pll[inTurnPl].Position = 10;
            }
            else if (this.squareName == "LUXURY TAX")
            {
                pll[inTurnPl].PlayerMoney -= 75000; 
            }
            else if (this.squareName == "INCOME TAX")
            {
                if (ctrlSquare.stt == "income")
                {
                    pll[inTurnPl].PlayerMoney -= (long)(pll[inTurnPl].Income * 0.2);
                }
                else pll[inTurnPl].PlayerMoney -= 200000;
            }

            return pll;
        }
 
    }
}
