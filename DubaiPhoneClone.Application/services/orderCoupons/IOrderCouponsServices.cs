using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.orderCoupons
{
    public interface IOrderCouponsServices
    {
        public Task<IQueryable<OrderCoupon>> GetAllOrderCoupon();

        public Task<OrderCoupon> GetOrderCouponByID(int OrderCoupon);

        public Task<OrderCoupon> CreateOrderCoupon(OrderCoupon OrderCoupon);

        public Task<OrderCoupon> UpdateOrderCoupon(OrderCoupon OrderCoupon);

        public Task<OrderCoupon> DeleteOrderCoupon(int OrderCouponId);
    }
}
