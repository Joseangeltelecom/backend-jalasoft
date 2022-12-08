using EcommerceJala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceJala.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepository;
        public CartItemController(ICartItemRepository carItemRepository)
        {
            _cartItemRepository = carItemRepository;
        }

        [HttpPost]
        public IActionResult AddProductToCart(int id)
        {
            var cartItem = _cartItemRepository.AddToCart(id);
            return Ok(cartItem);
           
        }

        [HttpGet]
        public IActionResult ShowItemsCart()
        {
            var product = _cartItemRepository.GetCartItems();
            return Ok(product);
        }

        [HttpGet]
        [Route("total")]
        public IActionResult GetTotal()
        {
            var total = _cartItemRepository.GetTotal();
            return Ok(total);
        }

        [HttpGet]
        [Route("count")]
        public IActionResult GetCount()
        {
            var count = _cartItemRepository.GetCount();
            return Ok(count);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCartItem(int id)
        {
            await _cartItemRepository.RemoveItem(id);
            return Ok(_cartItemRepository.GetCartItems());
        }

        [HttpPost]
        [Route("empty")]
        public IActionResult EmptyCart()
        {
             _cartItemRepository.EmptyCart();
            return Ok(_cartItemRepository.GetCartItems());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(int updateProductID, int quantity)
        {
            await _cartItemRepository.UpdateItem(updateProductID, quantity);
            return Ok(_cartItemRepository.GetCartItems());
        }
    }
}
