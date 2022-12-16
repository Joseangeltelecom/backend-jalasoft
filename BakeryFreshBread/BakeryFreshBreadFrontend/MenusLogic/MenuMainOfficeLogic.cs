using BakeryFreshBread.Core.DTO_s;
using System;
using System.Threading.Tasks;
using static BakeryFreshBreadFrontend.Enums.EnumOptions;

namespace BakeryFreshBreadFrontend.MenusLogic
{
    public static class MenuMainOfficeLogic
    {
        static int choiceMainMenu = 0;
        static public string selectedType = "";



        public static async Task<OfficeDTO> CreateOffice() 
        {
            OfficeDTO officeDTO = new OfficeDTO()
            {
                OfficeName = "Main",
                Capacity = 150

            };

            var office = await ApiRequest.Create("https://localhost:5001/api/offices", officeDTO);
            return office;
        }

       

    public async static void Run()
        {
            Menus.MenuMainOffice();
            choiceMainMenu = Utils.ValidateInput(4);
  
            var quantity = Console.ReadLine();
            int a = Convert.ToInt32(quantity);

            foreach (var searchMember in Enum.GetValues(typeof(MenuMainOffice)))
            {
                if (choiceMainMenu == (int)searchMember)
                {
                    selectedType = (string)searchMember;
                }
            }

            await CreateOffice();
            //Orders.SaveOrder(selectedType, a, 1);
        }  
    }        
}
