using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryFreshBread.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BakeryFreshBreadContext _context;
        public OrderRepository(BakeryFreshBreadContext context)
        {
            _context = context;
        }

        public int GetTotalCountInAorder(OrderDTO data)
        {
            var breadOrderCollection = data.BreadOrder;
            int totalQuantity = 0;
            foreach (var breadOrder in breadOrderCollection)
            {
                totalQuantity += breadOrder.Quantity;
            }
            return totalQuantity;
        }
        public OrderDTO CreateOrder(OrderDTO data)
        {
            var totalCost = TotalCost(data.BreadOrder);

            var order = new Order()
            {
                OfficeId = data.OfficeId,
                Status = data.Status,
                TotalCost = totalCost,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            SaveBreadOrder(order.OrderId, data.BreadOrder);
            return data;
        }

        private void SaveBreadOrder(int orderId, IEnumerable<BreadOrderDTO> orderDto)
        {
            foreach (var breadOrder in orderDto)
            {
                var breadOrderDb = new BreadOrder()
                {
                    OrderId = orderId,
                    BreadId = breadOrder.BreadId,
                    Quantity = breadOrder.Quantity
                };
                _context.BreadOrders.Add(breadOrderDb);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {

            var allOrders = await _context.Orders.ToListAsync();

            return allOrders;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var currentOrder = _context.Orders.SingleOrDefaultAsync(x => x.OrderId == id);
            return await currentOrder;
        }

        public async Task RemoveOrderById(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.OrderId == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        public float TotalCost(IEnumerable<BreadOrderDTO> breadOrder)
        {
            float totalCost = 0;

            foreach (var item in breadOrder)
            {
                var bread = _context.Breads.FirstOrDefault(x => x.BreadId == item.BreadId);
                totalCost += item.Quantity * bread.Price;
            }

            return totalCost;
        }
    }
}