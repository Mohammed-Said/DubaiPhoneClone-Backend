using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.productDTOs
{
    public class CreatingAndUpdatingProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please  enter the arabic name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "the arabic name of the product between 3 to 50 characters")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "please  enter the English name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "the English name of the product between 3 to 50 characters")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "sorry the quantity between  0  to 2147483647")]
        [Required(ErrorMessage = "please  enter the quantity of this product in our stock")]
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "how much does this product cost our clients?")]
        public decimal NormalPrice { get; set; }
        public decimal SalePercent { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
