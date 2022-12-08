using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflexionTask
{
    public class Program
    {
        static public int choiceMainMenu = 0;
        static public int choiceMenuData = 0;
        static public bool runMenuOptions = true;
        static public bool runMenuDataOptions = true;
        static public string typeUser = "";
        static public int searchedMember;
        static public BindingFlags BindingFlag1;
        static public BindingFlags BindingFlag2;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Reflexion App.");
            while (runMenuOptions)
            {
               StartMenu();
            }
            Console.WriteLine("\nThank you for using this App.");
            Console.ReadKey();
        }

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

        static public void GetModules()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Module[] modules = assembly.GetModules();
  
            foreach (Module module in modules)
            {
                Console.WriteLine("Module - " + module);
            }
        } 

        static public void GetAllTypes()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Module[] modules = assembly.GetModules();
            List<Type> types = modules[0].GetTypes().ToList();
            foreach (Module module in modules)
            {
                foreach (Type type in module.GetTypes())
                {
                    types.Add(type);
                    Console.WriteLine("Type - " + type);
                }
            }
        }

        static public void GetSpecificType()
        {
            Console.WriteLine("\nPlease Insert the assembly's type name: ");
            string typeUserAux = Console.ReadLine();
            ValidateNull(typeUserAux);
            typeUser = typeUserAux;
            StartMemberOptions();
            PerformanceAction(typeUser, searchedMember, BindingFlag1, BindingFlag2);
            StartMenu();
        }

        static public void PerformanceAction(string typeUser, int searchedMember, BindingFlags filterBindingFlag1, BindingFlags filterBindingFlag2)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type Type = assembly.GetType(typeUser);
    
            if (searchedMember == 1) 
            {
                MethodInfo[] methods = Type.GetMethods(filterBindingFlag1 | filterBindingFlag2);
                PrintMembers(methods);
            }
            if (searchedMember == 2)
            {
                ConstructorInfo[] constructors = Type.GetConstructors(filterBindingFlag1 | filterBindingFlag2);
                PrintMembers(constructors);
            }
            if (searchedMember == 3)
            {
                FieldInfo[] fields = Type.GetFields(filterBindingFlag1 | filterBindingFlag2);
                PrintMembers(fields);
            }
            if (searchedMember == 4)
            {
                PropertyInfo[] properties = Type.GetProperties(filterBindingFlag1 | filterBindingFlag2);
                PrintMembers(properties);
            }
        }

        static public void PrintMembers<T>(IEnumerable<T> members) 
        {
            Console.WriteLine($"\n//**Results**//\n");
            foreach (T member in members)
            {
                Console.WriteLine(member);
            };
        }
        static public void MenuOptions()
        {
            Console.WriteLine(
         $"\n//**You are in the main Menu**//\n" +
         $"\nPlease Select an option:\n" +
         $"1.Name of the assemblys's Modules\n" +
         $"2.Name of all the assembly's types\n" +
         $"3.Specific information of a assembly's type\n" +
         $"4.Quit\n");
        }
        static public void MemberOptions()
        {
            Console.WriteLine(
         $"\nPlease select an option to search: \n" +
         $"1.Methods\n" +
         $"2.Constructors\n" +
         $"3.Fields\n" +
         $"4.Properties\n");
        }

        static public void Filter1Option()
        {
            Console.WriteLine(
         $"\nSelect the 1er filter: \n" +
         $"1.Instances\n" +
         $"2.Statics\n" +
         $"3.Both \n");
        }

        static public void Filter2ption()
        {
            Console.WriteLine(
         $"\nSelect the 2nd filter: \n" +
         $"1.Public\n" +
         $"2.Non-public\n" +
         $"3.Both \n");
        }

        enum SearchedMember
        {
            methods = 1,
            constructors = 2,
            fields = 3,
            properties = 4
        }
        static void StartMemberOptions()
        {
            MemberOptions();
            choiceMenuData = ValidateInput(4);
  
            foreach (var searchMember in Enum.GetValues(typeof(SearchedMember)))
            {
                if (choiceMenuData == (int)searchMember)
                {
                    searchedMember = (int)searchMember;
                }
            }
            StartFilter1Option();
        }
        static public void StartMenu()
        {
            MenuOptions();
            choiceMainMenu = ValidateInput(4); ;

            if (choiceMainMenu == 1)
            {
                GetModules();
            }

            else if (choiceMainMenu == 2)
            {
                GetAllTypes();
            }

            else if (choiceMainMenu == 3)
            {
                while (runMenuDataOptions)
                {
                    GetSpecificType();
                }
            }

            else if (choiceMainMenu == 4)
            {
                runMenuOptions = false;
            }
        }

        static void StartFilter1Option()
        {
            Filter1Option();
            choiceMenuData = ValidateInput(3);

            Dictionary<int, BindingFlags> myDictionary = new Dictionary<int, BindingFlags>();

            myDictionary.Add(1, BindingFlags.Instance);
            myDictionary.Add(2, BindingFlags.Static);
            myDictionary.Add(3, BindingFlags.Instance | BindingFlags.Static);

            foreach (var tupla in myDictionary)
            {
                if (choiceMenuData == tupla.Key)
                {
                    BindingFlag1 = tupla.Value;
                }
            }
            StartFilter2Option();
        }

        static void StartFilter2Option()
        {
            Filter2ption(); 
            choiceMenuData = ValidateInput(3);

            if (choiceMenuData == 1) 
            {
                BindingFlag2 = BindingFlags.Public;
            } 
            if (choiceMenuData == 2) 
            {
                BindingFlag2 = BindingFlags.NonPublic;
            } 
            if (choiceMenuData == 3) 
            {
                BindingFlag2 = BindingFlags.Public | BindingFlags.NonPublic;
            } 
        }
    }
}
