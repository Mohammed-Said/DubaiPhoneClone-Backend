namespace DubaiPhoneClone.Models
{
    public class OrderCoupon
    {

        public int Id { get; set; }
        public int OrderID { get; set; }
        public Order? Order { get; set; }
        public int CouponId { get; set; }
        public Coupon? Coupon { get; set; }

    }
}
