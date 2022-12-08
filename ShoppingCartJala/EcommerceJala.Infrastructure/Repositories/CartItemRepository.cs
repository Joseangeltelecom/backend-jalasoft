using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Interfaces;
using EcommerceJala.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly EcommerceJalaContext _context;
        public CartItemRepository(EcommerceJalaContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }

        public string GetCartId()
        {
            return "cart-user-test";
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            var list = _context.ShoppingCartItems.Include(s => s.Product).Where(
                c => c.CartId == ShoppingCartId).ToList();
            return list;
        }


        public decimal GetTotal()
        {  
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _context.ShoppingCartItems
                               select (int?)cartItems.Quantity *
                               cartItems.Product.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }

        async public Task RemoveItem(int removeProductID)
        {
            {
                try
                {
                    var myItem = (from c in _context.ShoppingCartItems where c.Product.ProductID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _context.ShoppingCartItems.Remove(myItem);
                       await _context.SaveChangesAsync();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public async Task UpdateItem(int updateProductID, int quantity)
        {
            {
                try
                {
                    var myItem = (from c in _context.ShoppingCartItems where c.Product.ProductID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        async public Task EmptyCart()
        {
            var cartItems = _context.ShoppingCartItems;
            foreach (var cartItem in cartItems)
            {
                _context.ShoppingCartItems.Remove(cartItem);
            }
            // Save changes.             
            await _context.SaveChangesAsync();
        }

         public int GetCount()
        {
            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _context.ShoppingCartItems
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        async public Task<CartItem> AddToCart(int id)
        {
            ShoppingCartId = GetCartId();

            var cartItem = _context.ShoppingCartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ProductId == id);

            var product = _context.Products.SingleOrDefault(
                   p => p.ProductID == id);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _context.ShoppingCartItems.Add(cartItem);
                

            }
            else
            {
                cartItem.Quantity++;
            }
           await _context.SaveChangesAsync();
            return cartItem;
        }
    }
}