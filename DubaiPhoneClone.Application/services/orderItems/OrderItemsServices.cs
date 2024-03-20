using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderItems
{
    public class OrderItemsServices:IOrderItemsServices
    {
        IOrderItemRepository _repo;
        public OrderItemsServices(IOrderItemRepository repo)
        {
            _repo = repo;
        }
        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            var OrderItem = await _repo.Create(orderItem);
            await _repo.Save();
            return OrderItem;
        }

        public async Task<OrderItem> DeleteOrderItem(int OrderItemId)
        {
            var deltecart = await _repo.Delete(OrderItemId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<OrderItem>>  GetAllOrderItem()
        {
            var query = await _repo.GetAll();
            return query;
        }

        public async Task<OrderItem> GetOrderItemByID(int OrderItem)
        {
            var element = await _repo.GetById(OrderItem);
            return element;
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem OrderItem)
        {
            var updatecart = await _repo.Update(OrderItem);
            await _repo.Save();
            return updatecart;
        }
    }
}
