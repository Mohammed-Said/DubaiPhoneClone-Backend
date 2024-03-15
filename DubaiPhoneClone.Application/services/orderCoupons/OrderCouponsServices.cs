using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderCoupons
{
    public class OrderCouponsServices
    {
        IOrderCouponRepository _repo;
        public OrderCouponsServices(IOrderCouponRepository repo)
        {
            _repo = repo;
        }
        public OrderCoupon CreateOrderCoupon(OrderCoupon orderCoupon)
        {
            var OrderCoupon = _repo.Create(orderCoupon);
            _repo.Save();
            return OrderCoupon;
        }

        public OrderCoupon DeleteOrderCoupon(int OrderCouponId)
        {
            var deltecart = _repo.Delete(OrderCouponId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<OrderCoupon> GetAllOrderCoupon()
        {
            var query = _repo.GetAll();
            return query;
        }

        public OrderCoupon GetOrderCouponByID(int OrderCoupon)
        {
            var element = _repo.GetById(OrderCoupon);
            return element;
        }

        public OrderCoupon UpdateOrderCoupon(OrderCoupon OrderCoupon)
        {
            var updatecart = _repo.Update(OrderCoupon);
            _repo.Save();
            return updatecart;
        }
    }
}
