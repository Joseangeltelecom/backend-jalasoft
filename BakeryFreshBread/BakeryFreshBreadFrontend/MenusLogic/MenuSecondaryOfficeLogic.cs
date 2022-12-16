using BakeryFreshBread.Core.DTO_s;
using System;
using System.Collections.Generic;
using static BakeryFreshBreadFrontend.Enums.EnumOptions;

namespace BakeryFreshBreadFrontend.MenusLogic
{
    public class MenuSecondaryOfficeLogic
    {
        static int choiceSecondaryMenu = 0;
        static public string selectedType = "";
        public static async void Run()
        {
            Menus.MenuSecondaryOffice();
            choiceSecondaryMenu = Utils.ValidateInput(4);

            var quantity = Console.ReadLine();
            int castedQuantity = Convert.ToInt32(quantity);

            foreach (var searchMember in Enum.GetValues(typeof(MenuMainOffice)))
            {
                if (choiceSecondaryMenu == (int)searchMember)
                {
                    selectedType = (string)searchMember;
                }
            }

            List<BreadOrderDTO> listBreadOrder = new List<BreadOrderDTO>();

            var bread = new BreadOrderDTO()
            {
                BreadId = 2,
                Quantity = castedQuantity
            };

            listBreadOrder.Add(bread);

            OrderDTO orderdto = new OrderDTO()
            {
                OfficeId = 2,
                Status = "Preparing",
                BreadOrder = listBreadOrder
            };

            await Orders.SaveOrder(orderdto);
        }
    }
}
