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
     

        public async Task<Order> CreateOrder(CreateOrderDTO _order)
        {
            Order order = mapper.Map<Order>(_order); 
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

        public async Task<List<getOrderDTO>>  GetAllOrder()
        {
            var orders = await (await _repo.GetAll()).ToListAsync();
            return mapper.Map<List<getOrderDTO>>(orders);
        }

        public async Task<getOrderDTO> GetOrderByID(int Order)
        {
            var element = await _repo.GetById(Order);
            return mapper.Map<getOrderDTO>(element);
        }

        public async Task<Order> UpdateOrder(UpdateOrderDTO _Order)
        {
            Order order= mapper.Map<Order>(_Order);
            var updatecart = await _repo.Update(order);
            await _repo.Save();
            return updatecart;
        }
    }
}
