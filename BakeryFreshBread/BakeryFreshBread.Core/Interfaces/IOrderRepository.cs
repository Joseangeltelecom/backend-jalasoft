using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakeryFreshBread.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        OrderDTO CreateOrder(OrderDTO orderDTO);
        Task<Order> GetOrderById(int id);
        Task<IEnumerable<Order>> GetAllOrder();
        Task RemoveOrderById(int id);
    }
}