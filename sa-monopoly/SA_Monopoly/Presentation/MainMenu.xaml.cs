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

using SA_Monopoly.Presentation;

namespace SA_Monopoly
{
	/// <summary>
	/// Interaction logic for MainMenu.xaml
	/// </summary>
	public partial class MainMenu : Window
	{
        public MainMenu()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
            UIManager.Init(this);
		}

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCreateNewGame_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            grdMain.Children.Add(new UC_CreateNewGame());
        }

        private void btnJoinGame_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            grdMain.Children.Add(new UC_JoinGame(this));
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.Clear();
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}