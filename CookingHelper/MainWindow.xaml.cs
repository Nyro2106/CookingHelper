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
        List<Ingredient> meat = new List<Ingredient>();
        List<Ingredient> vegetables = new List<Ingredient>();
        List<Ingredient> fruit = new List<Ingredient>();
        List<Ingredient> other = new List<Ingredient>();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation =  WindowStartupLocation.CenterScreen;
            FillLists();
        }

        private void FillLists()
        {
            Ingredient.Load(Config.MeatPath, Meat, out meat, Ingredients.Type.Meat);
            Ingredient.Load(Config.VegetablePath, Vegetables, out vegetables, Ingredients.Type.Vegetable);
            Ingredient.Load(Config.FruitPath, Fruit, out fruit, Ingredients.Type.Fruit);
            Ingredient.Load(Config.OtherPath, Other, out other, Ingredients.Type.Other);
        }


        private void Meat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentIngredients.Items.Add(Meat.SelectedItem);
            //CheckReceipts(Ingredient.Steak);
        }

        private void CurrentIngredients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentIngredients.Items.Remove(CurrentIngredients.SelectedItem);
            CheckReceipts();
        }

        private void CheckReceipts()
        {
            Receipts.Items.Clear();
        }

        private void CheckReceipts(Ingredient ingredient, string[] ingredients = null)
        {
            //if (ingredient == Ingredient.Kürbis)
            //{
            //    Receipts.Items.Add("Kübissuppe");
            //    Receipts.Items.Add("Frittierte Kürbisstreifen");
            //    Receipts.Items.Add("Naan Tortillas mit Kürbis");
            //}
            //else
            //{
            //    Receipts.Items.Add("Steak mit Pommes");
            //    Receipts.Items.Add("Gebackenes Steak mit Ofenkartoffeln");
            //    Receipts.Items.Add("Burger");
            //    Receipts.Items.Add("Spaghetti Bolognese");
            //}
            //if (CurrentIngredients.Items.Contains("Rind") && CurrentIngredients.Items.Contains("Kürbis"))
            //{
            //    Receipts.Items.Clear();
            //    Receipts.Items.Add("Steak mit gebackenem Kürbis");
            //    Receipts.Items.Add("Hackbällchen mit Kürbisstreifen");
            //}

        }

        private void Vegetables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentIngredients.Items.Add(Vegetables.SelectedItem);
            //CheckReceipts(Ingredient.Kürbis);
        }

        private void Receipts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (Process.Start($@"")) { }
        }
    }
}
