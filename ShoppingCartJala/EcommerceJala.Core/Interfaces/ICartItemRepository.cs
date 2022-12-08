using EcommerceJala.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceJala.Core.Interfaces
{
    public interface ICartItemRepository
    {
        Task<CartItem> AddToCart(int id);
        string GetCartId();
        List<CartItem> GetCartItems();
        decimal GetTotal();
        Task RemoveItem(int removeProductID);
        Task UpdateItem(int updateProductID, int quantity);
        Task EmptyCart();
        int GetCount();
    }
}
