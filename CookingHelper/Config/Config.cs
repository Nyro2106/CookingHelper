using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingHelper
{
    class Config
    {
        static public string MeatPath { get; set; } = @"E:\Git\CookingData\Ingredients\Meat.txt";
        static public string VegetablePath { get; set; } = @"E:\Git\CookingData\Ingredients\Vegetables.txt";
        static public string FruitPath { get; set; } = @"E:\Git\CookingData\Ingredients\Fruits.txt";
        static public string OtherPath { get; set; } = @"E:\Git\CookingData\Ingredients\Other.txt";
    }
}
