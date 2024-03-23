using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime DeliverdOn { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        //User-Order one to many
        public int UserId { get; set; }
        public virtual Coupon? Coupon { get; set; }

    }
}
