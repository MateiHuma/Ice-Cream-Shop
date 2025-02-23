using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Cream_Shop
{
    public class IngredientPriceAttribute : Attribute
    {
        public int Price { get; }
        public bool IsPercentage { get; }
        public int Percentage { get; }

        public IngredientPriceAttribute(int price, bool isPercentage, int percentage)
        {
            Price = price;
            IsPercentage = isPercentage;
            Percentage = percentage;
        }
    }

    public enum Ingredient
    {
        [IngredientPrice(5, false, 0)]
        Vanilla,

        [IngredientPrice(3, false, 0)]
        Chocolate,

        [IngredientPrice(2, false, 0)]
        Cone,

        [IngredientPrice(4, false, 0)]
        DarkChocolate,

        [IngredientPrice(4, true, 5)]
        BelgianChocolate,

        [IngredientPrice(2, false, 0)]
        Strawberry,

        [IngredientPrice(0, true, 10)]
        Bowl,

        [IngredientPrice(2, true, 5)]
        SparklyTopping

    }


}
