using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        private readonly ApplicationContext _appContext;

        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _appContext = applicationContext;
        }

        public async Task<Order?> CreateOrder(Order order)
        {
            _appContext.Orders.Add(order);
            _appContext.SaveChanges();

            //Add Cart items into Order items
            //Get All Customer Catr items
            var cartItems =await _appContext.CartItems.Where(c => c.UserId == order.UserId).ToListAsync();

            if (cartItems is null ||  cartItems.Count() == 0)
                return null;

            foreach (var item in cartItems)
            {
                //Create Order item
                OrderItem orderItem = new OrderItem();
                orderItem.OrderID = order.Id;
                orderItem.Quantity = item.Quantity;
                orderItem.ProductID = item.ProductID;
                var prod =await _appContext.Products.FindAsync(item.ProductID);

                if (prod is null)
                    continue;

                prod.Stock -= item.Quantity;
                orderItem.Price=prod.SalePrice;

                order.TotalPrice += prod.SalePrice * orderItem.Quantity;
                _appContext.OrderItems.Add(orderItem);

                //Remove CartItems
                _appContext.CartItems.Remove(item);
            }
            _appContext.SaveChanges();

            return order;

        }

        public IQueryable<Order> GetUserOrders(string userId) =>
            _appContext.Orders.Where(o => o.UserId == userId).Include(o => o.OrderItems);
        
    }
}
