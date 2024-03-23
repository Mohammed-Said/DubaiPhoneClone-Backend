using DubaiPhone.DTOs.OrderDTOs;
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
        public Task<List<getOrderDTO>> GetAllOrder();

        public Task<getOrderDTO> GetOrderByID(int Order);

        public Task<Order> CreateOrder(CreateOrderDTO Order);

        public Task<Order> UpdateOrder(UpdateOrderDTO Order);

        public Task<Order> DeleteOrder(int OrderId);
        
    }
}
