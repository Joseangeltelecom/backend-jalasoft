using EcommerceJala.Core.Entities;
using System.Collections.Generic;

namespace EcommerceJala.Infrastructure.Repositories
{
    public class CartRepository
    {
        public List<Item> shoppingCart;
        public List<Item> inventory;  
        public CartRepository() 
        {
           shoppingCart = new List<Item>()
            {
                new Item()
                {
                Name = "Item 1",
                ItemId = 1,
                Price = 20,
                Description= "Description item 1",
                Quantity=1
                },
                new Item()
                {
                Name = "Item 2",
                ItemId = 2,
                Price = 10,
                Description= "Description item 2",
                Quantity=2
                }
            };

            inventory = new ItemRepository().items;
        }
    }
}