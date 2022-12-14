using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakeryFreshBread.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderWithRequest(CreateOrderRequest createOrderRequest);
        Task AddBreadOrderToSpecificOrderList(CreateOrderRequest createOrderRequest);
        Task CreateOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task RemoveOrderById(int id);
    }
}