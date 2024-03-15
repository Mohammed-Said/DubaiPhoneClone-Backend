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
        public IQueryable<OrderCoupon> GetAllOrderCoupon();

        public OrderCoupon GetOrderCouponByID(int OrderCoupon);

        public OrderCoupon CreateOrderCoupon(OrderCoupon OrderCoupon);

        public OrderCoupon UpdateOrderCoupon(OrderCoupon OrderCoupon);

        public OrderCoupon DeleteOrderCoupon(int OrderCouponId);
    }
}
