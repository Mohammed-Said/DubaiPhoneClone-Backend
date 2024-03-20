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
        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            var Coupon =await _repo.Create(coupon);
            await _repo.Save();
            return Coupon;
        }

        public async Task<Coupon> DeleteCoupon(int CouponId)
        {
            var deltecart =await _repo.Delete(CouponId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<Coupon>> GetAllCoupon()
        {
            var query = await _repo.GetAll();
            return query;
        }

        public async Task<Coupon> GetCouponByID(int Coupon)
        {
            var element = await _repo.GetById(Coupon);
            return element;
        }

        public async Task<Coupon> UpdateCoupon(Coupon Coupon)
        {
            var updatecart =await _repo.Update(Coupon);
            await _repo.Save();
            return updatecart;
        }
    }
}
