using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBreadFrontend.MenusLogic
{
    public static class MainMenu
    {
        static int choiceMainMenu = 0;
         public static void Run()
        {
            Menus.MainMenu();
            choiceMainMenu = Utils.ValidateInput(4); ;

            if (choiceMainMenu == 1)
            {
                MainOffice.Run();
            }

            else if (choiceMainMenu == 2)
            {
                SecondaryOffice.Run();
            }
        }
    }
}
