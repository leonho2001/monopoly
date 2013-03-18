using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Property
{
    class clsProperty
    {
        private string propertyID;

        public string PropertyID
        {
            get { return propertyID; }
            set { propertyID = value; }
        }

        public clsProperty()
        { }

        public clsProperty(string p)
        {
            this.propertyID = PropertyID;
        }
    }
}
