namespace DubaiPhone.DTOs.cartDTOs
{
    public class ProductCartDTO
    {
        public int ProductId { get; set; }
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public decimal NormalPrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
