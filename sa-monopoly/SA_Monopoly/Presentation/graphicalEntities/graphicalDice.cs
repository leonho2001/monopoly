using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace SA_Monopoly.Presentation
{
    class graphicalDice
    {
        List<Image> list;
        int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        void resetList()
        {
            for (int i = 0; i < 6; i++)
            {
                list[i].Opacity = 0;
            }
        }

        public graphicalDice(List<Image> list)
        {
            this.list = list;
        }

        public void rollDice(int i)
        {
            resetList();
            this.list[i].Opacity = 1;
            value = i + 1;
        }
    }
}
