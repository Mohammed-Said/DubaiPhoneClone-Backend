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
        IOrederRepository _repo;
        public OrderServices(IOrederRepository repo) {
        _repo = repo;
        }
     

        public Order CreateOrder(Order order)
        {
            var Order = _repo.Create(order);
            _repo.Save();
            return Order;
        }

        public Order DeleteOrder(int OrderId)
        {
            var deltecart = _repo.Delete(OrderId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<Order> GetAllOrder()
        {
            var query = _repo.GetAll();
            return query;
        }

        public Order GetOrderByID(int Order)
        {
            var element = _repo.GetById(Order);
            return element;
        }

        public Order UpdateOrder(Order Order)
        {
            var updatecart = _repo.Update(Order);
            _repo.Save();
            return updatecart;
        }
    }
}
