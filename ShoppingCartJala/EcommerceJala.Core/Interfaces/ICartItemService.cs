using EcommerceJala.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<IEnumerable<Product>> ShowItemsList();
        Task AddProductToCart(int id);
        Task RemoveProductFromCart(int id);
        Task<double> ComputeTotal();
    }
}
