using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Cream_Shop
{
    internal class IceCreamMachine
    {
        private Bank bank;

        public IceCreamMachine(Bank bank)
        {
            this.bank = bank;
        }

        public void Start ()
        {
            Basket basket = new Basket();
            string ingredient;


            Console.WriteLine("Please choose the desired ingridients: \n");
            Console.WriteLine("Type Checkout to finish the order.\n");
            IngredientHelper.PrintIngredients();

            while (true)
            {
                ingredient = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    Console.Write("Please insert a corect ingredient or checkout: ");
                    IngredientHelper.PrintIngredients();
                    continue;
                }

                if (ingredient.Equals("checkout", StringComparison.OrdinalIgnoreCase))
                {
                    double totalCost = basket.GetTotalCost();
                    Console.WriteLine($"The price of your icecream is: {totalCost}");
                    double clientMoney = GetClientMoney();
                    double change = bank.Pay(clientMoney, totalCost);
                    basket.PrintIngredientsFromBasket();
                    Console.WriteLine($"Your change is {change}");
                    break;
                }

                try
                {
                    Ingredient desiredIngredient = IngredientHelper.GetIngredientAfterName(ingredient);
                    basket.AddIngredient(desiredIngredient);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    IngredientHelper.PrintIngredients();
                }
                
            }
        }

        public double GetClientMoney()
        {
            string input;
            Console.WriteLine("Insert money:");
            input = Console.ReadLine();
            double money = double.Parse(input);
            return money;
        }
    }
}
