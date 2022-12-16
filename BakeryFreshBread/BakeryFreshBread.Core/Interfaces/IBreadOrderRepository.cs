using BakeryFreshBread.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakeryFreshBread.Core.Interfaces
{
    public interface IBreadOrderRepository
    {
        Task<IEnumerable<BreadOrder>> GetBreadOrders();
        Task<BreadOrder> GetBreadOrdersById(int id);
        Task DeleteBreadOrdersById(int id);
    }
}
