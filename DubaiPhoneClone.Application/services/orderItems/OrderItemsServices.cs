using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderItems
{
    public class OrderItemsServices
    {
        IOrderItemRepository _repo;
        public OrderItemsServices(IOrderItemRepository repo)
        {
            _repo = repo;
        }
        public OrderItem CreateOrderItem(OrderItem orderItem)
        {
            var OrderItem = _repo.Create(orderItem);
            _repo.Save();
            return OrderItem;
        }

        public OrderItem DeleteOrderItem(int OrderItemId)
        {
            var deltecart = _repo.Delete(OrderItemId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<OrderItem> GetAllOrderItem()
        {
            var query = _repo.GetAll();
            return query;
        }

        public OrderItem GetOrderItemByID(int OrderItem)
        {
            var element = _repo.GetById(OrderItem);
            return element;
        }

        public OrderItem UpdateOrderItem(OrderItem OrderItem)
        {
            var updatecart = _repo.Update(OrderItem);
            _repo.Save();
            return updatecart;
        }
    }
}
