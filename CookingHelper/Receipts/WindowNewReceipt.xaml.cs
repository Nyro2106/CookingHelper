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
        public MainWindow TempWindow { get; set; }
        internal List<Dictionary<string, CookBook.IngredientType>> TempIngredients = new List<Dictionary<string, CookBook.IngredientType>>();

        public WindowNewReceipt(MainWindow tempWindow)
        {
            InitializeComponent();

            this.TempWindow = tempWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            if (TxtReceiptName.Text != string.Empty)
            {
                TextRange range = new TextRange(RichTextReceiptContent.Document.ContentStart, RichTextReceiptContent.Document.ContentEnd);
                string receiptContent = range.Text;

                CookBook.CreateNewReceipt(TxtReceiptName.Text, receiptContent, TempIngredients);
                TempWindow.FillIngredients();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Bitte Rezeptnamen eingeben!");
            }
        }

        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtIngredientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && TxtIngredientName.Text != string.Empty)
            {
                WindowNewReceiptIngredients window = new WindowNewReceiptIngredients(this);
                window.Show();
            }
        }

        private void ImageAddIngredient_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TxtIngredientName.Text != string.Empty)
            {
                WindowNewReceiptIngredients window = new WindowNewReceiptIngredients(this);
                window.Show(); 
            }
        }
    }
}
