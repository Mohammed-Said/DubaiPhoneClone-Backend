namespace DubaiPhone.DTOs
{
    public class ProductCart
    {
        public int ProductId { get; set; }
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
