using BakeryFreshBread.Core.DTO_s;
using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Enumerations;
using BakeryFreshBread.Core.Exceptions;
using BakeryFreshBread.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public List<BreadOrder> breadOrderList { get; set; }
        public List<Order> orderList { get; set; }

        async public Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        async public Task CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        async public Task<BreadOrder> CreateBreadOrder(CreateOrderRequest createOrderRequest)
        {
            Bread CurrentBread = _context.Breads.SingleOrDefault(bread => bread.BreadId == createOrderRequest.BreadId);
            Order CurrentOrder = _context.Orders.SingleOrDefault(order => order.OrderId == createOrderRequest.OrderId);
           
            BreadOrder newBreadOrder = new BreadOrder()
            {
                Bread = CurrentBread,
                Order = CurrentOrder,
                Quantity = createOrderRequest.BreadQuantity,
            };

            _context.BreadOrders.Add(newBreadOrder);
            await _context.SaveChangesAsync();
            return newBreadOrder;
        }


        async public Task CreateOrderWithRequest(CreateOrderRequest createOrderRequest)
        {
            //Office CurrentOffice = _context.Offices.SingleOrDefault(office => office.OfficeId == createOrderRequest.OfficeId);
            var breadOrdersList = new List<BreadOrder>();
            var newBreadOrder = await CreateBreadOrder(createOrderRequest);
            breadOrdersList.Add(newBreadOrder);

            Order newOrder = new Order()
            {
                BreadOrder = breadOrdersList,
                Status = StatusType.processing,
                TotalCost = 200,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
        }

        //async public Task<float> GeTotalCost()
        //{
        //    float? total = 0;
        //    total = (float?)(from breadOrder in _context.Orders
        //                     select (int?)cartItems.Quantity *
        //                       cartItems.Product.UnitPrice).Sum();
        //    return total ?? float.Zero;

        //    return totalCost;
        //}

        async public Task AddBreadOrderToSpecificOrderList(CreateOrderRequest createOrderRequest)
        {
            //Office CurrentOffice = _context.Offices.SingleOrDefault(office => office.OfficeId == createOrderRequest.OfficeId);

            var bread = _context.Breads.FirstOrDefault(
                  p => p.BreadType == createOrderRequest.Breadtype);

            //if (CurrentOffice != null && bread != null)
            //{
            //    BreadOrder newBreadOrder = new BreadOrder()
            //    {
            //        Bread = bread,
            //        Quantity = createOrderRequest.BreadQuantity
            //    };

            //    breadOrderList.Add(newBreadOrder);

            //    Order newOrder = new Order()
            //    {
            //        BreadOrder = breadOrderList,
            //        Status = StatusType.processing,
            //        TotalCost = 200,
            //        DateCreated = DateTime.Now,
            //        DateModified = DateTime.Now
            //    };

            //    orderList.Add(newOrder);

            //    CurrentOffice.Orders = orderList;
            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    throw new EntityNotFoundException("Office not found");
            //}
        }

        async public Task<Order> GetOrderById(int id)
        {
            var currentOrder = _context.Orders.FirstOrDefaultAsync(order => order.OrderId == id);
            if (currentOrder != null)
            {
                return await currentOrder;
            }
            else
            {
                throw new EntityNotFoundException("Order not found");
            }
        }

        async public Task RemoveOrderById(int id)
        {
            var currentOrder = await GetOrderById(id);
            if (currentOrder != null)
            {
                _context.Orders.Remove(currentOrder);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new EntityNotFoundException("Order not found");
            }
        }
    }
}