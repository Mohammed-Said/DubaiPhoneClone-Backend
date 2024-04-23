using DubaiPhone.DTOs.OrderDTOs;
using DubaiPhoneClone.Application.services.orderServices;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dashboard.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderServices.GetAllOrder();

            return View(orders);
        }
        

        public async Task<IActionResult> Edit(int id)
        {
            var orderDto = await _orderServices.GetOrderByID(id);
            if (orderDto == null)
            {
                return NotFound();
            }

            var updateOrderDto = new UpdateOrderDto
            {
                Id = orderDto.Id,
                Status = orderDto.Status,
                TotalPrice = orderDto.TotalPrice,
                OrderedAt = orderDto.OrderedAt,
                Address = orderDto.Address,
                City = orderDto.City,
                ShippingMethod = orderDto.ShippingMethod,
                FirstName = orderDto.FirstName,
                LastName = orderDto.LastName,
                Phone = orderDto.Phone,
                UserId = orderDto.UserId,
                DeliverdOn = orderDto.DeliveredOn ,

            };

            return View(updateOrderDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateOrderDto updateOrderDto)
        {
            
            bool result = await _orderServices.UpdateOrder(updateOrderDto); 
            return RedirectToAction(nameof(Index));
        }

    }
}
