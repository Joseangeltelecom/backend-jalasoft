using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBreadFrontend.MenusLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryFreshBreadFrontend
{
    public static class Orders
    {
        public static void MenuOrders(string OfficeName) 
        {
             if (OfficeName == "Main")
             {
                MenuMainOfficeLogic.Run();
             }
            if (OfficeName == "Secondary")
            {
                MenuSecondaryOfficeLogic.Run();
            }
        }


        public static async void SaveOrder(OrderDTO orderDTO) 
        {

            var totalCost = 0;

            //foreach (var item in orderDTO.BreadOrder)
            //{
            //    totalCost = 
            //}

            //OrderDTO orderDTO = new OrderDTO()
            //{
            //         = orderDTO.ord",
            //    Capacity = 150
            //};

            //var office = await ApiRequest.Create("https://localhost:5001/api/offices", orderDTO);
            //return office;
        }
    }
}
