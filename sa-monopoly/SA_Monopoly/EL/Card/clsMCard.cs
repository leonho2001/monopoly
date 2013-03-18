using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Game;

namespace SA_Monopoly.EL.Card
{
    class clsMCard : clsCard
    {
        private long amount;

        public long Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string receiver;

        public string Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        public override List<clsPlayer> Activate(List<clsPlayer> PLL, int inturn)
        {
            if (this.receiver == "Bank" || this.receiver == "Reader")
            {
                PLL[inturn].PlayerMoney += this.amount;
            }
            else if (this.receiver == "AllOthers")
            {
                PLL[inturn].PlayerMoney += (this.amount * 3);
                foreach (clsPlayer item in PLL)
                {
                    if (PLL.Contains(PLL[inturn]) == false)
                    {
                        item.PlayerMoney -= this.amount;
                    }
                }
            }
            return PLL;
        }
    }
}
