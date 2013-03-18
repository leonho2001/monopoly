using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Property
{
    class clsUltility : clsSpecialProperty
    {
        private long multiplier1;

        public long Multiplier1
        {
            get { return multiplier1; }
            set { multiplier1 = value; }
        }

        private long multiplier2;

        public long Multiplier2
        {
            get { return multiplier2; }
            set { multiplier2 = value; }
        }

        private int peers;

        public int Peers
        {
            get { return peers; }
            set { peers = value; }
        }

        public clsUltility()
        { }

        public clsUltility(string p)
        {
            this.PropertyID = p;
        }
    }
}
