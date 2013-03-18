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
using System.Net;

using SA_Monopoly.BLL.Client;
using SA_Monopoly.BLL;
using System.ComponentModel;
using SA_Monopoly.Presentation;

namespace SA_Monopoly
{
	/// <summary>
	/// Interaction logic for UC_JoinGame.xaml
	/// </summary>
	public partial class UC_JoinGame : UserControl
	{
        ctrlGame clientGame = new ctrlGame();
        static BackgroundWorker _bw;

		public UC_JoinGame(Window parent)
		{
			this.InitializeComponent();            
            this.btnJoin.IsEnabled = false;
		}

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {

            clientGame.connectServer(this.txtIP.Text);
            ctrlGame.isConnect = true;
            btnJoin.IsEnabled = false;
            _bw = new BackgroundWorker();
            _bw.DoWork += listenToStart;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;

           

            _bw.RunWorkerAsync();
            if (ctrlGame.readData == "full")
            {
                clientGame.Disconnect();
                MessageBox.Show("The game you want to join has enough players! Please join another game", "Notice", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                btnJoin.IsEnabled = true;
            }
            
        }

        private void txtIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.btnJoin.IsEnabled = true;
            
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