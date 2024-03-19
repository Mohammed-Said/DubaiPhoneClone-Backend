using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderCoupons
{
    public class OrderCouponsServices: IOrderCouponsServices
    {
        IOrderCouponRepository _repo;
        public OrderCouponsServices(IOrderCouponRepository repo)
        {
            _repo = repo;
        }
        public async Task<OrderCoupon> CreateOrderCoupon(OrderCoupon orderCoupon)
        {
            var OrderCoupon =await _repo.Create(orderCoupon);
            await _repo.Save();
            return OrderCoupon;
        }

        public async Task<OrderCoupon> DeleteOrderCoupon(int OrderCouponId)
        {
            var deltecart =await _repo.Delete(OrderCouponId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<OrderCoupon>> GetAllOrderCoupon()
        {
            var query =await _repo.GetAll();
            return query;
        }

        public async Task<OrderCoupon> GetOrderCouponByID(int OrderCoupon)
        {
            var element =await _repo.GetById(OrderCoupon);
            return element;
        }

        public async Task<OrderCoupon> UpdateOrderCoupon(OrderCoupon OrderCoupon)
        {
            var updatecart = await _repo.Update(OrderCoupon);
            await _repo.Save();
            return updatecart;
        }
    }
}
