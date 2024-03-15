namespace DubaiPhoneClone.Models
{
    public class OrderItem
    {

        public int Id { get; set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }
        public int Quantity { get; set; }


        public Product? Product { get; set; }

        public Order? Order { get; set; }

    }
}
