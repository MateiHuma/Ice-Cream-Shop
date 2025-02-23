using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Cream_Shop
{
    internal class Basket
    {
        private double totalCost;
        private double percentage;
        private List<Ingredient> ingredients;

        public Basket ()
        {
            this.totalCost = 0;
            this.percentage = 0;
            this.ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            this.ingredients.Add(ingredient);
            this.totalCost += IngredientHelper.GetPrice(ingredient);
            if (IngredientHelper.IsPercentage(ingredient))
            {
                this.percentage += IngredientHelper.GetPercentage(ingredient);
            }

            Console.WriteLine($"Current price: {totalCost}. Current precentage that will be added to the total cost: {percentage}");
        }

        public void PrintIngredientsFromBasket()
        {
            Console.WriteLine("Your icecream contains the following ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient}");
            }
        } 

        public double GetTotalCost ()
        {
            totalCost += totalCost * (percentage / 100); 
            return totalCost;
        }
    }
}
