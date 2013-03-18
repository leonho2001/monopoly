using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Game;

namespace SA_Monopoly.EL.Card
{
    class clsGCard : clsCard
    {
        private string dSquare;

        public string DSquare
        {
            get { return dSquare; }
            set { dSquare = value; }
        }

        public override List<clsPlayer> Activate(List<clsPlayer> PLL, int inturn)
        {
            clsPlayer pl = new clsPlayer();
            pl = PLL[inturn];
            if (this.dSquare.First() == '+' || this.dSquare.First() == '-')
            {
                pl.Position += int.Parse(this.dSquare);
            }
            else pl.Position = int.Parse(this.dSquare);
            PLL[inturn] = pl;
            return PLL;
        }
    }
}
