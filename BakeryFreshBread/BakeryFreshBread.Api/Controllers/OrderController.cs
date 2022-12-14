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
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            return Ok(orders);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateOrder(Order order)
        //{
        //    Order newOrder = new Order
        //    {
        //        BreadOrder = order.BreadOrder,
        //        Status = order.Status,
        //        TotalCost = order.TotalCost,
        //        DateCreated = DateTime.Now,
        //        DateModified = DateTime.Now
        //    };

        //    await _orderRepository.CreateOrder(newOrder);
        //    return Ok(await _orderRepository.GetOrders());
        //}

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrderWithRequest(CreateOrderRequest createOrderRequest)
        {
            await _orderRepository.CreateOrderWithRequest(createOrderRequest);
            return Ok(await _orderRepository.GetOrders());
        }

        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> AddBreadOrderToSpecificOrderList(CreateOrderRequest createOrderRequest)
        //{
        //    await _orderRepository.AddBreadOrderToSpecificOrderList(createOrderRequest);
        //    return Ok(await _orderRepository.GetOrders());
        //}

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var item = await _orderRepository.GetOrderById(id);
            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProductById(int id)
        {
            await _orderRepository.RemoveOrderById(id);
            return Ok(await _orderRepository.GetOrders());
        }
    }
}
