using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ice_Cream_Shop
{
    internal class Bank
    {
        private double balance;

        public Bank (double balance)
        {
            this.balance = balance;
        }

        public double Pay(double clientAmount, double cost)
        {
            if (clientAmount < cost)
            {
                Console.WriteLine($"You don't have enough money! {clientAmount} is lower than the cost {cost}");
                return clientAmount;
            }
            else if (clientAmount > cost)
            {
               return GetChange(clientAmount, cost);
            }
            else
            {
                balance += cost;
                return 0;
            }
        }
        private double GetChange(double clientAmount, double cost)
        {
            double change = clientAmount - cost;
            balance += clientAmount - change;
            return change;
        }

    }
}
