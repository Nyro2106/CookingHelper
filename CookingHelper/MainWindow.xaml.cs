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
        List<Receipt> receiptList = new List<Receipt>();
        bool isFirstStart = Config.IsFirstStart();


        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoadConfig(isFirstStart);

            FillIngredients();
        }

        private void LoadConfig(bool isFirstStart)
        {
            if (isFirstStart)
            {
                Config.CreateConfigFolder();
                Config.Save();
                MessageBox.Show($"Konfiguration wurde unter {Config.ConfigPath} gespeichert");
            }
            else
            {
                Config.Load(Config.ConfigPath);
            }
        }

        internal void ClearListBoxes()
        {
            foreach (var child in MainGrid.Children)
            {
                if (child is ListBox listBox)
                {
                    listBox.Items.Clear();
                }
            }
        }

        internal void FillIngredients()
        {
            ClearListBoxes();
            try
            {
                CookBook.GetReceipts(receiptList);
                CookBook.FillLists(receiptList, ListMeat, ListVegetables, ListFruit, ListOther);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konnte Rezepte nicht laden, bitte Datenbank-Pfad in den Optionen überprüfen. {ex.Message}");
                ClearListBoxes();
            }
        }

        private void AddIngredient(ListBox ingredientList)
        {
            if (ListCurrentIngredients.Items.Contains(ingredientList.SelectedItem))
            {
                return;
            }
            else
            {
                ListCurrentIngredients.Items.Add(ingredientList.SelectedItem);
                CheckReceipts();
            }
        }

        private void Meat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListMeat.Items.Count == 0)
            {
                return;
            }
            AddIngredient(ListMeat);
        }

        private void Vegetables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListVegetables.Items.Count == 0)
            {
                return;
            }
            AddIngredient(ListVegetables);
        }

        private void Fruit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListFruit.Items.Count == 0)
            {
                return;
            }
            AddIngredient(ListFruit);
        }

        private void Other_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListOther.Items.Count == 0)
            {
                return;
            }
            AddIngredient(ListOther);
        }

        private void CurrentIngredients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListCurrentIngredients.Items.Count == 0)
            {
                return;
            }
            ListCurrentIngredients.Items.Remove(ListCurrentIngredients.SelectedItem);
            CheckReceipts();
        }

        private void CheckReceipts()
        {
            ListReceipts.Items.Clear();
            if (ListCurrentIngredients.Items.Count == 0)
            {
                ListReceipts.Items.Clear();
                return;
            }
            CookBook.CheckForReceipts(receiptList, ListReceipts, ListCurrentIngredients);
        }

        private void Receipts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListReceipts.Items.Count == 0)
            {
                return;
            }
            try
            {
                CookBook.Open(ListReceipts.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void IngredientsMenuItemRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            ListCurrentIngredients.Items.Clear();
            CheckReceipts();
        }

        private void HeaderOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionWindow window = new OptionWindow(Config.DatabasePath, this);
            window.Show();
        }

        private void HeaderNewReceipt_Click(object sender, RoutedEventArgs e)
        {
            WindowNewReceipt window = new WindowNewReceipt(this);
            window.Show();
        }
    }
}
