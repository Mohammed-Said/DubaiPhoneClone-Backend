namespace DubaiPhoneClone.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ArabicName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Percent { get; set; }

        //Product-Category one to many
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //Product-Brand one to many
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public List<ProductImage>? Images { get; set; }

        //Product-Order many to many
        public List<OrderItem>? OrderItems { get; set; }


        ////User-Product many to many Add To Cart
        public List<CartItem>? CartItems { get; set; }

        ////User-Product many to many Add To Wishlist
        public List<WishlistItem>? WishlistItems { get; set; }


        
    }
}
