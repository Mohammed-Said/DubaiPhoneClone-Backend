using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.cartDTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
