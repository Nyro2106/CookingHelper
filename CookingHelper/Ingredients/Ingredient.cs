using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CookingHelper.Ingredients
{

    class Ingredient
    {
        public string Name { get; set; }

        public Ingredient(string name)
        {
            this.Name = name;
        }

        public static void Load(string path, ListBox listBox, out List<Ingredient> ingredients)
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
                tempListAdvanced.Add(new Ingredient(name));
            }
            ingredients = tempListAdvanced;
            foreach (var ingredient in tempListAdvanced)
            {
                listBox.Items.Add(ingredient.Name);
            }
        }


    }
}
