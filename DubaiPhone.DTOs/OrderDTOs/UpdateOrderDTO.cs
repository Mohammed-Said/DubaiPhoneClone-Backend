using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.OrderDTOs
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime? DeliverdOn { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string ShippingMethod { get; set; }
        public string? Store { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        //User-Order one to many
        public string UserId { get; set; }
        public virtual Coupon? Coupon { get; set; }

    }
}
