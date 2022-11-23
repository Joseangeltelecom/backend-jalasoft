using EcommerceJala.Core.Entities;
using EcommerceJala.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceJala.Api.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        { 
            var items = await _itemService.GetItems();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            //return await _itemRepository.GetItem(id);
            var item =  await _itemService.GetItem(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            Item newItem = new Item()
            {
                Name = item.Name,
                ItemId = item.ItemId,
                Price= item.Price,
                Description = item.Description,
                Quantity = item.Quantity
            };
            await _itemService.AddItem(newItem);
            //return Ok(_itemRepository.GetItem(newItem.ItemId));
            return Ok(await _itemService.GetItems());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            await _itemService.RemoveItem(id);
            //return Ok(_repository.Get(id));
            return Ok( await _itemService.GetItems());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Item item)
        {
            Item newItem = new Item()
            {
                Name = item.Name,
                ItemId = item.ItemId,
                Price = item.Price,
                Description = item.Description,
                Quantity = item.Quantity
            };
            await _itemService.UpdateItem(newItem);
            //return Ok(_itemRepository.GetItem(newItem.ItemId));
            return Ok(await _itemService.GetItems());
        }
    }
}