using BakeryFreshBread.Core.DTO_s;
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

        public BreadController(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBreads()
        {
            var breads = await _breadRepository.GetAllBreads();
            return Ok(breads);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBread(BreadDTO breadDTO)
        {
            await _breadRepository.CreateBread(breadDTO);
            return Ok(await _breadRepository.GetAllBreads());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBreadById(int id)
        {
            var item = await _breadRepository.GetBreadById(id);
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBreadById(int id)
        {
            await _breadRepository.DeleteBreadById(id);
            return Ok(await _breadRepository.GetAllBreads());
        }

        
        [HttpGet("office/id")]
        public async Task<IActionResult> GetAllBreadsByOffice(int officeId)
        {
            var Breads = await _breadRepository.GetAllBreadsByOffice(officeId);
            return Ok(Breads);
        }
    }
}
