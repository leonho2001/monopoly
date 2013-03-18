using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Property
{
    class clsTrainStation : clsSpecialProperty
    {
        private long rent1;

        public long Rent1
        {
            get { return rent1; }
            set { rent1 = value; }
        }

        private long rent2;

        public long Rent2
        {
            get { return rent2; }
            set { rent2 = value; }
        }

        private long rent3;

        public long Rent3
        {
            get { return rent3; }
            set { rent3 = value; }
        }

        private long rent4;

        public long Rent4
        {
            get { return rent4; }
            set { rent4 = value; }
        }

        public clsTrainStation()
        { }

        public clsTrainStation(string P)
        {
            this.PropertyID = P;
        }
    }
}
