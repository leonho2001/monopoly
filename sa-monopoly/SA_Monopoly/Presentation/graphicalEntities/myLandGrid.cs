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
    class myLandGrid
    {
        int soHouse = 0;
        int soHotel = 0;

        BitmapImage imgHotel;
        BitmapImage imgHouse;
        Grid grdLand;

        public int SoHotel
        {
            get { return soHotel; }
        }

        public int SoHouse
        {
            get { return soHouse; }
        }

        public myLandGrid(Grid grd)
        {
            Uri src1 = new Uri(@"/Presentation/imgs/hotel.png", UriKind.Relative);
            Uri src2 = new Uri(@"/Presentation/imgs/house.png", UriKind.Relative);
            imgHotel = new BitmapImage(src1);
            imgHouse = new BitmapImage(src2);

            this.grdLand = grd;
        }

        public void addHouse()
        {
            if (soHouse < 3)
            {
                Image temp = new Image();
                temp.Source = imgHouse;
                grdLand.Children.Add(temp);
                Grid.SetColumn(temp, soHouse);
                Grid.SetRow(temp, 0);
                soHouse++;
            }

        }

        public void addHotel()
        {
            if (soHotel < 1 && soHouse == 3)
            {
                grdLand.Children.Clear();
                Image temp = new Image();
                temp.Source = imgHotel;
                grdLand.Children.Add(temp);
                Grid.SetColumn(temp, soHotel);
                Grid.SetRow(temp, 0);
                soHotel++;
            }
        }
    }
}
