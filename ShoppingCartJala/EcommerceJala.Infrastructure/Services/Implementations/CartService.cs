using EcommerceJala.Core.Entities;
using EcommerceJala.Infrastructure.Repositories;
using EcommerceJala.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceJala.Infrastructure.Services.Implementations
{
    public class CartService : ICartService
    {
        CartRepository cartRepository = new CartRepository();
        public async Task AddItem(int id)
        {
            var FoundItem = cartRepository.inventory.Find(p => p.ItemId == id);

            bool alreadyExist = cartRepository.shoppingCart.Contains(FoundItem);
            if (!alreadyExist)
            {
                await Task.Delay(5);
                cartRepository.shoppingCart.Add(FoundItem);

                foreach (var item in cartRepository.inventory)
                    if (item.ItemId == id)
                    {
                        await Task.Delay(5);
                        item.Quantity -= 1;
                    }
            }
            else
            {
                foreach (var item in cartRepository.shoppingCart)
                    if (item.ItemId == id)
                    {
                        await Task.Delay(5);
                        item.Quantity += 1;
                    }
                foreach (var item in cartRepository.inventory)
                    if (item.ItemId == id)
                    {
                        await Task.Delay(5);
                        item.Quantity -= 1;
                    }
            }
        }

        public async Task RemoveItem(int id)
        {
            var FoundItem = cartRepository.shoppingCart.Find(p => p.ItemId == id);
            if (FoundItem != null && FoundItem.Quantity > 0)
            {
                FoundItem.Quantity -= 1;
                foreach (var item in cartRepository.inventory)
                    if (item.ItemId == id)
                    {
                        await Task.Delay(5);
                        item.Quantity += 1;
                    }
            }
            else
            {
                cartRepository.shoppingCart.Remove(FoundItem);
                foreach (var item in cartRepository.inventory)
                    if (item.ItemId == id)
                    {
                        await Task.Delay(5);
                        item.Quantity += 1;
                    }
            }
        }

        async public Task<double> ComputeTotal()
        {
            double total = cartRepository.shoppingCart.Sum(item => item.Quantity * item.Price);
            await Task.Delay(5);
            return total;
        }

        async public Task<IEnumerable<Item>> ShowItemsList()
        {
            await Task.Delay(5);
            return cartRepository.shoppingCart;
        }
    }
}
