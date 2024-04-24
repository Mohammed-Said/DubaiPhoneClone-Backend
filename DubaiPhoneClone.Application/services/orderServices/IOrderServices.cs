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
        public Task<List<OrderDto>> GetAllOrder();

        public Task<OrderDto> GetOrderByID(int Order);

        public Task<Order> CreateOrder(CreateOrderDto Order);

        public Task<Order> DeleteOrder(int OrderId);

        public Task<List<OrderDto>> GetUserOrders(string userId);
        public Task<bool> UpdateOrder(UpdateOrderDto updateOrderDto);


    }
}
