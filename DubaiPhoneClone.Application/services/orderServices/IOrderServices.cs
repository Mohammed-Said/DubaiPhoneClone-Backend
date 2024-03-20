using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderServices
{
    public interface IOrderServices
    {
        public Task<IQueryable<Order>> GetAllOrder();

        public Task<Order> GetOrderByID(int Order);

        public Task<Order> CreateOrder(Order Order);

        public Task<Order> UpdateOrder(Order Order);

        public Task<Order> DeleteOrder(int OrderId);
        
    }
}
