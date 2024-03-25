using DubaiPhone.DTOs.CouponDTOs;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.Coupons
{
    public interface ICouponServices
    {
        public Task<List<GetCouponDTO>> GetAllCoupon();

        public Task<GetCouponDTO> GetCouponByID(int Coupon);

        public Task<Coupon> CreateCoupon(CreateCouponDTO Coupon);

        public Task<Coupon> UpdateCoupon(UpdateCouponDTO Coupon);

        public Task<Coupon> DeleteCoupon(int CouponId);
    }
}
