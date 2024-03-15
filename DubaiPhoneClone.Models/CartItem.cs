namespace DubaiPhoneClone.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductID { get; set; }
        public int Quantity { get; set; }


        public Product? Product { get; set; }

        public User? User { get; set; }
    }
}
