using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BakeryFreshBread.Api.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepository;
        public OfficeController(IOfficeRepository OfficeRepository)
        {
            _officeRepository = OfficeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetOffices()
        {
            var offices = await _officeRepository.GetOffices();
            return Ok(offices);
        }

        [HttpGet("orders/id")]
        public async Task<IActionResult> getAllOrdersByOffice(int id)
        {
            var offices = await _officeRepository.getAllOrdersByOffice(id);
            return Ok(offices);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffice(OfficeDTO officeDTO)
        {
            await _officeRepository.CreateOffice(officeDTO);
            return Ok(await _officeRepository.GetOffices());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOfficeById(int id)
        {
            var item = await _officeRepository.GetOfficeById(id);
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductById(int id)
        {
            await _officeRepository.RemoveOfficeById(id);
            return Ok(await _officeRepository.GetOffices());
        }
    }
}
