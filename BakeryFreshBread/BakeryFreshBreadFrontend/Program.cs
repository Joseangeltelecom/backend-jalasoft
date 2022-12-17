using BakeryFreshBread.Core.Entities;
using BakeryFreshBreadFrontend.MenusLogic;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BakeryFreshBreadFrontend
{
    internal class Program
    {
        static public bool runMenuOptions = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the BakeryfreshBread App.");
            while (runMenuOptions)
            {
                MainMenu.Run();
            }
            Console.WriteLine("\nThank you for using this App.");
            Console.ReadKey();
        }
    }
}