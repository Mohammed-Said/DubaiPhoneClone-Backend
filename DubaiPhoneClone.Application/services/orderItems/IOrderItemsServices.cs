using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderItems
{
    public interface IOrderItemsServices
    {
        public Task<IQueryable<OrderItem>> GetAllOrderItem();

        public Task<OrderItem> GetOrderItemByID(int OrderItem);

        public Task<OrderItem> CreateOrderItem(OrderItem OrderItem);

        public Task<OrderItem> UpdateOrderItem(OrderItem OrderItem);

        public Task<OrderItem> DeleteOrderItem(int OrderItemId);
    }
}
