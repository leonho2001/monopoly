using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Game
{
    class clsToken
    {
        private int tokenID;

        public int TokenID
        {
            get { return tokenID; }
            set { tokenID = value; }
        }

        private string tokenColor;

        public string TokenColor
        {
            get { return tokenColor; }
            set { tokenColor = value; }
        }
    }
}
