namespace DubaiPhoneClone.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; } = OrderStatus.pending.ToString();
        public decimal TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
        public DateTime? DeliveredOn { get; set; }

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string ShippingMethod { get; set; } = string.Empty;
        public string? Store { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        //User-Order one to many
        public User? User { get; set; }
        public virtual Coupon? Coupon { get; set; }
        public List<OrderItem>? OrderItems { get; set; }


    }
}
