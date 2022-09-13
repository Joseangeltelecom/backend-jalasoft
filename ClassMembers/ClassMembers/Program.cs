using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Linq;

namespace ClassMembers
{
    internal class Program
    {
        // Second version of my program:
        static void Main(string[] args) {

            Console.WriteLine("Welcome to the Class Members App.");
            while (MenuLogic.runMenuOptions)  
            {
               MenuLogic.StartMenu();
            }
            Console.WriteLine("\nThank you for using this App.");
            Console.ReadKey();
        }

    }
}
