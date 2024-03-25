using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderServices
{
    public class OrderServices:IOrderServices
    {
        IOrderRepository _repo;
        public OrderServices(IOrderRepository repo) {
        _repo = repo;
        }
     

        public async Task<Order> CreateOrder(Order order)
        {
            var Order = await _repo.Create(order);
            await _repo.Save();
            return Order;
        }

        public async Task<Order> DeleteOrder(int OrderId)
        {
            var deltecart = await _repo.Delete(OrderId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<Order>>  GetAllOrder()
        {
            var query = await _repo.GetAll();
            return query;
        }

        public async Task<Order> GetOrderByID(int Order)
        {
            var element = await _repo.GetById(Order);
            return element;
        }

        public async Task<Order> UpdateOrder(Order Order)
        {
            var updatecart = await _repo.Update(Order);
            await _repo.Save();
            return updatecart;
        }
    }
}
