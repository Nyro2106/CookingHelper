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
    class Receipt
    {
        internal enum IngredientListType
        {
            Meat, Vegetable, Fruit, Other
        }

        internal string Path { get => $@"{Config.DatabasePath}\Receipts\{Name}.txt"; }
        internal string Name { get; set; } = "";
        internal List<Dictionary<string, IngredientListType>> Ingredients { get; set; }


        internal Receipt(string name, List<Dictionary<string, IngredientListType>> ingredients)
        {
            this.Name = name;
            this.Ingredients = ingredients;
        }

        private static IngredientListType GetIngredientType(string type)
        {
            switch (type)
            {
                case "Meat":
                    return IngredientListType.Meat;
                case "Vegetable":
                    return IngredientListType.Vegetable;
                case "Fruit":
                    return IngredientListType.Fruit;
                case "Other":
                    return IngredientListType.Other;
                default:
                    return IngredientListType.Other;
            }
        }


        internal static void GetReceipts(List<Receipt> receiptList)
        {
            string[] receiptPaths = Directory.GetFiles($@"{Config.DatabasePath}\Receipts");
            string[] ingredients;
            Dictionary<string, IngredientListType> tempDict = new Dictionary<string, IngredientListType>();
            List<Dictionary<string, IngredientListType>> tempList = new List<Dictionary<string, IngredientListType>>();
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
                    receiptList.Add(new Receipt($"{name}", tempList));
                    tempDict = new Dictionary<string, IngredientListType>();
                    tempList = new List<Dictionary<string, IngredientListType>>();
                }

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
                foreach (var receiptName in receipt.Ingredients)
                {
                    foreach (var ingredientType in receiptName)
                    {
                        switch (ingredientType.Value)
                        {
                            case IngredientListType.Meat:
                                GetIngredients(templistMeat, receipt.Ingredients, IngredientListType.Meat);
                                break;
                            case IngredientListType.Vegetable:
                                GetIngredients(templistVeg, receipt.Ingredients, IngredientListType.Vegetable);
                                break;
                            case IngredientListType.Fruit:
                                GetIngredients(templistFruit, receipt.Ingredients, IngredientListType.Fruit);
                                break;
                            case IngredientListType.Other:
                                GetIngredients(templistOther, receipt.Ingredients, IngredientListType.Other);
                                break;
                            default:
                                GetIngredients(templistOther, receipt.Ingredients, IngredientListType.Other);
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

        private static void GetIngredients(List<string> ingredientList, List<Dictionary<string, IngredientListType>> ingredients, IngredientListType Type)
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

        internal static void Open(List<Receipt> receipts, string name)
        {
            try
            {

                string path = receipts.Where(receipt => receipt.Name == name).FirstOrDefault().Path;
                using (Process.Start($@"{path}")) { }
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
                            foreach (var ingredientDictionary in receiptIngredient)
                            {
                                if (ingredientDictionary.Key == ingredient.ToString() && !(receipts.Items.Contains(receipt.Name)))
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
