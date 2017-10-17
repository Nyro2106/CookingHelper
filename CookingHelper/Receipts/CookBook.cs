using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CookingHelper
{
    class CookBook
    {
        internal enum IngredientType
        {
            Meat, Vegetable, Fruit, Other
        };

        internal static List<Receipt> GetReceipts(List<Receipt> receipts)
        {
            string[] receiptPaths = Directory.GetFiles($@"{Config.DatabasePath}\Receipts");
            string[] ingredients;
            Dictionary<string, IngredientType> tempDict = new Dictionary<string, IngredientType>();
            List<Dictionary<string, IngredientType>> tempList = new List<Dictionary<string, IngredientType>>();
            string line;
            string name;
            foreach (var receiptPath in receiptPaths)
            {
                name = receiptPath.Replace(".txt", "");
                name = name.Replace($@"{Config.DatabasePath}\Receipts\", "");
                using (StreamReader reader = new StreamReader($"{receiptPath}"))
                {
                    while ((line = reader.ReadLine()) != string.Empty)
                    {
                        ingredients = line.Split('=');
                        tempDict.Add(ingredients[0], GetIngredientType(ingredients[1]));
                        tempList.Add(tempDict);
                    }
                    receipts.Add(new Receipt($"{name}", tempList));
                    tempDict = new Dictionary<string, IngredientType>();
                    tempList = new List<Dictionary<string, IngredientType>>();
                }
            }
            return receipts;
        }

        internal static void CreateNewReceipt(string receiptName, string receiptText, List<Dictionary<string, CookBook.IngredientType>> ingredients)
        {
            string[] receiptPaths = Directory.GetFiles($@"{Config.DatabasePath}\Receipts");
            using (StreamWriter writer = new StreamWriter($@"{Config.DatabasePath}\Receipts\{receiptName}.txt"))
            {
                foreach (var ingredient in ingredients)
                {
                    foreach (var ingredientKey in ingredient)
                    {
                        writer.WriteLine($"{ingredientKey.Key}={ingredientKey.Value}");
                    }
                }
                writer.WriteLine($"\n{receiptText}");
            }
        }

        private static IngredientType GetIngredientType(string type)
        {
            switch (type)
            {
                case "Meat":
                    return IngredientType.Meat;
                case "Vegetable":
                    return IngredientType.Vegetable;
                case "Fruit":
                    return IngredientType.Fruit;
                case "Other":
                    return IngredientType.Other;
                default:
                    return IngredientType.Other;
            }
        }

        internal static void FillLists(List<Receipt> receiptList, ListBox meat, ListBox vegetables, ListBox fruit, ListBox other)
        {
            List<string> templistMeat = new List<string>();
            List<string> templistVeg = new List<string>();
            List<string> templistFruit = new List<string>();
            List<string> templistOther = new List<string>();

            foreach (var receipt in receiptList)
            {
                foreach (var ingredient in receipt.Ingredients)
                {
                    foreach (var ingredientDictionaryEntry in ingredient)
                    {
                        switch (ingredientDictionaryEntry.Value)
                        {
                            case IngredientType.Meat:
                                GetIngredients(templistMeat, receipt.Ingredients, IngredientType.Meat);
                                break;
                            case IngredientType.Vegetable:
                                GetIngredients(templistVeg, receipt.Ingredients, IngredientType.Vegetable);
                                break;
                            case IngredientType.Fruit:
                                GetIngredients(templistFruit, receipt.Ingredients, IngredientType.Fruit);
                                break;
                            case IngredientType.Other:
                                GetIngredients(templistOther, receipt.Ingredients, IngredientType.Other);
                                break;
                            default:
                                GetIngredients(templistOther, receipt.Ingredients, IngredientType.Other);
                                break;
                        }
                    }
                }

            }
            templistMeat.Sort();
            templistVeg.Sort();
            templistFruit.Sort();
            templistOther.Sort();
            AddList(templistMeat, meat);
            AddList(templistVeg, vegetables);
            AddList(templistFruit, fruit);
            AddList(templistOther, other);
        }

        private static void AddList(List<string> tempList, ListBox list)
        {
            foreach (var item in tempList)
            {
                list.Items.Add(item);
            }
        }

        private static void GetIngredients(List<string> ingredientList, List<Dictionary<string, IngredientType>> ingredients, IngredientType Type)
        {
            foreach (var item in ingredients)
            {
                foreach (var ingredient in item)
                {
                    if ((!ingredientList.Contains(ingredient.Key) && ingredient.Value == Type))
                    {
                        ingredientList.Add(ingredient.Key);
                    }
                }

            }
        }

        internal static void Open(string receiptName)
        {
            try
            {
                using (Process.Start($@"{Config.DatabasePath}\Receipts\{receiptName}.txt")) { }
            }
            catch (Exception ex)
            {
                throw new Exception($"Rezept nicht gefunden. {ex.Message}.");
            }
        }


        internal static void CheckForReceipts(List<Receipt> receiptList, ListBox receipts, ListBox currentIngredients)
        {
            foreach (var ingredient in currentIngredients.Items)
            {
                foreach (var receipt in receiptList)
                {
                    foreach (var receiptIngredient in receipt.Ingredients)
                    {
                        if (receiptIngredient.ContainsKey(ingredient.ToString()))
                        {
                            foreach (var ingredientDictionaryEntry in receiptIngredient)
                            {
                                if (ingredientDictionaryEntry.Key == ingredient.ToString() && !(receipts.Items.Contains(receipt.Name)))
                                {
                                    receipts.Items.Add(receipt.Name);
                                }
                            }
                        }


                    }
                }
            }
        }
    }
}
