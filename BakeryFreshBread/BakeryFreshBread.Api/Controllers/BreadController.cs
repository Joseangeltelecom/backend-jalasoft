using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BakeryFreshBread.Api.Controllers
{
    [Route("api/breads")]
    [ApiController]
    public class BreadController : ControllerBase
    {
        private readonly IBreadRepository _breadRepository;

        public BreadController(IBreadRepository breadtRepository)
        {
            _breadRepository = breadtRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetBreads()
        {
            var breads = await _breadRepository.GetBreads();
            return Ok(breads);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBread(Bread bread)
        {
            Bread newBread = new Bread()
            {
                BreadType = bread.BreadType,
                Price = bread.Price,
            };
            await _breadRepository.CreateBread(newBread);
            return Ok(await _breadRepository.GetBreads());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBreadById(int id)
        {
            var item = await _breadRepository.GetBreadById(id);
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductById(int id)
        {
            await _breadRepository.RemoveBreadById(id);
            return Ok(await _breadRepository.GetBreads());
        }
    }
}
