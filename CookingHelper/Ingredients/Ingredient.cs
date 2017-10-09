using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHelper.Ingredients
{
    enum Type
    {
        Chicken, Pig, Beef, Fish
    }
    class Ingredient
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Type Type { get; set; }

    }
}
