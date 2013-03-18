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
    class myPolygon
    {
        Path polygon;
        const string PLAYER1COLOR = "#FFFF0000";
        const string PLAYER2COLOR = "#FF08FD00";
        const string PLAYER3COLOR = "#FF5800FB";
        const string PLAYER4COLOR = "#FF0AF7F2";

        public myPolygon(Path p)
        {
            this.polygon = p;
        }

        void changePolygonColor(Path polygon, string colStr)
        {
            ColorConverter cc = new ColorConverter();
            Color color = (Color)cc.ConvertFrom(colStr);

            LinearGradientBrush lgb = new LinearGradientBrush(color, color, new Point(0, 0), new Point(1, 1));
            polygon.Fill = lgb;
        }

        public void setOwner(int playerNo)
        {
            switch (playerNo)
            {
                case 1: changePolygonColor(polygon, PLAYER1COLOR); break;
                case 2: changePolygonColor(polygon, PLAYER2COLOR); break;
                case 3: changePolygonColor(polygon, PLAYER3COLOR); break;
                case 4: changePolygonColor(polygon, PLAYER4COLOR); break;
                default: changePolygonColor(polygon, "#FFFFFFFF"); break;
            }
        }
    }
}
