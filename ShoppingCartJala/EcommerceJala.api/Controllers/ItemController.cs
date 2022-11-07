using EcommerceJala.Core.Entities;
using EcommerceJala.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceJala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        { 
            var items = await _itemRepository.GetItems();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item =  await _itemRepository.GetItem(id);
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
            await _itemRepository.AddItem(newItem);
            //return Ok(_itemRepository.GetItem(newItem.ItemId));
            return Ok(await _itemRepository.GetItems());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveItem(int id)
        {
            await _itemRepository.RemoveItem(id);
            //return Ok(_repository.Get(id));
            return Ok( await _itemRepository.GetItems());
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
            await _itemRepository.UpdateItem(newItem);
            //return Ok(_itemRepository.GetItem(newItem.ItemId));
            return Ok(await _itemRepository.GetItems());
        }
    }
}