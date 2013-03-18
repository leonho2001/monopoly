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

using SA_Monopoly.Presentation;
using SA_Monopoly.BLL.Client;
using SA_Monopoly.EL.Game;

using System.Threading;

namespace SA_Monopoly
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

        // my code
        // fields

        List<Grid> listGrdLand;
        grdLandsManager landManager;
        List<Path> listPolygons;
        polygonsManager polygonsManager;
        List<Image> listDice1, listDice2;
        graphicalDice dice1, dice2;
        graphicalDicesManager dicesMan;
        List<Image> listPlayer1Tokens;
        List<Image> listPlayer2Tokens;
        List<Image> listPlayer3Tokens;
        List<Image> listPlayer4Tokens;
        tokenImgsManager player1Token;
        tokenImgsManager player2Token;
        tokenImgsManager player3Token;
        tokenImgsManager player4Token;

        

        List<int> listSquareKoHien;



        // constructor
        # region init
        public MainWindow()
        {
            this.InitializeComponent();

            // Insert code required on object creation below this point.

            listDice1 = new List<Image>();
            listDice1.Add(dice11);
            listDice1.Add(dice12);
            listDice1.Add(dice13);
            listDice1.Add(dice14);
            listDice1.Add(dice15);
            listDice1.Add(dice16);
            dice1 = new graphicalDice(listDice1);

            listDice2 = new List<Image>();
            listDice2.Add(dice21);
            listDice2.Add(dice22);
            listDice2.Add(dice23);
            listDice2.Add(dice24);
            listDice2.Add(dice25);
            listDice2.Add(dice26);
            dice2 = new graphicalDice(listDice2);


            dicesMan = new graphicalDicesManager(dice1, dice2);


            

            // khoi tao danh sach lands
            this.listGrdLand = new List<Grid>();
            this.listGrdLand.Add(grdLand1);
            this.listGrdLand.Add(grdLand2);
            this.listGrdLand.Add(grdLand3);
            this.listGrdLand.Add(grdLand4);
            this.listGrdLand.Add(grdLand5);
            this.listGrdLand.Add(grdLand6);
            this.listGrdLand.Add(grdLand7);
            this.listGrdLand.Add(grdLand8);
            this.listGrdLand.Add(grdLand9);
            this.listGrdLand.Add(grdLand10);
            this.listGrdLand.Add(grdLand11);
            this.listGrdLand.Add(grdLand12);
            this.listGrdLand.Add(grdLand13);
            this.listGrdLand.Add(grdLand14);
            this.listGrdLand.Add(grdLand15);
            this.listGrdLand.Add(grdLand16);
            this.listGrdLand.Add(grdLand17);
            this.listGrdLand.Add(grdLand18);
            this.listGrdLand.Add(grdLand19);
            this.listGrdLand.Add(grdLand20);
            this.listGrdLand.Add(grdLand21);
            this.listGrdLand.Add(grdLand22);

            landManager = new grdLandsManager(this.listGrdLand);

            // khoi tao cho list polygons
            this.listPolygons = new List<Path>();
            this.listPolygons.Add(polygon1);
            this.listPolygons.Add(polygon2);
            this.listPolygons.Add(polygon3);
            this.listPolygons.Add(polygon4);
            this.listPolygons.Add(polygon5);
            this.listPolygons.Add(polygon6);
            this.listPolygons.Add(polygon7);
            this.listPolygons.Add(polygon8);
            this.listPolygons.Add(polygon9);
            this.listPolygons.Add(polygon10);
            this.listPolygons.Add(polygon11);
            this.listPolygons.Add(polygon12);
            this.listPolygons.Add(polygon13);
            this.listPolygons.Add(polygon14);
            this.listPolygons.Add(polygon15);
            this.listPolygons.Add(polygon16);
            this.listPolygons.Add(polygon17);
            this.listPolygons.Add(polygon18);
            this.listPolygons.Add(polygon19);
            this.listPolygons.Add(polygon20);
            this.listPolygons.Add(polygon21);
            this.listPolygons.Add(polygon22);
            this.listPolygons.Add(polygon23);
            this.listPolygons.Add(polygon24);
            this.listPolygons.Add(polygon25);
            this.listPolygons.Add(polygon26);
            this.listPolygons.Add(polygon27);
            this.listPolygons.Add(polygon28);

            polygonsManager = new polygonsManager(this.listPolygons);

            listSquareKoHien = new List<int>();
            listSquareKoHien.Add(0);
            listSquareKoHien.Add(2);
            listSquareKoHien.Add(4);
            listSquareKoHien.Add(7);
            listSquareKoHien.Add(10);
            listSquareKoHien.Add(17);
            listSquareKoHien.Add(20);
            listSquareKoHien.Add(22);
            listSquareKoHien.Add(30);
            listSquareKoHien.Add(33);
            listSquareKoHien.Add(36);
            listSquareKoHien.Add(38);

            this.listPlayer1Tokens = new List<Image>();
            listPlayer1Tokens.Add(player1Token0);
            listPlayer1Tokens.Add(player1Token1);
            listPlayer1Tokens.Add(player1Token2);
            listPlayer1Tokens.Add(player1Token3);
            listPlayer1Tokens.Add(player1Token4);
            listPlayer1Tokens.Add(player1Token5);
            listPlayer1Tokens.Add(player1Token6);
            listPlayer1Tokens.Add(player1Token7);
            listPlayer1Tokens.Add(player1Token8);
            listPlayer1Tokens.Add(player1Token9);
            listPlayer1Tokens.Add(player1Token10);
            listPlayer1Tokens.Add(player1Token11);
            listPlayer1Tokens.Add(player1Token12);
            listPlayer1Tokens.Add(player1Token13);
            listPlayer1Tokens.Add(player1Token14);
            listPlayer1Tokens.Add(player1Token15);
            listPlayer1Tokens.Add(player1Token16);
            listPlayer1Tokens.Add(player1Token17);
            listPlayer1Tokens.Add(player1Token18);
            listPlayer1Tokens.Add(player1Token19);
            listPlayer1Tokens.Add(player1Token20);
            listPlayer1Tokens.Add(player1Token21);
            listPlayer1Tokens.Add(player1Token22);
            listPlayer1Tokens.Add(player1Token23);
            listPlayer1Tokens.Add(player1Token24);
            listPlayer1Tokens.Add(player1Token25);
            listPlayer1Tokens.Add(player1Token26);
            listPlayer1Tokens.Add(player1Token27);
            listPlayer1Tokens.Add(player1Token28);
            listPlayer1Tokens.Add(player1Token29);
            listPlayer1Tokens.Add(player1Token30);
            listPlayer1Tokens.Add(player1Token31);
            listPlayer1Tokens.Add(player1Token32);
            listPlayer1Tokens.Add(player1Token33);
            listPlayer1Tokens.Add(player1Token34);
            listPlayer1Tokens.Add(player1Token35);
            listPlayer1Tokens.Add(player1Token36);
            listPlayer1Tokens.Add(player1Token37);
            listPlayer1Tokens.Add(player1Token38);
            listPlayer1Tokens.Add(player1Token39);

            this.listPlayer2Tokens = new List<Image>();
            listPlayer2Tokens.Add(player2Token0);
            listPlayer2Tokens.Add(player2Token1);
            listPlayer2Tokens.Add(player2Token2);
            listPlayer2Tokens.Add(player2Token3);
            listPlayer2Tokens.Add(player2Token4);
            listPlayer2Tokens.Add(player2Token5);
            listPlayer2Tokens.Add(player2Token6);
            listPlayer2Tokens.Add(player2Token7);
            listPlayer2Tokens.Add(player2Token8);
            listPlayer2Tokens.Add(player2Token9);
            listPlayer2Tokens.Add(player2Token10);
            listPlayer2Tokens.Add(player2Token11);
            listPlayer2Tokens.Add(player2Token12);
            listPlayer2Tokens.Add(player2Token13);
            listPlayer2Tokens.Add(player2Token14);
            listPlayer2Tokens.Add(player2Token15);
            listPlayer2Tokens.Add(player2Token16);
            listPlayer2Tokens.Add(player2Token17);
            listPlayer2Tokens.Add(player2Token18);
            listPlayer2Tokens.Add(player2Token19);
            listPlayer2Tokens.Add(player2Token20);
            listPlayer2Tokens.Add(player2Token21);
            listPlayer2Tokens.Add(player2Token22);
            listPlayer2Tokens.Add(player2Token23);
            listPlayer2Tokens.Add(player2Token24);
            listPlayer2Tokens.Add(player2Token25);
            listPlayer2Tokens.Add(player2Token26);
            listPlayer2Tokens.Add(player2Token27);
            listPlayer2Tokens.Add(player2Token28);
            listPlayer2Tokens.Add(player2Token29);
            listPlayer2Tokens.Add(player2Token30);
            listPlayer2Tokens.Add(player2Token31);
            listPlayer2Tokens.Add(player2Token32);
            listPlayer2Tokens.Add(player2Token33);
            listPlayer2Tokens.Add(player2Token34);
            listPlayer2Tokens.Add(player2Token35);
            listPlayer2Tokens.Add(player2Token36);
            listPlayer2Tokens.Add(player2Token37);
            listPlayer2Tokens.Add(player2Token38);
            listPlayer2Tokens.Add(player2Token39);

            this.listPlayer3Tokens = new List<Image>();
            listPlayer3Tokens.Add(player3Token0);
            listPlayer3Tokens.Add(player3Token1);
            listPlayer3Tokens.Add(player3Token2);
            listPlayer3Tokens.Add(player3Token3);
            listPlayer3Tokens.Add(player3Token4);
            listPlayer3Tokens.Add(player3Token5);
            listPlayer3Tokens.Add(player3Token6);
            listPlayer3Tokens.Add(player3Token7);
            listPlayer3Tokens.Add(player3Token8);
            listPlayer3Tokens.Add(player3Token9);
            listPlayer3Tokens.Add(player3Token10);
            listPlayer3Tokens.Add(player3Token11);
            listPlayer3Tokens.Add(player3Token12);
            listPlayer3Tokens.Add(player3Token13);
            listPlayer3Tokens.Add(player3Token14);
            listPlayer3Tokens.Add(player3Token15);
            listPlayer3Tokens.Add(player3Token16);
            listPlayer3Tokens.Add(player3Token17);
            listPlayer3Tokens.Add(player3Token18);
            listPlayer3Tokens.Add(player3Token19);
            listPlayer3Tokens.Add(player3Token20);
            listPlayer3Tokens.Add(player3Token21);
            listPlayer3Tokens.Add(player3Token22);
            listPlayer3Tokens.Add(player3Token23);
            listPlayer3Tokens.Add(player3Token24);
            listPlayer3Tokens.Add(player3Token25);
            listPlayer3Tokens.Add(player3Token26);
            listPlayer3Tokens.Add(player3Token27);
            listPlayer3Tokens.Add(player3Token28);
            listPlayer3Tokens.Add(player3Token29);
            listPlayer3Tokens.Add(player3Token30);
            listPlayer3Tokens.Add(player3Token31);
            listPlayer3Tokens.Add(player3Token32);
            listPlayer3Tokens.Add(player3Token33);
            listPlayer3Tokens.Add(player3Token34);
            listPlayer3Tokens.Add(player3Token35);
            listPlayer3Tokens.Add(player3Token36);
            listPlayer3Tokens.Add(player3Token37);
            listPlayer3Tokens.Add(player3Token38);
            listPlayer3Tokens.Add(player3Token39);

            this.listPlayer4Tokens = new List<Image>();
            listPlayer4Tokens.Add(player4Token0);
            listPlayer4Tokens.Add(player4Token1);
            listPlayer4Tokens.Add(player4Token2);
            listPlayer4Tokens.Add(player4Token3);
            listPlayer4Tokens.Add(player4Token4);
            listPlayer4Tokens.Add(player4Token5);
            listPlayer4Tokens.Add(player4Token6);
            listPlayer4Tokens.Add(player4Token7);
            listPlayer4Tokens.Add(player4Token8);
            listPlayer4Tokens.Add(player4Token9);
            listPlayer4Tokens.Add(player4Token10);
            listPlayer4Tokens.Add(player4Token11);
            listPlayer4Tokens.Add(player4Token12);
            listPlayer4Tokens.Add(player4Token13);
            listPlayer4Tokens.Add(player4Token14);
            listPlayer4Tokens.Add(player4Token15);
            listPlayer4Tokens.Add(player4Token16);
            listPlayer4Tokens.Add(player4Token17);
            listPlayer4Tokens.Add(player4Token18);
            listPlayer4Tokens.Add(player4Token19);
            listPlayer4Tokens.Add(player4Token20);
            listPlayer4Tokens.Add(player4Token21);
            listPlayer4Tokens.Add(player4Token22);
            listPlayer4Tokens.Add(player4Token23);
            listPlayer4Tokens.Add(player4Token24);
            listPlayer4Tokens.Add(player4Token25);
            listPlayer4Tokens.Add(player4Token26);
            listPlayer4Tokens.Add(player4Token27);
            listPlayer4Tokens.Add(player4Token28);
            listPlayer4Tokens.Add(player4Token29);
            listPlayer4Tokens.Add(player4Token30);
            listPlayer4Tokens.Add(player4Token31);
            listPlayer4Tokens.Add(player4Token32);
            listPlayer4Tokens.Add(player4Token33);
            listPlayer4Tokens.Add(player4Token34);
            listPlayer4Tokens.Add(player4Token35);
            listPlayer4Tokens.Add(player4Token36);
            listPlayer4Tokens.Add(player4Token37);
            listPlayer4Tokens.Add(player4Token38);
            listPlayer4Tokens.Add(player4Token39);

        }

        // support functions
        Point returnTokenPosition(Image playerToken)
        {
            GeneralTransform transform = playerToken.TransformToAncestor(this);
            Point rootPoint = transform.Transform(new Point(0, 0));
            return rootPoint;
        }

        void disableAllBtns(bool val)
        {
            btnBuild.IsEnabled = !val;
            btnSell.IsEnabled = !val;
            btnMortgage.IsEnabled = !val;
            btnUnmortgage.IsEnabled = !val;
            btnTrade.IsEnabled = !val;
            btnRollDices.IsEnabled = !val;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            MessageBox.Show(p.X.ToString() + " " + p.Y.ToString());
        }

        private void bindData()
        {
            switch (ctrlGame.clientGame.PlayerList.Count)
            {
                case 1:
                    txtPlayer1Money.Text = "$ " + ctrlGame.clientGame.PlayerList[0].PlayerMoney;
                    listPlayer1Tokens[0].Opacity = 1;
                    break;
                case 2:
                    txtPlayer1Money.Text = "$ " + ctrlGame.clientGame.PlayerList[0].PlayerMoney;
                    txtPlayer2Money.Text = "$ " + ctrlGame.clientGame.PlayerList[1].PlayerMoney;
                    listPlayer1Tokens[0].Opacity = 1;
                    listPlayer2Tokens[0].Opacity = 1;
                    break;
                case 3:
                    txtPlayer1Money.Text = "$ " + ctrlGame.clientGame.PlayerList[0].PlayerMoney;
                    txtPlayer2Money.Text = "$ " + ctrlGame.clientGame.PlayerList[1].PlayerMoney;
                    txtPlayer3Money.Text = "$ " + ctrlGame.clientGame.PlayerList[2].PlayerMoney;
                    
                    break;
                case 4:
                    txtPlayer1Money.Text = "$ " + ctrlGame.clientGame.PlayerList[0].PlayerMoney;
                    txtPlayer2Money.Text = "$ " + ctrlGame.clientGame.PlayerList[1].PlayerMoney;
                    txtPlayer3Money.Text = "$ " + ctrlGame.clientGame.PlayerList[2].PlayerMoney;
                    txtPlayer4Money.Text = "$ " + ctrlGame.clientGame.PlayerList[3].PlayerMoney;
                    
                    break;
            }
        }
        # endregion

        public void updateMoney()
        {
            txtPlayer1Money.Text = ctrlGame.clientGame.PlayerList[0].PlayerMoney.ToString();
            txtPlayer2Money.Text = ctrlGame.clientGame.PlayerList[1].PlayerMoney.ToString();
        }

        // event handlers
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            disableAllBtns(true);

            foreach (Image img in listPlayer1Tokens)
            {
                img.Opacity = 0;
            }
            foreach (Image img in listPlayer2Tokens)
            {
                img.Opacity = 0;
            }
            foreach (Image img in listPlayer3Tokens)
            {
                img.Opacity = 0;
            }
            foreach (Image img in listPlayer4Tokens)
            {
                img.Opacity = 0;
            }
            this.player1Token = new Presentation.tokenImgsManager(listPlayer1Tokens);
            this.player2Token = new Presentation.tokenImgsManager(listPlayer2Tokens);
            

            ctrlGame.clientGame = new clsGame();
            
            bindData();

            ctrlGame.clientGame.TurnOfPlayer = 1;
            btnEndTurn.IsEnabled = false;

            if (ctrlGame.thisPlayerID == ctrlGame.clientGame.TurnOfPlayer)
            {
                disableAllBtns(false);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {            
            UIManager.switchToMainMenu();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            grdMessage.Children.Clear();
            grdMessage.Children.Add(new UC_MainWindowMenu());
        }        

        private void btnBuild_Click(object sender, RoutedEventArgs e)
        {
            grdMessage.Children.Clear();
            // test them nha
            // landManager.buildHouseAt(15);

        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            grdMessage.Children.Clear();

            // test code
            // polygonsManager.setOwnerAt(15, 3);
        }

        private void btnMortgage_Click(object sender, RoutedEventArgs e)
        {
            grdMessage.Children.Clear();
        }

        private void btnUnmortgage_Click(object sender, RoutedEventArgs e)
        {
            grdMessage.Children.Clear();            
        }

        private void btnTrade_Click(object sender, RoutedEventArgs e)
        {
            grdMessage.Children.Clear();

            // test code
            // stoPlayer1.moveThisAmountOfSquares(15); 
        }

        private void btnRollDices_Click(object sender, RoutedEventArgs e)
        {
            dicesMan.rollDices();
            int val = dice1.Value + dice2.Value;
            //int val = 9;

            btnRollDices.IsEnabled = false;


            if (ctrlGame.clientGame.TurnOfPlayer == 1)
            {
                

                int showSquare = player1Token.currentDisplayed + val;

                if (showSquare > 39) showSquare -= 40;


                player1Token.setCurrentDisplay(showSquare);
                ctrlGame.clientGame.PlayerList[0].Position = showSquare;

                ctrlSquare squ = new ctrlSquare();
                ctrlGame.clientGame.PlayerList = squ.ActivateSquare(ctrlGame.clientGame.PlayerList, ctrlGame.clientGame.TurnOfPlayer, squ.getSquareById(showSquare.ToString()));
                showSquare = ctrlGame.clientGame.PlayerList[0].Position;
                //player1Token.setCurrentDisplay(showSquare);
                if (!listSquareKoHien.Contains(showSquare))
                {
                    this.grdMessage.Children.Clear();
                    this.grdMessage.Children.Add(new UC_LandInfo(showSquare, this));

                }
            }
            else
            {
                
                int showSquare = player2Token.currentDisplayed + val;

                if (showSquare > 39) showSquare -= 40;


                player2Token.setCurrentDisplay(showSquare);
                ctrlGame.clientGame.PlayerList[1].Position = showSquare;

                if (!listSquareKoHien.Contains(showSquare))
                {
                    this.grdMessage.Children.Clear();
                    this.grdMessage.Children.Add(new UC_LandInfo(showSquare, this));
                }
                    
            }

            btnEndTurn.IsEnabled = true;
        }

        private void btnEndTurn_Click(object sender, RoutedEventArgs e)
        {
            btnEndTurn.IsEnabled = false;
            if (ctrlGame.clientGame.TurnOfPlayer == 1)
            {
                ctrlGame.clientGame.TurnOfPlayer = 0;
                btnRollDices.IsEnabled = true;
            }
            else
            {
                ctrlGame.clientGame.TurnOfPlayer = 1;
                btnRollDices.IsEnabled = true;
            }
            this.grdMessage.Children.Clear();
        }

	}
}