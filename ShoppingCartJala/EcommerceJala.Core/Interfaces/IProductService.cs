using EcommerceJala.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GeProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product item);
        Task RemoveProduct(int id);
        Task<bool> UpdateProduct(Product item);
    }
}
