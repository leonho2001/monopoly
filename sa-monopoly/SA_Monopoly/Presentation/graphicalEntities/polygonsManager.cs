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
    class polygonsManager
    {
        List<myPolygon> listPolygons;

        public polygonsManager(List<Path> list)
        {
            this.listPolygons = new List<myPolygon>();
            foreach (Path item in list)
            {
                myPolygon temp = new myPolygon(item);
                this.listPolygons.Add(temp);
            }
        }

        public void setOwnerAt(int index, int playerNo)
        {
            listPolygons[index].setOwner(playerNo);
        }
    }
}
