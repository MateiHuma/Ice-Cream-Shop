using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Cream_Shop
{
    public static class IngredientHelper
    {
        public static int GetPrice(this Ingredient ingredient)
        {
            FieldInfo field = ingredient.GetType().GetField(ingredient.ToString());
            return field.GetCustomAttribute<IngredientPriceAttribute>().Price;
        }

        public static bool IsPercentage(this Ingredient ingredient)
        {
            FieldInfo field = ingredient.GetType().GetField(ingredient.ToString());
            return field.GetCustomAttribute<IngredientPriceAttribute>().IsPercentage;
        }

        public static int GetPercentage(this Ingredient ingredient)
        {
            FieldInfo field = ingredient.GetType().GetField(ingredient.ToString());
            return field.GetCustomAttribute<IngredientPriceAttribute>().Percentage;
        }

        public static void PrintIngredients()
        {
            foreach (Ingredient ingredient in Enum.GetValues(typeof(Ingredient)))
            {
                int price = ingredient.GetPrice();
                bool isPercentage = ingredient.IsPercentage();
                int percentage = ingredient.GetPercentage();

                Console.Write($"{ingredient}: ");
                Console.Write($"Price = {price}");
                if (isPercentage)
                {
                    Console.Write($", Price Increase = {percentage}%");
                }
                Console.WriteLine();
            }
        }

        public static Ingredient GetIngredientAfterName(string ingredientName)
        {
            if (Enum.TryParse<Ingredient>(ingredientName, true, out Ingredient ingredient))
            {
                return ingredient;
            }
            throw new ArgumentException($"Ingredient '{ingredientName}' does not exist.", nameof(ingredientName));
        }

    }
}
