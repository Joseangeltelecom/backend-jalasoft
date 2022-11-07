using EcommerceJala.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceJala.Core.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int id);
        Task AddItem(Item item);
        Task RemoveItem(int id);
        Task<bool> UpdateItem(Item item);
    }
}
