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
    class Receipt : CookBook
    {
        internal string Path { get => $@"{Config.DatabasePath}\Receipts\{Name}.txt"; }
        internal string Name { get; set; } = "";
        internal List<Dictionary<string, IngredientType>> Ingredients { get; set; }


        internal Receipt(string name, List<Dictionary<string, IngredientType>> ingredients)
        {
            this.Name = name;
            this.Ingredients = ingredients;
        }
    }
}
