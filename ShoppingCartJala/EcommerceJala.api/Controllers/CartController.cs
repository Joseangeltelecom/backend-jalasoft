using EcommerceJala.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceJala.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("/api/cart/showitems")]
        public async Task<IActionResult> ShowItemsList()
        { 
            var items = await _cartService.ShowItemsList();
            return Ok(items);
        }

        [HttpGet]
        [Route("/api/cart/total")]
        public async Task<IActionResult> ComputeTotal()
        {
            var total = await _cartService.ComputeTotal();
            return Ok(total);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> AddItem(int id)
        {
            await _cartService.AddItem(id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            await _cartService.RemoveItem(id);
            return Ok();
        }
    }
}