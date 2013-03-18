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

using SA_Monopoly.Presentation;

namespace SA_Monopoly
{
	/// <summary>
	/// Interaction logic for UC_MainWindowMenu.xaml
	/// </summary>
	public partial class UC_MainWindowMenu : UserControl
	{
		public UC_MainWindowMenu()
		{
			this.InitializeComponent();            
		}

        private void btnExitGame_Click(object sender, RoutedEventArgs e)
        {
            UIManager.switchToMainMenu();
        }

        
        
	}
}