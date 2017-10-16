using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CookingHelper
{
    /// <summary>
    /// Interaktionslogik für OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        public MainWindow TempWindow { get; set; }

        public OptionWindow(string databasePath, MainWindow mainWindow)
        {
            InitializeComponent();
            TxtPathToDatabase.Text = databasePath;
            TempWindow = mainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            Config.ChangeDatabasePath(TxtPathToDatabase.Text);
            TempWindow.FillIngredients();
            this.Close();
        }

        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtPathToDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                Config.ChangeDatabasePath(TxtPathToDatabase.Text);
                this.Close();
            }
        }

        
        private void OpenFileDialogeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Bitte Datenbankdatei auswählen"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                TxtPathToDatabase.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }
        }
    }
}
