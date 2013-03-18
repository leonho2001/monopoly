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
using System.Windows.Media.Animation;
using System.Threading;
using System.Net;

using SA_Monopoly.Presentation;
using SA_Monopoly.BLL.Server;
using SA_Monopoly.BLL.Client;
using SA_Monopoly.BLL;
using System.ComponentModel;

namespace SA_Monopoly
{
	/// <summary>
	/// Interaction logic for UC_CreateNewGame.xaml
	/// </summary>
	public partial class UC_CreateNewGame : UserControl
	{
        static BackgroundWorker _bw;
        Thread tid1;
        Server ser = new Server();
        ctrlGame game = new ctrlGame();
        LinearGradientBrush lgb = new LinearGradientBrush(Colors.LawnGreen, Colors.GreenYellow, new Point(0, 0), new Point(1, 1));
        LinearGradientBrush ulgb = new LinearGradientBrush(Colors.White, Colors.White, new Point(0, 0), new Point(1, 1));
        
        public UC_CreateNewGame()
		{
			this.InitializeComponent();
            this.btnStartGame.IsEnabled = false;

		}

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            game.sendMessToServer("ALL_start");
            Server.isBegin = true;
        }

        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        { 
            //Start the server
            Server.Done = false;
            ser = new Server();
            tid1 = new Thread(new ThreadStart(ser.StartServer));
            tid1.Start();

            _bw = new BackgroundWorker();
            _bw.DoWork += listenToStart;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            _bw.RunWorkerAsync();

            //Local machine connect to server
            game.connectServer(Support.GetLocalIP());
            ctrlGame.isConnect = true;
            

            //disable the Start button and fill the slot with filled mode
            btnStartServer.IsEnabled = false;
            btnStartServer.Content = "Server Started!";
            fillSlot(lgb);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (ctrlGame.isConnect == true)
            {
                //Dispose the Server Thread

                Server.playerCount = -1;
                tid1.Abort();
                ser.StopServer();
                //game.Disconnect();

                //Enable the Start button and fill the slot in empty mode
                btnStartServer.IsEnabled = true;
                btnStartServer.Content = "Start Server";
                fillSlot(ulgb);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            
            if (Server.playerCount != -1)
            {
                fillSlot(lgb);
                btnStartGame.IsEnabled = true;
            }

        }

        private void fillSlot(LinearGradientBrush lgb)
        {
            switch (Server.playerCount)
            {
                case 0:
                    txtSlot1.Foreground = lgb; break;
                case 1:
                    txtSlot1.Foreground = lgb;
                    txtSlot2.Foreground = lgb; break;
                case 2:
                    txtSlot1.Foreground = lgb;
                    txtSlot2.Foreground = lgb;
                    txtSlot3.Foreground = lgb; break;
                case 3:
                    txtSlot1.Foreground = lgb;
                    txtSlot2.Foreground = lgb;
                    txtSlot3.Foreground = lgb;
                    txtSlot4.Foreground = lgb; break;
                default:
                    txtSlot1.Foreground = lgb;
                    txtSlot2.Foreground = lgb;
                    txtSlot3.Foreground = lgb;
                    txtSlot4.Foreground = lgb; break;
            }

        }

        private void listenToStart(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (ctrlGame.readCommand == "start")
                {
                    break;
                }
            }
        }

        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                UIManager.switchToMainWindow(); 
        }
	}
}