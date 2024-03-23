using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DubaiPhoneClone.Models
{
    public class Product
    {
        public Product() {
            Images = new List<ProductImage>();
            Users=new List<User>();
            OrderItems=new List<OrderItem>();
            CartItems=new List<CartItem>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="please  enter the arabic name")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="the arabic name of the product between 3 to 50 characters")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "please  enter the English name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "the English name of the product between 3 to 50 characters")]
        public string Name { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="sorry the quantity between  0  to 2147483647")]
        [Required(ErrorMessage = "please  enter the quantity of this product in our stock")]
        public int Stock { get; set; }
       
        public string Description { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;

        [Required(ErrorMessage ="how much does this product cost our clients?")]
        public decimal NormalPrice { get; set; }
        public decimal SalePrice { get; set; }

        //Product-Category one to many
        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //Product-Brand one to many
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public List<ProductImage>? Images { get; set; }

        //Product-Order many to many
        public List<OrderItem>? OrderItems { get; set; }


        ////User-Product many to many Add To Cart
        public List<CartItem>? CartItems { get; set; }

        ////User-Product many to many Add To Wishlist
        public List<User>? Users { get; set; }


        
    }
}
