using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Property
{
    class clsSpecialProperty : clsProperty
    {
        private long mortgage;

        public long Mortgage
        {
            get { return mortgage; }
            set { mortgage = value; }
        }

        private long price;

        public long Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
