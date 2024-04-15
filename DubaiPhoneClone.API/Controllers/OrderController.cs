using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhone.DTOs.OrderDTOs;
using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Application.services.orderServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            this._orderServices = orderServices;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateOrderDto _order)
        {
            if (ModelState.IsValid)
            {

                await _orderServices.CreateOrder(_order);
                return Ok(_order);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _orderServices.DeleteOrder(id) == null)
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var order = await _orderServices.GetAllOrder();
            if (order == null || order.Count() == 0)
            {
                return NoContent();
            }
            return Ok(order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            OrderDto order = await _orderServices.GetOrderByID(id);
            if (order == null)
            {
                return NoContent();
            }
            return Ok(order);
        }

        [HttpGet("GetUserOrders")]
        public async Task<ActionResult> GetUserOrders(string id)
        {
            List<OrderDto> order = await _orderServices.GetUserOrders(id);
            if (order == null || order.Count==0)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
