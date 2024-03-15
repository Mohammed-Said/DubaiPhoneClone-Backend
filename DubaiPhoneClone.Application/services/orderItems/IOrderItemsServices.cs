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
        public IQueryable<OrderItem> GetAllOrderItem();

        public OrderItem GetOrderItemByID(int OrderItem);

        public OrderItem CreateOrderItem(OrderItem OrderItem);

        public OrderItem UpdateOrderItem(OrderItem OrderItem);

        public OrderItem DeleteOrderItem(int OrderItemId);
    }
}
