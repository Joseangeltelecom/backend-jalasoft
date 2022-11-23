using System;
using System.Collections.Generic;

namespace FilterExtensionMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = new List<int>();
            listNumbers.Add(1);
            listNumbers.Add(2);
            listNumbers.Add(3);
            listNumbers.Add(4);

            // testing with a list of numbers:
            var MoreThan2 = listNumbers.Filter1(n => n > 2);
            MoreThan2.PrintPrimitive();


            List<string> listNames = new List<string>();
            listNames.Add("Ana");
            listNames.Add("Pedro");
            listNames.Add("Maria");
            listNames.Add("Jose");
            // testing with a list of string names:
            var FindJose = listNames.Filter1(name => name == "Jose");
            FindJose.PrintPrimitive();

            List<Cart> listCarts = new List<Cart>();

            Cart car1 = new Cart("Ferrari", "red", 2000);
            Cart car2 = new Cart("lamborghini", "blue", 2005);
            Cart car3 = new Cart("Pagani", "gray", 2005);
            Cart car4 = new Cart("Bugatti", "red", 2010);

            listCarts.Add(car1);
            listCarts.Add(car2);
            listCarts.Add(car3); ;
            listCarts.Add(car4);

            // testing with a list objects:
            var FindCarts = listCarts.Filter1(cart => cart.Color == "red");
            foreach (var value in FindCarts)
            {
                Console.WriteLine(value.Name);
            }
        }
    }
}
