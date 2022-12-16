using BakeryFreshBread.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static BakeryFreshBreadFrontend.Enums.EnumOptions;


namespace BakeryFreshBreadFrontend.MenusLogic
{
    public class MenuSecondaryOfficeLogic
    {
        static int choiceSecondaryMenu = 0;
        static public string selectedType = "";
        public static void Run()
        {
            Menus.MenuSecondaryOffice();
            choiceSecondaryMenu = Utils.ValidateInput(4);

              // CreateOffice


            foreach (var searchMember in Enum.GetValues(typeof(MenuMainOffice)))
            {
                if (choiceSecondaryMenu == (int)searchMember)
                {
                    selectedType = (string)searchMember;
                }
            }
            //Orders.SaveOrder(selectedType, 30, 1);
        }
    }
}
