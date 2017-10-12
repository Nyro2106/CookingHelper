using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHelper
{
    class Config
    {
        static public string DatabasePath { get; set; } = @"E:\Git\CookingData";
        static public string ReceiptPath { get; set; } = $@"{DatabasePath}\Receipts\";
        static public string MeatPath { get; set; } = $@"{DatabasePath}\Ingredients\Meat.txt";
        static public string VegetablePath { get; set; } = $@"{DatabasePath}\Ingredients\Vegetables.txt";
        static public string FruitPath { get; set; } = $@"{DatabasePath}\Ingredients\Fruits.txt";
        static public string OtherPath { get; set; } = $@"{DatabasePath}\Ingredients\Other.txt";

        public static void ChangeDatabasePath(string newPath)
        {
            ///TODO
            ///Laden/Speichern implementieren
            ///
            DatabasePath = newPath;
        }

        
    }
}
