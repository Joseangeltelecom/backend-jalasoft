using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EcommerceJala.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public List<Item> items = new List<Item>() 
        { 
            new Item()
            {
            Name = "Item 1",
            ItemId = 1,
            Price = 20,
            Description= "Description item 1",
            Quantity=20
            },
         new Item()
            {
            Name = "Item 2",
            ItemId = 2,
            Price = 10,
            Description= "Description item 2",
            Quantity=20
            }
        };
        async public Task<IEnumerable<Item>> GetItems()
        {
            await Task.Delay(5);
            return items;
        }
        async public Task<Item> GetItem(int id)
        {
            await Task.Delay(5);
            return items.Find(p => p.ItemId == id);
        }
        async public Task AddItem(Item item)
        {
            
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            await Task.Delay(5);
            items.Add(item);
        }
        async public Task RemoveItem(int id)
        {
            await Task.Delay(5);
            items.RemoveAll(p => p.ItemId == id);  
        }
        public async Task<bool> UpdateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = items.FindIndex(p => p.ItemId == item.ItemId);
            if (index == -1)
            {
                await Task.Delay(5);
                return false;
            }
            items.RemoveAt(index);
            items.Add(item);
            await Task.Delay(5);
            return true;
        }
    }
}