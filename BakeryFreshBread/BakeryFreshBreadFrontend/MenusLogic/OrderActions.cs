
using BakeryFreshBread.Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using static BakeryFreshBreadFrontend.Enums.EnumOptions;

namespace BakeryFreshBreadFrontend.MenusLogic
{
    public class OrderActions
    {
        static int actionChoice = 0;
        
        public static int Run()
        {
            var selectedAction = 0;
            Menus.MenuOfficeActions();
            actionChoice = Utils.ValidateInput(4);

            foreach (var searchMember in Enum.GetValues(typeof(MenuMainOffice)))
            {
                if (actionChoice == (int)searchMember)
                {
                    selectedAction = (int)searchMember;
                }
            }
            return selectedAction;
        }
    }
}
