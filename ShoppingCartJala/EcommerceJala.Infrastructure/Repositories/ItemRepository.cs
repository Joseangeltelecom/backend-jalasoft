using EcommerceJala.Core.Entities;
using System.Collections.Generic;

namespace EcommerceJala.Infrastructure.Repositories
{
    public class ItemRepository
    {
        public List<Item> items;

        public ItemRepository()
        {
            items = new List<Item>()
            {
                new Item()
                {
                Name = "Item 3",
                ItemId = 3,
                Price = 25,
                Description= "Description item 3",
                Quantity=20
                },
                new Item()
                {
                Name = "Item 4",
                ItemId = 4,
                Price = 15,
                Description= "Description item 4",
                Quantity=20
                }
            };
        }
    }
}