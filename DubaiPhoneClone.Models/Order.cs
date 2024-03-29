namespace DubaiPhoneClone.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime DeliverdOn { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty ;

        //User-Order one to many
        public string UserId { get; set; }

        public User? User { get; set; }
        public virtual Coupon? Coupon { get; set; }
        public List<OrderItem>? OrderItems { get; set; }






    }
}
