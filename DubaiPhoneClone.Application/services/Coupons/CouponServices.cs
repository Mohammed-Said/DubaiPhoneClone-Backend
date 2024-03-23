using AutoMapper;
using DubaiPhone.DTOs.CouponDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DubaiPhoneClone.Application.services.Coupons
{
    public class CouponServices
    {
        ICouponRepository _repo;
        private readonly IMapper mapper;

        public CouponServices(ICouponRepository repo,IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        public async Task<Coupon> CreateCoupon(CreateCouponDTO _coupon)
        {
            Coupon coupon= mapper.Map<Coupon>(_coupon);
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

        public async Task<List<GetCouponDTO>> GetAllCoupon()
        {
            var query = await _repo.GetAll();
            return mapper.Map<List<GetCouponDTO>>(query);
        }

        public async Task<GetCouponDTO> GetCouponByID(int Coupon)
        {
            var element = await _repo.GetById(Coupon);
            return mapper.Map<GetCouponDTO>(element); ;
        }

        public async Task<Coupon> UpdateCoupon(UpdateCouponDTO _coupon)
        {
            Coupon coupon = mapper.Map<Coupon>(_coupon);

            var updatecart =await _repo.Update(coupon);
            await _repo.Save();
            return updatecart;
        }
    }
}
