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
        public Task<IQueryable<Coupon>> GetAllCoupon();

        public Task<Coupon> GetCouponByID(int Coupon);

        public Task<Coupon> CreateCoupon(Coupon Coupon);

        public Task<Coupon> UpdateCoupon(Coupon Coupon);

        public Task<Coupon> DeleteCoupon(int CouponId);
    }
}
