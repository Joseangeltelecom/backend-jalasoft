using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collections
{
    internal static class StackCollection
    {
        public static void ReverseString(string value) 
        {
            Stack myStack = new Stack();
            string[] pieces = value.Split(" ");

            foreach (var elem in pieces)
            {
                myStack.Push(elem);
            }

            foreach (var elem in myStack)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
