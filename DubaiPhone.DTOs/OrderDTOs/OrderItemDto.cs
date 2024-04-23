using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.OrderDTOs
{
    public class OrderItemDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Cover { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }

    }
}
