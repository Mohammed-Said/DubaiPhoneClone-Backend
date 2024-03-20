using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.productDTOs
{
    public class GetProductDetails
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Percent { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public List<WishlistItem>? WishlistItems { get; set; }
        public List<ProductImage>? Images { get; set; }
    }
}
