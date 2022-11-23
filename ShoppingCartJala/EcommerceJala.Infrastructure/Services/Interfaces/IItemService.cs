using EcommerceJala.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Services.Interfaces
{
    public interface IItemService
    {
            Task<IEnumerable<Item>> GetItems();
            Task<Item> GetItem(int id);
            Task AddItem(Item item);
            Task RemoveItem(int id);
            Task<bool> UpdateItem(Item item);   
    }
}
