using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.cartDTOs
{
    public class CreateCartItemDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
