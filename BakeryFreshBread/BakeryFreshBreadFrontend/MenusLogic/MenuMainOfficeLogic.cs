using BakeryFreshBread.Core.DTO_s;
using System;
using System.Collections.Generic;
using static BakeryFreshBreadFrontend.Enums.EnumOptions;

namespace BakeryFreshBreadFrontend.MenusLogic
{
    public static class MenuMainOfficeLogic
    {
        static int choiceMainMenu = 0;
        static public string selectedType = "";

    public async static void Run()
        {
            Menus.MenuMainOffice();

            choiceMainMenu = Utils.ValidateInput(4);
  
            var quantity = Console.ReadLine();

            int castedQuantity = Convert.ToInt32(quantity);

            foreach (var selectedBread in Enum.GetValues(typeof(MenuMainOffice)))
            {
                if (choiceMainMenu == (int)selectedBread)
                {
                    selectedType = (string)selectedBread;
                }
            }

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
                Status = "Preparing",
                BreadOrder = listBreadOrder
            };

            await Orders.SaveOrder(orderdto);
        }  
    }        
}
