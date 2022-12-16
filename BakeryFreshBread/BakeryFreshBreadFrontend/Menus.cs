using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBreadFrontend
{
    public static class Menus
    {
         public static void MainMenu()
        {
            Console.WriteLine(
         $"\nBakery Fresh Bread:\n" +
         $"\n___________________\n" +
         $"\nSelect the Office to make an order:\n" +
         $"1.Main Office\n" +
         $"2.Secondary Office");
        }

         public static void MenuOfficeActions()
        {
            Console.WriteLine(
         $"\nBakery Fresh Bread:\n" +
         $"\n___________________\n" +
         $"\nSelect an action to perform:\n" +
         $"1.Add order\n" +
         $"2.Prepare all the orders\n" +
         $"3.Go back to the main menu\n");
        }

         public static void MenuMainOffice()
        {
            Console.WriteLine(
         $"\nBakery Fresh Bread:\n" +
         $"\n___________________\n" +
         $"\nSelect a bread type and quantity:\n" +
         $"1.Baguettes: 2.0 $US\n" +
         $"2.White Bread: 2.5 $US\n" +
         $"3.Milk Bread: 1.5 $US \n");
        }
         public static void MenuSecondaryOffice()
        {
            Console.WriteLine(
         $"\nBakery Fresh Bread:\n" +
         $"\n___________________\n" +
         $"\nSelect a bread type and quantity: \n" +
         $"1.Baguettes: 2.0 $US\n" +
         $"2.White Bread: 2.5 $US\n" +
         $"3.Hamburger Bun: 1.0 $US\n");
        }
    }
}
