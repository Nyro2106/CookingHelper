using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CookingHelper
{

    class Config
    {

        static public string DatabasePath { get; set; } = @"D:\Visual Studio 2017\Projects\CookingHelper\CookingDataa";
        static public string ConfigPath { get; set; } = $@"C:\users\{Environment.UserName}\documents\Cooking Helper\cookinghelperconfig.bin";
        static public string ReceiptPath { get; set; } = $@"{DatabasePath}\Receipts\";
        static public string MeatPath { get; set; } = $@"{DatabasePath}\Ingredients\Meat.txt";
        static public string VegetablePath { get; set; } = $@"{DatabasePath}\Ingredients\Vegetables.txt";
        static public string FruitPath { get; set; } = $@"{DatabasePath}\Ingredients\Fruits.txt";

        internal static bool IsFirstStart()
        {
            if (File.Exists(ConfigPath))
            {
                return false;
            }
            return true;
        }

        static public string OtherPath { get; set; } = $@"{DatabasePath}\Ingredients\Other.txt";

        internal static void CreateConfigFolder()
        {
            Directory.CreateDirectory($@"C:\users\{Environment.UserName}\documents\Cooking Helper");
        }

        public static void ChangeDatabasePath(string newPath)
        {
            DatabasePath = newPath;
            Save();
        }

        public static void Save()
        {
            using (Stream stream = new FileStream(ConfigPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, DatabasePath);
            }
        }

        public static void Load(string databasePath)
        {
            using (Stream stream = new FileStream(ConfigPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                IFormatter formatter = new BinaryFormatter();
                DatabasePath = (string)formatter.Deserialize(stream);
            }
        }
    }
}
