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
using System.Windows.Navigation;
using System.Windows.Shapes;

using SA_Monopoly.EL.Property;
using SA_Monopoly.BLL.Client;
using SA_Monopoly.EL.Game;

namespace SA_Monopoly
{
	/// <summary>
	/// Interaction logic for UC_LandInfo.xaml
	/// </summary>
	public partial class UC_LandInfo : UserControl
	{
        MainWindow parent;
        int currentSquare;

		public UC_LandInfo(int currentSquare, MainWindow parent)
		{
			this.InitializeComponent();
            this.currentSquare = currentSquare;
            this.parent = parent;
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            switch (currentSquare)
            {
                case 5:
                case 15:
                case 25:
                case 35:
                    {
                        ctrlSquare ctrl = new ctrlSquare();
                        clsTrainStation train = ctrl.getTrainStationByID(currentSquare.ToString());
                        txtLandName.Text = train.PropertyID;
                        txtInfo.Text =
                            "- Rent 1:    $" + train.Rent1.ToString() + Environment.NewLine +
                            "- Rent 2:    $" + train.Rent2.ToString() + Environment.NewLine +
                            "- Rent 3:    $" + train.Rent3.ToString() + Environment.NewLine +
                            "- Rent 4:    $" + train.Rent4.ToString() + Environment.NewLine;
                        txtPrice.Text = "Price: $" + train.Price;
                        ctrlSquare.gia = train.Price;
                        break;
                    }
                case 1:
                case 3:
                case 6:
                case 8:
                case 9:
                case 11:
                case 13:
                case 14:
                case 16:
                case 18:
                case 19:
                case 21:
                case 23:
                case 24:
                case 26:
                case 27:
                case 29:
                case 31:
                case 32:
                case 34:
                case 37:
                case 39:
                    {
                        ctrlSquare ctrl = new ctrlSquare();

                        clsLand land = ctrl.getLandByID(currentSquare.ToString());
                        txtLandName.Text = land.PropertyID + ". " + ctrl.getPropertyName(land);
                        txtInfo.Text =
                            "- Rent 0:     $" + land.Rent0.ToString() + Environment.NewLine +
                            "- Rent 1:     $" + land.Rent1.ToString() + Environment.NewLine +
                            "- Rent 2:     $" + land.Rent2.ToString() + Environment.NewLine +
                            "- Rent 3:     $" + land.Rent3.ToString() + Environment.NewLine + Environment.NewLine +
                            "- Rent with hotel: $" + land.RentHotel + Environment.NewLine +
                            "Cost to build a house is $" + land.PerHouseCost + Environment.NewLine +
                            "Cost to build a hotel is $" + land.PerHotelCost;
                        txtPrice.Text = "Price: $" + land.Price;
                        ctrlSquare.gia = land.Price;
                        break;
                    }
                case 12:
                case 28:
                    {
                        ctrlSquare ctrl = new ctrlSquare();

                        clsUltility uti = ctrl.getUtilityByID(currentSquare.ToString());
                        txtLandName.Text = uti.PropertyID + ". " + ctrl.getPropertyName(uti);
                        txtInfo.Text =
                            "- Multiplier 1:     $" + uti.Multiplier1.ToString() + Environment.NewLine +
                            "- Multiplier 2:     $" + uti.Multiplier2.ToString() + Environment.NewLine;
                            
                        txtPrice.Text = "Price: $" + uti.Price;
                        ctrlSquare.gia = uti.Price;
                        break;
                    }
                case 30:
                    ctrlSquare squ = new ctrlSquare();
                    squ.ActivateSquare(ctrlGame.clientGame.PlayerList, ctrlGame.clientGame.TurnOfPlayer, squ.getSquareById(currentSquare.ToString()));
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.parent.grdMessage.Children.Clear();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            ctrlSquare.stt = "buy";
            ctrlSquare squ = new ctrlSquare();
            squ.ActivateSquare(ctrlGame.clientGame.PlayerList, ctrlGame.clientGame.TurnOfPlayer, squ.getValueSquareById(currentSquare.ToString()));
            this.parent.updateMoney();
            btnBuy.IsEnabled = false;
        }


	}
}