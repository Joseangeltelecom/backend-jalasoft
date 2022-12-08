using EcommerceJala.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceJala.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product item);
        Task RemoveProductById(int id);
        Task<bool> UpdateProduct(Product item);
    }
}
