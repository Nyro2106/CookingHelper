using CookingHelper.Ingredients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookingHelper
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>

    //public enum Ingredient
    //{
    //    Steak,
    //    Kürbis
    //}
    public partial class MainWindow : Window
    {
        List<Receipt> ReceiptList = new List<Receipt>();


        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;



            FillIngredients();
        }

        private void FillIngredients()
        {
            Receipt.GetReceipts(ReceiptList);
            Receipt.FillLists(ReceiptList, Meat, Vegetables, Fruit, Other);
        }

        private void AddIngredient(ListBox ingredientList)
        {
            if (CurrentIngredients.Items.Contains(ingredientList.SelectedItem))
            {
                return;
            }
            else
            {
                CurrentIngredients.Items.Add(ingredientList.SelectedItem);
                CheckReceipts();
            }
        }

        private void Meat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Meat.Items.Count == 0)
            {
                return;
            }
            AddIngredient(Meat);
        }

        private void Vegetables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Vegetables.Items.Count == 0)
            {
                return;
            }
            AddIngredient(Vegetables);
        }

        private void Fruit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Fruit.Items.Count == 0)
            {
                return;
            }
            AddIngredient(Fruit);
        }

        private void Other_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Other.Items.Count == 0)
            {
                return;
            }
            AddIngredient(Other);
        }

        private void CurrentIngredients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrentIngredients.Items.Count == 0)
            {
                return;
            }
            CurrentIngredients.Items.Remove(CurrentIngredients.SelectedItem);
            CheckReceipts();
        }

        private void CheckReceipts()
        {
            Receipts.Items.Clear();
            if (CurrentIngredients.Items.Count == 0)
            {
                Receipts.Items.Clear();
                return;
            }
            Receipt.CheckForReceipts(ReceiptList, Receipts, CurrentIngredients);
        }

        private void Receipts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Receipts.Items.Count == 0)
            {
                return;
            }
            try
            {
                Receipt.Open(ReceiptList, Receipts.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void IngredientsMenuItemRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            CurrentIngredients.Items.Clear();
            CheckReceipts();
        }

        private void HeaderOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionWindow window = new OptionWindow(Config.DatabasePath);
            window.Show();
        }

        private void HeaderNewReceipt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
