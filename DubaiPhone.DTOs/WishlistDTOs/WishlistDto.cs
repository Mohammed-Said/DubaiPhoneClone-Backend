using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.WishlistDTOs
{
    public class WishlistDto
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Name { get; set; }
        public decimal NormalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Cover { get; set; }
    }
}
