using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.Presentation
{
    static class UIManager
    {
        static MainMenu mainMenu;
        static MainWindow mainWindow;

        static public void Init(MainMenu mm)
        {
            mainMenu = mm;
            makeNewMainWindow();
        }

        static public void makeNewMainWindow()
        {
            mainWindow = new MainWindow();
        }

        static public void switchToMainMenu()
        {
            mainWindow.Close();
            mainMenu.Show();
        }

        static public void switchToMainWindow()
        {
            makeNewMainWindow();
            mainMenu.Hide();
            mainWindow.Show();
        }
    }
}
