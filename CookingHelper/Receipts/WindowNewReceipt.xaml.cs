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
    /// Interaktionslogik für WindowNewReceipt.xaml
    /// </summary>
    public partial class WindowNewReceipt : Window
    {
        public WindowNewReceipt()
        {
            InitializeComponent();
            FillIngredientTypes();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void FillIngredientTypes()
        {
            ComboBoxIngredientType.Items.Add("Meat");
            ComboBoxIngredientType.Items.Add("Vegetable");
            ComboBoxIngredientType.Items.Add("Fruit");
            ComboBoxIngredientType.Items.Add("Other");
            ComboBoxIngredientType.SelectedIndex = 0;
        }

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            //Save
        }

        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
