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
        public IQueryable<Coupon> GetAllCoupon();

        public Coupon GetCouponByID(int Coupon);

        public Coupon CreateCoupon(Coupon Coupon);

        public Coupon UpdateCoupon(Coupon Coupon);

        public Coupon DeleteCoupon(int CouponId);
    }
}
