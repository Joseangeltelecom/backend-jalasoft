using EcommerceJala.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Services.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<Item>> ShowItemsList();
        Task AddItem(int id);
        Task RemoveItem(int id);
        Task<double> ComputeTotal();
    }
}
