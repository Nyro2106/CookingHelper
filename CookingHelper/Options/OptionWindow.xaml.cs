using System;
using System.Collections.Generic;
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
        public OptionWindow(string databasePath)
        {
            InitializeComponent();
            txtPathToDatabase.Text = databasePath;
        }

        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            Config.ChangeDatabasePath(txtPathToDatabase.Text);
            this.Close();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtPathToDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            else
            {
                Config.ChangeDatabasePath(txtPathToDatabase.Text);
                this.Close();
            }
        }
    }
}
