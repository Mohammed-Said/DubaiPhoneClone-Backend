namespace DubaiPhoneClone.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public Product? Product { get; set; }

        public User? User { get; set; }
    }
}
