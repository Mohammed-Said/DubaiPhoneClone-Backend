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
        public IQueryable<Order> GetAllOrder();

        public Order GetOrderByID(int Order);

        public Order CreateOrder(Order Order);

        public Order UpdateOrder(Order Order);

        public Order DeleteOrder(int OrderId);
        
    }
}
