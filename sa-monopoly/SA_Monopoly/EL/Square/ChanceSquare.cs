using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Game;
using SA_Monopoly.BLL.Client;

namespace SA_Monopoly.EL.Square
{
    class ChanceSquare : clsSquare
    {
        public override List<clsPlayer> SquareActivate(List<clsPlayer> pll , int it)
        {
            base.SquareActivate(pll, it);
            if (this.SquareName == "CHANCE" || this.SquareName == "COMMUNITY CHEST")
            {
                ctrlCard ctlCard = new ctrlCard();
                ctlCard.ActivateCard(pll, ctrlCard.randomingCard, it);
            }

            return pll;
        }
    }
}
