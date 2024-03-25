using DubaiPhone.DTOs.CouponDTOs;
using DubaiPhoneClone.Application.services.Coupons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponServices _couponServices;

        public CouponController(ICouponServices couponServices)
        {
    
            this._couponServices = couponServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var Coupon = await _couponServices.GetAllCoupon();
            if (Coupon == null || Coupon.Count() == 0)
            {
                return NoContent();
            }
            return Ok(Coupon);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var Coupon = await _couponServices.GetCouponByID(id);
            if (Coupon == null)
            {
                return NoContent();
            }
            return Ok(Coupon);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateCouponDTO _order)
        {
            if (ModelState.IsValid)
            {

                await _couponServices.CreateCoupon(_order);
                return Ok(_order);

            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCouponDTO Coupon)
        {
            if (ModelState.IsValid)
            {
                await _couponServices.UpdateCoupon(Coupon);
                return Ok(Coupon);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _couponServices.DeleteCoupon(id) == null)
                return BadRequest();
            return Ok();
        }
    }
}
