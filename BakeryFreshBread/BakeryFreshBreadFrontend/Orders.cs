using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBreadFrontend.MenusLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task<bool> SaveOrder(OrderDTO orderDTO) 
        {
          await ApiRequest.Create("https://localhost:5001/api/offices", orderDTO);

            return true;
        }
    }
}
