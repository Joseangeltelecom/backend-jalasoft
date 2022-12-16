using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BakeryFreshOrder.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepositoy)
        {
            _orderRepository = orderRepositoy;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var item = await _orderRepository.GetOrderById(id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderDTO addOrder)
        {
            var order = _orderRepository.CreateOrder(addOrder);
            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetAllOrder();
            return Ok(orders);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductById(int id)
        {
            await _orderRepository.RemoveOrderById(id);
            return Ok(await _orderRepository.GetAllOrder());
        }
    }
}
