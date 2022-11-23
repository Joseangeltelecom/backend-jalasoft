using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Exceptions;
using EcommerceJala.Infrastructure.Repositories;
using EcommerceJala.Infrastructure.Services.Interfaces;
using EcommerceJala.Infrastructure.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Services.Implementations
{
    public class ItemService : IItemService
    {
        ItemRepository itemRepository = new ItemRepository();
        async public Task<IEnumerable<Item>> GetItems()
        {
            await Task.Delay(5);
            return itemRepository.items;
        }
        async public Task<Item> GetItem(int id)
        {
            var FoundItem = itemRepository.items.Find(p => p.ItemId == id);
            if (FoundItem != null)
            {
                await Task.Delay(5);
                return FoundItem;
            }
            else
            {
                throw new ItemNotFoundException("Item not found");
            }
        }
        async public Task AddItem(Item item)
        {
            CreateItemValidator.Validate(item);
            await Task.Delay(5);
            itemRepository.items.Add(item);
        }
        async public Task RemoveItem(int id)
        {
            var FoundItem = itemRepository.items.Find(p => p.ItemId == id);
            if (FoundItem != null)
            {
                await Task.Delay(5);
                itemRepository.items.RemoveAll(p => p.ItemId == id);
            }
            else
            {
                throw new ItemNotFoundException("Item not found");
            }
        }
        public async Task<bool> UpdateItem(Item item)
        {
            int index = itemRepository.items.FindIndex(p => p.ItemId == item.ItemId);

            if (index != -1)
            {
                itemRepository.items.RemoveAt(index);
                itemRepository.items.Add(item);
                await Task.Delay(5);
                return true;
            }
            else
            {
                throw new ItemNotFoundException("Item not found");
            }

        }
    }
}
