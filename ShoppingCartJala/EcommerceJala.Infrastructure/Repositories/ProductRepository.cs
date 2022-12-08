using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Exceptions;
using EcommerceJala.Core.Interfaces;
using EcommerceJala.Infrastructure.Data;
using EcommerceJala.Infrastructure.Validators;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly EcommerceJalaContext _context;

        public ProductRepository(EcommerceJalaContext context)
        {
            _context = context;
        }
        async public Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        async public Task<Product> GetProductById(int id)
        {
            var CurrentProduct = _context.Products.FirstOrDefaultAsync(product => product.ProductID == id);
            if (CurrentProduct != null)
            {
                return await CurrentProduct;
            }
            else
            {
                throw new ItemNotFoundException("Product not found");
            }
        }
        async public Task AddProduct(Product product)
        {

            CreateItemValidator.Validate(product);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        async public Task RemoveProductById(int id)
        {
            var CurrentProduct = await GetProductById(id);
            if (CurrentProduct != null)
            {
                _context.Products.Remove(CurrentProduct);
            }
            else
            {
                throw new ItemNotFoundException("Product not found");
            }
        }
        public async Task<bool> UpdateProduct(Product newProduct)
        {
            var CurrentProduct = await GetProductById(newProduct.ProductID);

            if (CurrentProduct != null)
            {
                CurrentProduct.ProductName = newProduct.ProductName;
                CurrentProduct.UnitPrice = newProduct.UnitPrice;
                CurrentProduct.Description = newProduct.Description;
                CurrentProduct.ImagePath = newProduct.ImagePath;

                int rows = await _context.SaveChangesAsync();
                return rows > 0; // si se afecto al menos un registro devolvemos un True.
            }
            else
            {
                throw new ItemNotFoundException("Product not found");
            }
        }
    }
}