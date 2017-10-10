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
    
    public enum Ingredient
    {
        Steak,
        Kürbis
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation =  WindowStartupLocation.CenterScreen;
            FillLists();
        }

        private void FillLists()
        {
            Meat.Items.Add("Hühnchen");
            Meat.Items.Add("Rind");
            Meat.Items.Add("Schwein");
            Meat.Items.Add("Ente");
            Meat.Items.Add("Fisch");
            FirstSideDish.Items.Add("Nudeln");
            FirstSideDish.Items.Add("Reis");
            FirstSideDish.Items.Add("CousCous");
            FirstSideDish.Items.Add("Kartoffeln");
            FirstSideDish.Items.Add("Naan <3");
            SecondSideDish.Items.Add("Tomate");
            SecondSideDish.Items.Add("Gurke");
            SecondSideDish.Items.Add("Paprika");
            SecondSideDish.Items.Add("Zucchini");
            SecondSideDish.Items.Add("Zwiebeln");
            SecondSideDish.Items.Add("Lauch");
            FirstSideDish.Items.Add("Kürbis");
        }


        private void Meat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentIngredients.Items.Add(Meat.SelectedItem);
            CheckReceipts(Ingredient.Steak);
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
            if (ingredient == Ingredient.Kürbis)
            {
                Receipts.Items.Add("Kübissuppe");
                Receipts.Items.Add("Frittierte Kürbisstreifen");
                Receipts.Items.Add("Naan Tortillas mit Kürbis");
            }
            else
            {
                Receipts.Items.Add("Steak mit Pommes");
                Receipts.Items.Add("Gebackenes Steak mit Ofenkartoffeln");
                Receipts.Items.Add("Burger");
                Receipts.Items.Add("Spaghetti Bolognese");
            }
            if (CurrentIngredients.Items.Contains("Rind") && CurrentIngredients.Items.Contains("Kürbis"))
            {
                Receipts.Items.Clear();
                Receipts.Items.Add("Steak mit gebackenem Kürbis");
                Receipts.Items.Add("Hackbällchen mit Kürbisstreifen");
            }

        }

        private void FirstSideDish_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CurrentIngredients.Items.Add(FirstSideDish.SelectedItem);
            CheckReceipts(Ingredient.Kürbis);
        }

        private void Receipts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (Process.Start(@"http://www.chefkoch.de/rezepte/259781101566295/Kuerbissuppe-mit-Ingwer-und-Kokosmilch.html")) { }
        }
    }
}
