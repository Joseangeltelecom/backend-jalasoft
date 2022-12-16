using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBreadFrontend
{
    public static class Utils
    {
        static public void ValidateNull(string field)
        {
            while (field == "" || field == null)
            {
                Console.WriteLine("The field can't be emptied");
                field = Console.ReadLine();
            }
        }

        static public int ValidateInput(int number)
        {
            var stringNumber = Console.ReadLine();
            int n;
            bool isNumeric = int.TryParse(stringNumber, out n);

            while (!isNumeric || Int32.Parse(stringNumber) > number || Int32.Parse(stringNumber) < 1)
            {
                Console.WriteLine($"Invalid input, Please type a number 1 - {number}");
                stringNumber = Console.ReadLine();
                isNumeric = int.TryParse(stringNumber, out n);
            }
            return Int32.Parse(stringNumber);
        }
    }
}
