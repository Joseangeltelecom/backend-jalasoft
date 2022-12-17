using BakeryFreshBread.Core.DTO_s;
using System;
using System.Collections.Generic;
using static BakeryFreshBreadFrontend.Enums.EnumOptions;

namespace BakeryFreshBreadFrontend.MenusLogic
{
    public static class MainOffice
    {
        static int choiceMainMenu = 0;
        static public int selectedType = 0;

    public async static void Run()
        {

            var action = OrderActions.Run();


            if(action == 1)
            {
                Menus.MenuMainOffice();
                choiceMainMenu = Utils.ValidateInput(4);
                Console.WriteLine("Enter Quantity");
                var quantity = Console.ReadLine();

                int castedQuantity = Convert.ToInt32(quantity);
                List<BreadOrderDTO> listBreadOrder = new List<BreadOrderDTO>();

                var bread = new BreadOrderDTO()
                {
                    BreadId = 1,
                    Quantity = castedQuantity
                };

                listBreadOrder.Add(bread);

                OrderDTO orderdto = new OrderDTO()
                {
                    OfficeId = 1,
                    Status = "Preparing!!!!!",
                    BreadOrder = listBreadOrder
                };

                await Orders.SaveOrder(orderdto);
            }

            if (action == 2)
            {

            }

            if (action == 3)
            {

            }


    

        

            foreach (var selectedBread in Enum.GetValues(typeof(MenuMainOffice)))
            {
                if (choiceMainMenu == (int)selectedBread)
                {
                    selectedType = (int)selectedBread;
                }
            }
     
        }  
    }        
}
