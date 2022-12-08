using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Exceptions;
using EcommerceJala.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceJala.Infrastructure.Validators
{
    public class CreateItemValidator
    {
        private static  EcommerceJalaContext _context;

        public CreateItemValidator(EcommerceJalaContext context)
        {
            _context = context;
        }
        public static void Validate(Product product)
        {
            //var Currentproduct = _context.Products.FirstOrDefaultAsync(product => product.ProductName == product.ProductName);

            if (product == null)
            {
                throw new ItemArgumentExeption($"{nameof(product)} is null.");
            }
            else if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                throw new ItemArgumentExeption($"{nameof(product.ProductName)} is null/Empty.");
            }
            //else if (Currentproduct != null)
            //{
            //    throw new ItemArgumentExeption($"{nameof(product.ProductName)} Already Exists.");
            //}
            else if (string.IsNullOrWhiteSpace(product.Description))
            {
                throw new ItemArgumentExeption($"{nameof(product.Description)} is null/Empty.");
            }
            else if (product.UnitPrice <= 0)
            {
                throw new ItemArgumentExeption($"{nameof(product.UnitPrice)} can't be less or equal to zero (0).");
            }
        }
    }

}
