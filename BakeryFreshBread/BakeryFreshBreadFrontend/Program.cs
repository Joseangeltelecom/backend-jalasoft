using BakeryFreshBread.Core.Entities;
using BakeryFreshBreadFrontend.MenusLogic;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BakeryFreshBreadFrontend
{
    internal class Program
    {

        //static public int choiceMenuData = 0;
        static public bool runMenuOptions = true;
        //static public bool runMenuDataOptions = true;
        //static public string typeUser = "";
        //static public int searchedMember;
        //static public BindingFlags BindingFlag1;
        //static public BindingFlags BindingFlag2;
        static async Task Main(string[] args)
        {
            //var offices = await ApiRequest.GetList<Office>("https://localhost:5001/api/offices");
            //foreach (var office in offices)
            //{
            //    Console.WriteLine(office.OfficeId);
            //    Console.WriteLine(office.OfficeName);
            //    Console.WriteLine(office.Capacity);
            //}

            Console.WriteLine("Welcome to the Reflexion App.");
            while (runMenuOptions)
            {
                MainMenuLogic.Run();
            }
            Console.WriteLine("\nThank you for using this App.");
            Console.ReadKey();
        }
    }
}
