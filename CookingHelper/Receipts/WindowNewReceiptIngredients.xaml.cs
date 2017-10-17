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
    /// Interaktionslogik für WindowNewReceiptIngredients.xaml
    /// </summary>
    public partial class WindowNewReceiptIngredients : Window
    {
        public WindowNewReceipt TempWindow { get; set; }
        

        public WindowNewReceiptIngredients(WindowNewReceipt windowNewReceipt)
        {
            InitializeComponent();
            FillIngredientTypes();
            TempWindow = windowNewReceipt;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ListBoxIngredientType.Focus();
            ListBoxIngredientType.SelectedIndex = 0;

        }

        private void ListBoxIngredientType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                GetIngredient();
            }
        }

        private void GetIngredient()
        {
            Dictionary<string, CookBook.IngredientType> tempDict = new Dictionary<string, CookBook.IngredientType>();
            tempDict.Add(TempWindow.TxtIngredientName.Text, GetIngredient(ListBoxIngredientType.SelectedItem.ToString()));
            TempWindow.TempIngredients.Add(tempDict);
            TempWindow.ListBoxIngredients.Items.Add(TempWindow.TxtIngredientName.Text);
            TempWindow.TxtIngredientName.Clear();
            this.Close();
        }

        private CookBook.IngredientType GetIngredient(string ingredientName)
        {
            switch (ingredientName)
            {
                case "Meat":
                return CookBook.IngredientType.Meat;
                case "Vegetable":
                    return CookBook.IngredientType.Vegetable;
                case "Fruit":
                    return CookBook.IngredientType.Fruit;
                case "Other":
                    return CookBook.IngredientType.Other;
                default:
                    return CookBook.IngredientType.Meat;
            }
        }

        private void FillIngredientTypes()
        {
            ListBoxIngredientType.Items.Add("Meat");
            ListBoxIngredientType.Items.Add("Vegetable");
            ListBoxIngredientType.Items.Add("Fruit");
            ListBoxIngredientType.Items.Add("Other");
            ListBoxIngredientType.SelectedIndex = 1;
        }

        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CmdChoose_Click(object sender, RoutedEventArgs e)
        {
            GetIngredient();
        }

        private void ListBoxIngredientType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GetIngredient();
        }
    }
}
