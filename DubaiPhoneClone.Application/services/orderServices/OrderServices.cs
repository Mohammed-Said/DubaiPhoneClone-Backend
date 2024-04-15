using AutoMapper;
using DubaiPhone.DTOs.OrderDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;

        public OrderServices(IOrderRepository repo,IMapper mapper) {

        _repo = repo;
            this.mapper = mapper;
        }
     

        public async Task<Order> CreateOrder(CreateOrderDto _order)
        {
            Order order = mapper.Map<Order>(_order); 
            var Order = await _repo.CreateOrder(order);
            await _repo.Save();
            return Order;
        }

        public async Task<Order> DeleteOrder(int OrderId)
        {
            var deltecart = await _repo.Delete(OrderId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<List<OrderDto>>  GetAllOrder()
        {
            var orders = await (await _repo.GetAll()).ToListAsync();
            return mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByID(int Order)
        {
            var element = await _repo.GetById(Order);
            return mapper.Map<OrderDto>(element);
        }

        public async Task<List<OrderDto>> GetUserOrders(string userId)
        {
           var orders= await _repo.GetUserOrders(userId).ToListAsync();

           return mapper.Map<List<OrderDto>>(orders);
        }
    }
}
