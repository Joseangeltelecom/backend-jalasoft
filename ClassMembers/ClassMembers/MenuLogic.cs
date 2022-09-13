using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassMembers
{
    internal class MenuLogic
    {
        static public int choiceMainMenu = 0;
        static public int choiceMenuData = 0;
        static public bool runMenuOptions = true;
        static public bool runMenuDataOptions = true;
        static public bool courseExist = false;
        static public bool managerExist = false;
        static public bool trainerExist = false;

        static public Member manager;
        static public Member trainer;
        static public Member student;
        static public Course course;
        static public void StartMenu()
        {
            Utilities.MenuOptions(); // Menu options
            choiceMainMenu = Utilities.ValidateInputMenu(); // input an Option.;

            if (choiceMainMenu == 1) //Create manager.
            {
                manager = Utilities.CreateMember(Role.manager);
                managerExist = true;
            } //Create manager

            else if (choiceMainMenu == 2) // Create trainer.
            {
                trainer = Utilities.CreateMember(Role.trainer);
                trainerExist = true;
            } // Create trainer

            else if (choiceMainMenu == 3) // Create course.
            {
                if (!managerExist || !trainerExist)
                {
                    Console.WriteLine("\nPlease create a Manager and a Trainer before creating a course.");
                }
                else
                {
                    course = Utilities.CreateCourse(manager, trainer);
                    courseExist = true;
                }
            } // Create course

            else if (choiceMainMenu == 4) // Add student to course.
            {
                if (!courseExist)
                {
                    Console.WriteLine("\nPlease create a course before you add a student.");
                }
                else
                {
                    student = Utilities.CreateMember(Role.student);
                    course.AddStudent(student);
                }
            } // Add student to course

            else if (choiceMainMenu == 5) // See Data.
            {

                if (!managerExist && !trainerExist && !courseExist)
                {
                    Console.WriteLine("\nYou have no data at all.");
                }
                else
                {
                    while (runMenuDataOptions)
                    {
                        SubMenuLogic.StartSubMenu();
                    }
                }
            } // Go to submenu

            else if (choiceMainMenu == 6)
            {
                runMenuOptions = false;
            } //Quit app
        }
    }
}
