using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassMembers
{
    internal class Utilities
    {
        static public void ValidateNull(string field)
        {
            while (field == "" || field == null)
            {
                Console.WriteLine("The field can't be emptied");
                field = Console.ReadLine();
            }
        } // validate if the input data is emptied.
        static public int ValidateInputMenu() 
        {
            var stringNumber = Console.ReadLine();
            int n;
            bool isNumeric = int.TryParse(stringNumber, out n);

            while (!isNumeric || Int32.Parse(stringNumber) > 6 || Int32.Parse(stringNumber) < 1)
            {
                Console.WriteLine("Invalid input, Please type a number 1 - 6");
                stringNumber = Console.ReadLine();
                isNumeric = int.TryParse(stringNumber, out n);
            }
            return Int32.Parse(stringNumber);
        }// validate It's a number and 1 - 6.
        static public int ValidateInputSubMenu()
        {
            var stringNumber = Console.ReadLine();
            int n;
            bool isNumeric = int.TryParse(stringNumber, out n);

            while (!isNumeric || Int32.Parse(stringNumber) > 4 || Int32.Parse(stringNumber) < 1)
            {
                Console.WriteLine("Invalid input, Please type a number 1 - 4");
                stringNumber = Console.ReadLine();
                isNumeric = int.TryParse(stringNumber, out n);
            }

            return Int32.Parse(stringNumber);
        } //  validate It's a number and 1 - 4.
        static public Member CreateMember(Role role)
        {
            Console.WriteLine("\nPlease Insert a name:");
            string name = Console.ReadLine();
            ValidateNull(name);
            Console.WriteLine("\nPlease Insert a Lastname:");
            string lastname = Console.ReadLine();
            ValidateNull(lastname);
            Console.WriteLine("\nInsert an Email:");
            string email = Console.ReadLine();
            ValidateNull(email);

            Console.WriteLine($"\nMember {name} susscefully created with role {role}.");
            return new Member(name, lastname, email, role);
        } // Create a Member.
        static public Course CreateCourse(Member manager, Member trainer)
        {
            Console.WriteLine("\nPlease Insert a name for your course:\n");
            string name = Console.ReadLine();
            ValidateNull(name);

            Console.WriteLine($"\nThe course {name} has been susscefully created.");
            return new Course(manager, trainer, name);
        } // Create a course
        static public void MenuOptions()
        {
            Console.WriteLine(
         $"\n//**You are in the main Menu**//\n" +
         $"\nPlease Select an option:\n" +
         $"1.Create manager\n" +
         $"2.Create trainer\n" +
         $"3.Create Course\n" +
         $"4.Add student to course\n" +
         $"5.See data\n" +
         $"6.Quit\n");
         } // Show main menu
        static public void MenuDataOptions()
        {
            Console.WriteLine(
         $"\n//**You are in the Submenu**//\n" +
         $"\nPlease Select an option:\n" +
         $"1.See Manager Data\n" +
         $"2.See Trainer Data\n" +
         $"3.See students list\n" +
         $"4.Back to Main Menu.\n");
        } // Show Submenu
    }
}
