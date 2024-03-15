using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.Coupons
{
    public class CouponServices
    {
        ICouponRepository _repo;
        public CouponServices(ICouponRepository repo)
        {
            _repo = repo;
        }
        public Coupon CreateCoupon(Coupon coupon)
        {
            var Coupon = _repo.Create(coupon);
            _repo.Save();
            return Coupon;
        }

        public Coupon DeleteCoupon(int CouponId)
        {
            var deltecart = _repo.Delete(CouponId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<Coupon> GetAllCoupon()
        {
            var query = _repo.GetAll();
            return query;
        }

        public Coupon GetCouponByID(int Coupon)
        {
            var element = _repo.GetById(Coupon);
            return element;
        }

        public Coupon UpdateCoupon(Coupon Coupon)
        {
            var updatecart = _repo.Update(Coupon);
            _repo.Save();
            return updatecart;
        }
    }
}
