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
    class graphicalDicesManager
    {
        graphicalDice dice1;
        graphicalDice dice2;

        public graphicalDicesManager(graphicalDice d1, graphicalDice d2)
        {
            this.dice1 = d1;
            this.dice2 = d2;
        }

        public void rollDices()
        {
            Random rand = new Random();

            int result1 =0, result2 = 0;
            result1 = rand.Next(0, 100000) % 6;
            result2 = rand.Next(0, 100000) % 6;
            
            

            dice1.rollDice(result1);
            dice2.rollDice(result2);
        }
    }
}
