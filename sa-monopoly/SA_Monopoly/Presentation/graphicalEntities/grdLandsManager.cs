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
    class grdLandsManager
    {
        List<myLandGrid> list;

        public grdLandsManager(List<Grid> listGrd)
        {
            this.list = new List<myLandGrid>();
            foreach (Grid item in listGrd)
            {
                myLandGrid temp = new myLandGrid(item);
                this.list.Add(temp);
            }
        }

        public bool buildHouseAt(int landNo)
        {
            if (list[landNo].SoHouse < 3)
            {
                list[landNo].addHouse();
                return true;
            }
            else return false;
        }

        public bool buildHotelAt(int landNo)
        {
            if (list[landNo].SoHotel < 1)
            {
                list[landNo].addHotel();
                return true;
            }
            else return false;
        }
    }
}
