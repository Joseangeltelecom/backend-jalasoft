using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassMembers
{
    internal class SubMenuLogic
    {
        static public void StartSubMenu() 
        {
            Utilities.MenuDataOptions(); // subMenu options.
            MenuLogic.choiceMenuData = Utilities.ValidateInputSubMenu(); // input Sub Option.

            if (MenuLogic.choiceMenuData == 1) //see manager data.
            {
                if (!MenuLogic.managerExist)
                {
                    Console.WriteLine("\nA manager does not exist yet. Please try another option. Go back to main menu to create one.");
                }
                else
                {
                    MenuLogic.manager.GetMemberData();
                }
            } //see manager data.
            if (MenuLogic.choiceMenuData == 2) // see Trainer Data.
            {
                if (!MenuLogic.trainerExist)
                {
                    Console.WriteLine("\nA trainer does not exist yet. Please try another option. Go back to main menu to create one.");
                }
                else
                {
                    MenuLogic.trainer.GetMemberData();
                }
            } // see Trainer Data.
            if (MenuLogic.choiceMenuData == 3) // see students data.
            {
                if (!MenuLogic.courseExist || Course.studentsList.Count < 1)
                {
                    Console.WriteLine("\nYou have no students at all. Go back to main menu to add one.");
                }
                else
                {
                    MenuLogic.course.GetStudentList();
                }
            } // see students data.
            if (MenuLogic.choiceMenuData == 4) // quit to main menu.
            {
                MenuLogic.runMenuDataOptions = false;
            } // Go back to main menu.
        }
    }
}
