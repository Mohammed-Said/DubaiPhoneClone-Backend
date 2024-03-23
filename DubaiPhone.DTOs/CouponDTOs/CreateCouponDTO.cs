using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.CouponDTOs
{
    public class CreateCouponDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Percent { get; set; }
        public int? OrderId { get; set; }
    }
}
