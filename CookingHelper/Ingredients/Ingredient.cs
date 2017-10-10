using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CookingHelper.Ingredients
{
    enum Type
    {
        Meat, Vegetable, Fruit, Other
    }
    class Ingredient
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Type Type { get; set; }

        public Ingredient(string name, Type type)
        {
            this.Name = name;
            this.Type = type;
        }

        public static void Load(string path, ListBox listBox, out List<Ingredient> ingredients, Type ingredientType)
        {
            List<string> tempList = new List<string>();
            List<Ingredient> tempListAdvanced = new List<Ingredient>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    tempList.Add(line);
                }
            }
            tempList.Sort();
            foreach (var name in tempList)
            {
                tempListAdvanced.Add(new Ingredient(name, ingredientType));
            }
            ingredients = tempListAdvanced;
            foreach (var ingredient in tempListAdvanced)
            {
                listBox.Items.Add(ingredient.Name);
            }
        }
    }
}
