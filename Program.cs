using Ice_Cream_Shop;
using System;
using System.Reflection;


class Program
{
    static void Main(string[] args)
    {
        IceCreamMachine iceCreamMachine = new IceCreamMachine(new Bank(50));
        iceCreamMachine.Start();
    }

}
